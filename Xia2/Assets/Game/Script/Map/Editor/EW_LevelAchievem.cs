using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 关卡战斗成就管理 编辑器
/// 
/// Maintaince Logs: 
/// 2014-12-17  WP      Initial version
/// </summary>
public class EW_LevelAchievem : MapEditor
{
    /// <summary>
    /// 场景物体名
    /// </summary>
    const string NAME_PARENT = "LEVEL_ACHIEVEMENT_PARENT";

    const string KEY_DungeonIndex = "ach_index_dungeon";
    const string KEY_ConfigIndex = "ach_index_config";
    const string KEY_ChapterIndex = "ach_index_chapter";

    private GameObject mParent;
    private GameObject goParent
    {
        get
        {
            if (mParent == null)
            {
                mParent = GameObject.Find(NAME_PARENT);

                if (mParent == null)
                {
                    mParent = new GameObject();
                    mParent.name = NAME_PARENT;
                }
            }
            return mParent;
        }
    }

    private List<LevelAchievemCtrl> mExistLevels = new List<LevelAchievemCtrl>();
    private List<LevelAchievemCtrl> existLevels
    {
        get
        {
            if (goParent.transform.childCount != mExistLevels.Count)
            {
                mExistLevels.Clear();
                foreach (Transform t in goParent.transform)
                {
                    LevelAchievemCtrl lc = t.GetComponent<LevelAchievemCtrl>();
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

    /// <summary>
    /// 路径
    /// </summary>
    const string PATH_Achievem = AllStrings.PATH_LEVEL_ACHIEVEMENT;

    /// <summary>
    /// 当前所选择的成就名字
    /// </summary>
    private string curAchievemName
    {
        get
        {
            return AllStrings.FILE_LEVEL_ACHIEVEMENT + select.GetConfigId();
        }
    }

    /// <summary>
    /// 模板Model
    /// </summary>
    private Object model
    {
        get
        {
            return Resources.Load(PATH_Achievem + AllStrings.FILE_LEVEL_ACHIEVEMENT + "Model");
        }
    }

    /// <summary>
    /// 当前选择的Table所对应的Prefab
    /// </summary>
    private Object prefab
    {
        get
        {
            return Resources.Load(PATH_Achievem + curAchievemName);
        }
    }

    /// <summary>
    /// 目标Prefab，加载成就到场景的时候赋值
    /// </summary>
    private static Object targetPrefab;

    /// <summary>
    /// 当前场景中的成就
    /// </summary>
    private static LevelAchievemCtrl curAchievement;

    //protected override void ShowLevelsSelect()
    //{
    //    GUILayout.BeginHorizontal();

    //    select.curChapterIndex = EditorGUILayout.Popup(select.curChapterIndex, select.allChapterPopup.ToArray());

    //    select.curDungeonIndex = EditorGUILayout.Popup(select.curDungeonIndex, select.allDungeonPopup.ToArray());

    //    select.curConfigIndex = EditorGUILayout.Popup(select.curConfigIndex, select.allTablePopup.ToArray());

    //    GUILayout.EndHorizontal();
    //}

    protected override void ShowOverrideGUI()
    {
        ShowRes();

        GUILayout.Space(20);
    }

    void ShowRes()
    {
        if (curAchievement == null)
        {
            curAchievement = GameObject.FindObjectOfType(typeof(LevelAchievemCtrl)) as LevelAchievemCtrl;
            //set value form  last 
            if (curAchievement)
            {
                select.curChapterIndex = EditorPrefs.GetInt(KEY_ChapterIndex, select.curChapterIndex);
                select.curDungeonIndex = EditorPrefs.GetInt(KEY_DungeonIndex, select.curDungeonIndex);
                select.curConfigIndex = EditorPrefs.GetInt(KEY_ConfigIndex, select.curConfigIndex);
            }
        }

        GUILayout.BeginHorizontal();

        string resName = prefab ? "Res:" : AllStrings.FILE_LEVEL_ACHIEVEMENT + select.GetConfigId();
        GUILayout.Label(resName);

        //是否有Prefab
        bool hasRes = EditorGUILayout.ObjectField("", prefab, typeof(Object), false);

        if (!hasRes)
        {
            if (GUILayout.Button("创建关卡成就"))
            {
                CreatePrefab();
            }
        }
        else
        {
            if (GUILayout.Button("显示关卡成就"))
            {
                LoadAchievemToScene();
            }
        }

        if (curAchievement != null && targetPrefab != null)
        {
            if (GUILayout.Button("保存当前关卡"))
            {
                SaveLevel();
            }
        }

        GUILayout.EndHorizontal();
    }

    void CreatePrefab()
    {
        KMPrefabEditor.ClonePrefab(model, AllStrings.FILE_LEVEL_ACHIEVEMENT + select.GetConfigId());
    }

    void LoadAchievemToScene()
    {
        if (curAchievement != null)
        {
            curAchievement.gameObject.SetActive(false);
        }

        LevelAchievemCtrl lc = GetExistLevel(curAchievemName);
        if (lc != null)
        {
            lc.gameObject.SetActive(true);
            curAchievement = lc;
        }
        else
        {
            GameObject go = KMPrefabEditor.LoadPrefab(prefab, null);
            go.transform.parent = goParent.transform;
            curAchievement = go.GetComponent<LevelAchievemCtrl>();
        }

        targetPrefab = prefab;

        Selection.activeGameObject = curAchievement.gameObject;

        //save data form last load
        EditorPrefs.SetInt(KEY_DungeonIndex, select.curDungeonIndex);
        EditorPrefs.SetInt(KEY_ChapterIndex, select.curChapterIndex);
        EditorPrefs.SetInt(KEY_ConfigIndex, select.curConfigIndex);
    }

    void SaveLevel()
    {
        KMPrefabEditor.SavePrefab(curAchievement.gameObject, targetPrefab);
    }

    LevelAchievemCtrl GetExistLevel(string prefabName)
    {
        LevelAchievemCtrl la = null;
        for (int i = 0; i < existLevels.Count; )
        {
            if (existLevels[i] != null)
            {
                if (existLevels[i].name == prefabName) la = existLevels[i];
                else existLevels[i].gameObject.SetActive(false);
            }
            else
            {
                existLevels.RemoveAt(i);
                continue;
            }
            i++;
        }

        return la;
    }
}
