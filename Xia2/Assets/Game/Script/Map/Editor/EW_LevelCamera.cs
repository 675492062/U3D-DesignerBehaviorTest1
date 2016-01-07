/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-17   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class EW_LevelCamera : MapEditor
{

    const string NAME_PARENT = "LEVEL_CAMERA_PARENT";

    const string KEY_LCPDungeonIndex = "LCPDungeonIndex";
    const string KEY_LCPChapterIndex = "LCPChapterIndex";

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

    private List<LevelCamera> mExistLevels = new List<LevelCamera>();
    private List<LevelCamera> existLevels
    {
        get
        {
            if (goParent.transform.childCount != mExistLevels.Count)
            {
                mExistLevels.Clear();
                foreach (Transform t in goParent.transform)
                {
                    LevelCamera lc = t.GetComponent<LevelCamera>();
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

    private static Object targetPrefab;

    private static LevelCamera curCP;

    private bool hasRes = false;

    protected override void ShowLevelsSelect()
    {
        GUILayout.BeginHorizontal();

        int chapterIndex = EditorGUILayout.Popup(select.curChapterIndex, select.allChapterPopup.ToArray());

        if (select.curChapterIndex != chapterIndex)
        {
            select.curChapterIndex = chapterIndex;
            //curCP = null;
        }

        int dungeonIndex = EditorGUILayout.Popup(select.curDungeonIndex, select.allDungeonPopup.ToArray());

        if (select.curDungeonIndex != dungeonIndex)
        {
            select.ResetDungeon();
            select.curDungeonIndex = dungeonIndex;
            //curCP = null;
        }

        GUILayout.EndHorizontal();
    }

    protected override void ShowOverrideGUI()
    {
        ShowRes();

        EditorGUILayout.Space();

        if (curCP == null || !hasRes) return;

        curCP.waitTimeToPlay = EditorGUILayout.Slider("Camera Anim Wait Time", curCP.waitTimeToPlay, 0, 10);

        if (KMInspectorEditor.DrawHeader("Opening Anim"))

            ShowOPCameraPath();

        EditorGUILayout.Space();

        if (KMInspectorEditor.DrawHeader("Ending Anim"))

            ShowENCamerPath();

    }

    void ShowRes()
    {

        if (curCP == null)
        {
            curCP = GameObject.FindObjectOfType(typeof(LevelCamera)) as LevelCamera;
            //set value form  last 
            if (curCP)
            {
                select.curChapterIndex = EditorPrefs.GetInt(KEY_LCPChapterIndex, select.curChapterIndex);
                select.curDungeonIndex = EditorPrefs.GetInt(KEY_LCPDungeonIndex, select.curDungeonIndex);
                //Debug.Log(select.curChapterIndex + "-------------" + select.curDungeonIndex);
            }
        }

        GUILayout.BeginHorizontal();

        string resName = select.prbMapRes ? "Res:" : select.curDungeon.resname;
        GUILayout.Label(resName);

        hasRes = EditorGUILayout.ObjectField("", select.prbMapRes, typeof(Object), false);

        if (!hasRes)
        {
            GUILayout.Label("please import res of map before Edit!");
            return;
        }


        bool hasCameraPath = select.prbLevelCameraPath;

        if (!hasCameraPath)
        {
            if (select.prbModelLevelCamera && GUILayout.Button("Create Camera"))
            {
                CreatePrefab();
            }
        }
        else
        {
            GUILayout.Label("Camera Prefab:");
            EditorGUILayout.ObjectField("", select.prbLevelCameraPath, typeof(Object), false);

            if (curCP != null && curCP.name == select.prbLevelCameraPath.name)
            {
                //if (GUILayout.Button("Edit")) EditLevel();
            }
            if (GUILayout.Button("Show In Scene"))
                LoadLevelToScene();

            //, GUILayout.MinWidth(200f)
            if (GUILayout.Button("ReLoad Json", GUILayout.MaxWidth(100f)))
            {
                ReLoadJson();
            }
        }

        GUILayout.EndHorizontal();

        if (curCP == null) return;

        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Save"))
        {
            SaveLevel();
        }

        GUILayout.EndHorizontal();
    }

    void ShowOPCameraPath()
    {
        ShowCameraPath(curCP.open);
        if (GUILayout.Button("Add Opening Anim"))
        {
            curCP.AddOPAnim();
        }
    }

    void ShowENCamerPath()
    {
        ShowCameraPath(curCP.end);
        if (GUILayout.Button("Add Ending Anim"))
        {
            curCP.AddEDAnim();
        }
    }

    void ShowCameraPath(List<CameraPathBezierAnimator> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GUILayout.Space(3f);
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Step " + (i + 1) + " :" + list[i].name))
            {
                Selection.activeGameObject = list[i].gameObject;
            }
            if ((GUILayout.Button("Delete", GUILayout.MaxWidth(100))))
            {
                DestroyImmediate(list[i].gameObject);
                return;
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
        }
    }

    void CreatePrefab()
    {
        KMPrefabEditor.ClonePrefab(select.prbModelLevelCamera, select.GetNameByCurCamera());
    }

    void LoadLevelToScene()
    {
        if (curCP != null)
        {
            curCP.gameObject.SetActive(false);
        }

        LevelCamera lc = GetExistLevel(select.prbLevelCameraPath.name);
        if (lc != null)
        {
            lc.gameObject.SetActive(true);
            curCP = lc;
        }
        else
        {
            GameObject go = KMPrefabEditor.LoadPrefab(select.prbLevelCameraPath, null);
            go.transform.parent = goParent.transform;
            curCP = go.GetComponent<LevelCamera>();
        }

        if (curRes) DestroyImmediate(curRes.gameObject);
        curRes = KMPrefabEditor.LoadPrefab(select.prbMapRes, null);

        targetPrefab = select.prbLevelCameraPath;

        Selection.activeGameObject = curCP.gameObject;

        //save data form last load
        EditorPrefs.SetInt(KEY_LCPDungeonIndex, select.curDungeonIndex);
        EditorPrefs.SetInt(KEY_LCPChapterIndex, select.curChapterIndex);
    }

    void SaveLevel()
    {
        KMPrefabEditor.SavePrefab(curCP.gameObject, targetPrefab);
    }

    LevelCamera GetExistLevel(string prefabName)
    {
        LevelCamera lc = null;
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
