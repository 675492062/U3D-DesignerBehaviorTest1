/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-17   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;

public class EW_LevelConfig : MapEditor
{
    const string NAME_LEVELS_PARENT = "LEVEL_CONFIG_PARENT";

    const string KEY_LCTableIndex = "LCTableIndex";
    const string KEY_LCDungeonIndex = "LCDungeonIndex";
    const string KEY_LCChapterIndex = "LCChapterIndex";

    private GameObject mParent;
    private GameObject goParent
    {
        get
        {
            if (mParent == null)
            {
                mParent = GameObject.Find(NAME_LEVELS_PARENT);

                if (mParent == null)
                {
                    mParent = new GameObject();
                    mParent.name = NAME_LEVELS_PARENT;
                }
            }
            return mParent;
        }
    }

    private List<LevelConfig> mExistLevels = new List<LevelConfig>();
    private List<LevelConfig> existLevels
    {
        get
        {
            if (goParent.transform.childCount != mExistLevels.Count)
            {
                mExistLevels.Clear();
                foreach (Transform t in goParent.transform)
                {
                    LevelConfig lc = t.GetComponent<LevelConfig>();
                    if (lc)
                    {
                        mExistLevels.Add(lc);
                    }
                    else
                    {
                        Debug.Log("what's a fuck this? ", t);
                        t.parent = null;
                    }
                }
            }
            return mExistLevels;
        }
    }

    private static LevelConfig curLevel;
    private static Object targetPrefab;

    static string[] mPopMethods;
    private static string[] popMethods
    {
        get { if (mPopMethods == null) mPopMethods = LevelFlowCtrl.getMethodList.ToArray(); return mPopMethods; }
    }

    private Vector2 srlAcitons = Vector2.zero;

    protected override void ShowOverrideGUI()
    {
        ShowLevelDetails();
    }

    void ShowLevelDetails()
    {

        if (curLevel == null)
        {
            //find in scene and set
            curLevel = GameObject.FindObjectOfType(typeof(LevelConfig)) as LevelConfig;

            //set to last data
            if (curLevel)
            {
                select.curChapterIndex = EditorPrefs.GetInt(KEY_LCChapterIndex, select.curChapterIndex);
                select.curDungeonIndex = EditorPrefs.GetInt(KEY_LCDungeonIndex, select.curDungeonIndex);
                select.curConfigIndex = EditorPrefs.GetInt(KEY_LCTableIndex, select.curConfigIndex);
            }

        }

        #region level prefab
        GUILayout.BeginHorizontal();

        string resName = select.prbMapRes ? "Res:" : select.curDungeon.resname;
        GUILayout.Label(resName);
        bool hasRes = EditorGUILayout.ObjectField("", select.prbMapRes, typeof(Object), false);

        if (!hasRes) return;


        bool hasConfig = select.prbLevelConfig;

        if (!hasConfig)
        {
            if (select.prbModelConfig && GUILayout.Button("Create Config"))
            {
                CreateConfigPrefab();
            }
        }
        else
        {
            GUILayout.Label("Config:");
            EditorGUILayout.ObjectField("", select.prbLevelConfig, typeof(Object), false);

            //if (curLevel != null && curLevel.name == select.prbLevelConfig.name)
            //{
            //    if (GUILayout.Button("Edit")) EditLevel();
            //}
            if (GUILayout.Button("Show In Scene"))
            {
                LoadLevelToScene();
            }

            //, GUILayout.MinWidth(200f)
            if (GUILayout.Button("ReLoad Json", GUILayout.MaxWidth(100f)))
            {
                ReLoadJson();
            }
        }

        GUILayout.EndHorizontal();
        #endregion


        if (curLevel == null) return;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            SaveLevel();
        }

        if (GUILayout.Button("Edit", GUILayout.MaxWidth(100f)))
        {
            KMTools.SetActive(curLevel.gameObject, true);
            EditLevel();
        }
        GUILayout.EndHorizontal();
        if (KMInspectorEditor.DrawHeader("Position Edit"))
        {
            ShowPositions();
        }

        EditorGUILayout.Space();

        if (KMInspectorEditor.DrawHeader("Stage Actions"))
        {
            ShowLevelActions();
        }

        EditorGUILayout.Space();

        if (KMInspectorEditor.DrawHeader("External Event"))
        {
            ShowExternalEvent();
        }

        EditorGUILayout.Space();

        if (KMInspectorEditor.DrawHeader("Other------"))
        {
            ShowOther();
        }

    }

    void ShowPositions()
    {
        GUILayout.Space(3f);
        GUILayout.BeginHorizontal();
        if (curLevel.ground) { }
        if (GUILayout.Button("玩家坐标" + curLevel.heroStartPos.position))
        {
            GoToSelect(curLevel.heroStartPos.gameObject);
        }
        if (GUILayout.Button("地图区域"))
        {
            GoToSelect(curLevel.ground.gameObject);
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3f);
        GUILayout.BeginHorizontal();
        Transform trans;
        for (int i = 0; i < curLevel.enemyPos.Count; i++)
        {
            bool isNextLine = i % 4 == 0;
            if (isNextLine) { GUILayout.EndHorizontal(); GUILayout.BeginHorizontal(); }
            GUILayout.Space(10f);
            trans = curLevel.enemyPos[i];
            if (GUILayout.Button("No." + (i + 1) + " : " + trans.position, GUILayout.Width(150)))
            {
                GoToSelect(trans.gameObject);
            }
            if ((GUILayout.Button("-", GUILayout.Width(20))))
            {
                curLevel.RemoveEnemyPos(trans);
                return;
            }
        }

        GUILayout.EndHorizontal();
        GUILayout.Space(4f);
        if (GUILayout.Button("Add Enemy Pos"))
        {
            GoToSelect(curLevel.AddEnemyPos());
        }
    }

    float svHight = 200;
    int sumEnemies = 1;
    void ShowLevelActions()
    {
        GUILayout.BeginHorizontal();
        svHight = EditorGUILayout.FloatField("Scroll View Min Height", svHight);

        GUILayout.Label("| 敌人总数量:" + sumEnemies + "|");
        GUILayout.EndHorizontal();
        //EditorTools.DrawSeparator();


        GUILayout.BeginHorizontal();
        GUILayout.Space(6f);
        GUILayout.BeginVertical();
        srlAcitons = GUILayout.BeginScrollView(srlAcitons, GUILayout.MinHeight(svHight));

        List<string> curAction;
        sumEnemies = 0;

        //用于显示外部事件
        int exteralIndex = -1;
        // 显示外部事件完成的执行事件
        int exteralFinishIndex = -1;

        for (int i = 0; i < curLevel.actions.Count; i++)
        {
            if (i == 0) KMInspectorEditor.DrawSeparator();
            GUILayout.Space(2f);
            GUILayout.BeginHorizontal();
            curAction = curLevel.actions[i].action;

            string selAction = WlssEditor.PopupActions(curAction[0]);

            if (selAction != curAction[0] || !curLevel.IsLegalAction(selAction, curAction.Count - 1))
            {
                //当前为事件系统，则需要删除
                string mName = curAction[0];

                if (curAction.Count != 0)
                    curAction[0] = selAction;
                else
                {
                    Debug.Log("     count is 0 ");
                    curAction.Add(selAction);
                }
                curLevel.InitAction(curAction, i);

                if (mName == AllStrings.actWaitExternal)
                {
                    curLevel.DeleteEvent(i);
                }

                GUILayout.EndHorizontal();
                return;
            }

            switch (selAction)
            {
                case AllStrings.actCreateEnemy:
                    #region create Enemy 下方还有一个添加成功事件到敌人的行动

                    //int id 1, ,  float
                    curAction[1] = WlssEditor.PopupEnemies(int.Parse(curAction[1]), GUILayout.MaxWidth(200f)).ToString();

                    //老版本的为字符串
                    if (curAction[2].Length > 2)
                    {
                        curAction[2] = "0";
                    }

                    int enemyPosIndex = int.Parse(curAction[2]);

                    //越界判断
                    if (enemyPosIndex >= curLevel.popEnemyPos.Length) enemyPosIndex = curLevel.popEnemyPos.Length - 1;
                    int selEnemyPosIndex = EditorGUILayout.Popup(enemyPosIndex, curLevel.popEnemyPos, GUILayout.Width(80f));

                    //int count 3,
                    int enemyCount = EditorGUILayout.IntSlider(int.Parse(curAction[3]), 1, 20);
                    // disTime 4
                    GUILayout.Label("Distance:");
                    float disTime = EditorGUILayout.FloatField(float.Parse(curAction[4]));
                    disTime = Mathf.Clamp(disTime, .1f, 10f);

                    //set:
                    if (enemyPosIndex != selEnemyPosIndex
                        || enemyCount != int.Parse(curAction[3])
                        || disTime != float.Parse(curAction[4]))
                    {
                        curAction[2] = selEnemyPosIndex.ToString();
                        curAction[3] = enemyCount.ToString();
                        curAction[4] = disTime.ToString();
                    }
                    #endregion

                    sumEnemies += int.Parse(curAction[3]);
                    break;
                case AllStrings.actWaitForTime:
                    //time 1
                    float wiatTime = EditorGUILayout.FloatField("Wait time (s)", float.Parse(curAction[1]), GUILayout.MaxWidth(200f));
                    wiatTime = Mathf.Abs(wiatTime);
                    curAction[1] = wiatTime.ToString();
                    break;
                case AllStrings.actTimeOver:
                    float timeOver = EditorGUILayout.FloatField("Start Timing (s)", float.Parse(curAction[1]), GUILayout.MaxWidth(200f));
                    timeOver = Mathf.Abs(timeOver);
                    curAction[1] = timeOver.ToString();
                    break;
                case AllStrings.actSetMaxCount:
                    int maxCount = EditorGUILayout.IntField("Set Enemies max count", int.Parse(curAction[1]), GUILayout.MaxWidth(200f));
                    maxCount = Mathf.Clamp(maxCount, 1, 100);
                    curAction[1] = maxCount.ToString();
                    break;
                case AllStrings.actAddSuccessToEnemy:

                    curAction[1] = WlssEditor.PopupEnemies(int.Parse(curAction[1]), GUILayout.MaxWidth(200f)).ToString();

                    //老版本的为字符串
                    if (curAction[2].Length > 2)
                    {
                        curAction[2] = "0";
                    }
                    enemyPosIndex = int.Parse(curAction[2]);
                    if (enemyPosIndex >= curLevel.popEnemyPos.Length) enemyPosIndex = curLevel.popEnemyPos.Length - 1;
                    selEnemyPosIndex = EditorGUILayout.Popup(enemyPosIndex, curLevel.popEnemyPos, GUILayout.Width(80f));
                    if (string.IsNullOrEmpty(curAction[3])) curAction[3] = "1";

                    float scale = float.Parse(curAction[3]);
                    scale = EditorGUILayout.FloatField("缩放比例：", scale);

                    if (selEnemyPosIndex != enemyPosIndex || scale != float.Parse(curAction[3]))
                    {
                        curAction[2] = selEnemyPosIndex.ToString();
                        curAction[3] = scale.ToString();
                    }

                    //用于敌人统计
                    sumEnemies++;
                    break;
                case AllStrings.actWaitExternal:
                    exteralIndex++;
                    // 外部事件
                    if (exteralIndex < curLevel.events.Count)
                    {
                        if (GUILayout.Button(curLevel.events[exteralIndex].name))
                        {
                            GoToSelect(curLevel.events[exteralIndex].gameObject);
                        }
                    }
                    else
                    {
                        Debug.Log(" the event count is error !!!!!");
                        curLevel.AddEventTrigger();
                    }
                    break;
                case AllStrings.actWaitForKill:
                    if (exteralFinishIndex < exteralIndex)
                    {
                        exteralFinishIndex++;
                        if (GUILayout.Button(">>> Wait  " + curLevel.events[exteralFinishIndex].name + "  Finish<<<"))
                        {
                            GoToSelect(curLevel.events[exteralFinishIndex].gameObject);
                        }

                    }

                    break;
                case AllStrings.actAddEnemiesToAllPos:

                    curAction[1] = WlssEditor.PopupEnemies(int.Parse(curAction[1]), GUILayout.MaxWidth(200f)).ToString();
                    enemyCount = EditorGUILayout.IntSlider(int.Parse(curAction[2]), 1, 40);
                    disTime = EditorGUILayout.FloatField("每生成一群等待时间：", float.Parse(curAction[3]));

                    if (enemyCount != int.Parse(curAction[2])
                        || disTime != float.Parse(curAction[3]))
                    {
                        curAction[2] = enemyCount.ToString();
                        curAction[3] = disTime.ToString();
                    }

                    //用于敌人统计
                    sumEnemies += enemyCount;
                    break;
            }

            if (GUILayout.Button("Insert"))
            {
                curLevel.InsertAction(i);
                GUI.changed = true;
                GUILayout.EndHorizontal();
                break;
            }

            if (GUILayout.Button("Delete"))
            {
                curLevel.RemoveAction(i);
                GUILayout.EndHorizontal();
                break;
            }
            GUILayout.EndHorizontal();
            KMInspectorEditor.DrawSeparator();
        }

        if (GUILayout.Button("Add Action"))
        {
            curLevel.AddAction();
        }


        GUILayout.EndScrollView();
        GUILayout.EndVertical();
        GUILayout.Space(3f);
        GUILayout.EndHorizontal();
    }

    void ShowExternalEvent()
    {
        LevelFlowContinue lft;
        for (int i = 0; i < curLevel.events.Count; i++)
        {
            GUILayout.BeginHorizontal();

            lft = curLevel.events[i];
            if (GUILayout.Button(lft.name + ":", GUILayout.Width(100)))
            {
                NGUITools.SetActive(lft.gameObject, true);
                GoToSelect(lft.gameObject);
            }

            List<Transform> parcloseList = lft.parcloseList;
            for (int j = 0; j < parcloseList.Count; j++)
                if (GUILayout.Button(parcloseList[j].name, GUILayout.MaxWidth(100)))
                {
                    GoToSelect(parcloseList[j].gameObject);
                }
                else if ((GUILayout.Button("-", GUILayout.Width(20))))
                {
                    DestroyImmediate(parcloseList[j].gameObject);
                    break;
                }



            //for (int j = 0; j < lft.signList.Count; j++)
            //    if (GUILayout.Button(lft.signList[j].name, GUILayout.MaxWidth(100)))
            //    {
            //        GoToSelect(lft.signList[j].gameObject);
            //    }
            //    else if ((GUILayout.Button("-", GUILayout.Width(20))))
            //    {
            //        DestroyImmediate(lft.signList[j].gameObject);
            //        break;
            //    }



            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if ((GUILayout.Button("Add Parclose")))
            {
                GoToSelect(lft.AddParclose());
            }
            //if ((GUILayout.Button("Add Sign")))
            //{
            //    GoToSelect(lft.AddSign());
            //}
            //if ((GUILayout.Button("Delete Event")))
            //{
            //    curLevel.RemoveEventTrigger(lft);
            //}
            GUILayout.EndHorizontal();

            GUILayout.Space(3f);
        }


        if (GUILayout.Button("Reset Event Trigger"))
        {
            curLevel.ResetEvent();
        }
    }

    void ShowOther()
    {
        //全局屏障显示
        if (curLevel.parcloses.Count > 0)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("屏障物体：");
            GUILayout.BeginHorizontal();
            for (int i = 0; i < curLevel.parcloses.Count; i++)
            {
                if (GUILayout.Button("Parclose ----" + (i + 1))) { GoToSelect(curLevel.parcloses[i].gameObject); }
                else if ((GUILayout.Button("-", GUILayout.Width(20)))) { curLevel.RemoveParclose(i); break; }
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }



        EditorGUILayout.Space();
        //军营显示
        if (curLevel.barracks.Count > 0)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("军营建筑物：");
            GUILayout.BeginHorizontal();
            for (int i = 0; i < curLevel.barracks.Count; i++)
            {
                if (GUILayout.Button("Barrack ----" + (i + 1))) { GoToSelect(curLevel.barracks[i].gameObject); }
                else if ((GUILayout.Button("-", GUILayout.Width(20)))) { curLevel.RemoveBarrack(i); break; }
            }
            GUILayout.EndHorizontal();
            if (curLevel.barracks.Count > 0)
            {
                curLevel.barrackKills = EditorGUILayout.IntSlider("杀完个数取胜:", curLevel.barrackKills, 0, curLevel.barracks.Count);
            }
            EditorGUILayout.EndVertical();
        }

        //城门显示
        if (curLevel.gates.Count > 0)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("城门建筑物：");
            GUILayout.BeginHorizontal();
            for (int i = 0; i < curLevel.gates.Count; i++)
            {
                if (GUILayout.Button("Gate ----" + (i + 1))) { GoToSelect(curLevel.gates[i].gameObject); }
                else if ((GUILayout.Button("-", GUILayout.Width(20)))) { curLevel.RemoveGate(i); break; }
            }
            GUILayout.EndHorizontal();
            if (curLevel.gates.Count > 0)
            {
                curLevel.gateKills = EditorGUILayout.IntSlider("杀完个数取胜:", curLevel.gateKills, 0, curLevel.gates.Count);
            }
            EditorGUILayout.EndVertical();
        }

        //城堡显示
        if (curLevel.castles.Count > 0)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("成败建筑物：");
            GUILayout.BeginHorizontal();
            for (int i = 0; i < curLevel.castles.Count; i++)
            {
                if (GUILayout.Button("Castle ----" + (i + 1))) { GoToSelect(curLevel.castles[i].gameObject); }
                else if ((GUILayout.Button("-", GUILayout.Width(20)))) { curLevel.RemoveCastle(i); break; }
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();
        //添加按钮
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加全局屏障"))
        {
            GoToSelect(curLevel.AddParcloses());
        }
        if (GUILayout.Button("添加敌方军营"))
        {
            GoToSelect(curLevel.AddBarrack());
        }
        if (GUILayout.Button("添加敌方城门"))
        {
            GoToSelect(curLevel.AddGate());
        }
        if (GUILayout.Button("添加城堡"))
        {
            GoToSelect(curLevel.AddCastle());
        }
        GUILayout.EndHorizontal();
    }

    void GoToSelect(GameObject go)
    {
        Selection.activeGameObject = go;
        //KMSceneEditor.GotoScenePoint(go.transform.position);
    }

    void CreateConfigPrefab()
    {
        KMPrefabEditor.ClonePrefab(select.prbModelConfig, select.GetNameByCurConfig());
    }

    void LoadLevelToScene()
    {
        if (curLevel != null)
        {
            curLevel.gameObject.SetActive(false);
        }

        LevelConfig lc = GetExistLevel(select.prbLevelConfig.name);
        if (lc != null)
        {
            lc.gameObject.SetActive(true);
            curLevel = lc;
        }
        else
        {
            GameObject go = KMPrefabEditor.LoadPrefab(select.prbLevelConfig, null);
            go.transform.parent = goParent.transform;
            curLevel = go.GetComponent<LevelConfig>();
        }

        if (curRes) DestroyImmediate(curRes.gameObject);
        curRes = KMPrefabEditor.LoadPrefab(select.prbMapRes, null);

        targetPrefab = select.prbLevelConfig;

        //save data form last load
        EditorPrefs.SetInt(KEY_LCTableIndex, select.curConfigIndex);
        EditorPrefs.SetInt(KEY_LCDungeonIndex, select.curDungeonIndex);
        EditorPrefs.SetInt(KEY_LCChapterIndex, select.curChapterIndex);
    }

    void SaveLevel()
    {
        curLevel.SavePrefab();

        KMPrefabEditor.SavePrefab(curLevel.gameObject, targetPrefab);
    }

    void EditLevel()
    {
        Selection.activeGameObject = curLevel.gameObject;

    }

    LevelConfig GetExistLevel(string prefabName)
    {
        LevelConfig lc = null;
        for (int i = 0; i < existLevels.Count; )
        {
            if (existLevels[i] != null)
            {
                if (existLevels[i].name == prefabName) lc = existLevels[i];
                else existLevels[i].gameObject.SetActive(false);
            }
            else
            {
                existLevels.RemoveAt(i);
                continue;
            }
            i++;
        }

        return lc;
    }
}
