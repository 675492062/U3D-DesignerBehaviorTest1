/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-09   WP      Initial version
 * 2014-10-11   WP      Added Methons
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;

public class MapEditor : EditorWindow
{
    private const string NAME_SCENE = "Assets/Scene/MapEditor";

    private SelectDatas mSelect;
    protected SelectDatas select
    {
        get
        {
            if (mSelect == null)
            {
                mSelect = new SelectDatas();
                mSelect.curChapterIndex = 0;
            }
            return mSelect;
        }
    }

    private static GameObject mCurRes;
    protected GameObject curRes
    {
        get
        {
            if (mCurRes == null)
            {
                LevelSetting res = GameObject.FindObjectOfType(typeof(LevelSetting)) as LevelSetting;
                if (res)
                    mCurRes = res.gameObject;
            }
            return mCurRes;
        }
        set
        {
            mCurRes = value;
        }
    }

    protected void ReLoadJson()
    {
        StaticMonster.Instance().readData();
        StaticDungeon.Instance().readData();
        StaticChapter.Instance().readData();
        mSelect = new SelectDatas();
        mSelect.curChapterIndex = 0;
    }

    void OnGUI()
    {
        if (!EditorApplication.currentScene.Contains(NAME_SCENE))
        {
            GUILayout.Label("the scene isn't MapEditor , please open MapEditor and Edit !!  current scene is:" + EditorApplication.currentScene);
           
             GUILayout.Space(3f);

             GUILayout.Label("Path form  " + NAME_SCENE + "XXXXXXXXX");

            return;
        }

        KMInspectorEditor.DrawSeparator();

        GUILayout.Space(3f);
        ShowLevelsSelect();

        KMInspectorEditor.DrawSeparator();

        EditorGUILayout.Space();
        KMInspectorEditor.BeginContents();

        ShowOverrideGUI();

        KMInspectorEditor.EndContents();

        GUILayout.Space(3f);
    }

    protected virtual void ShowLevelsSelect()
    {
        GUILayout.BeginHorizontal();

        int chapterIndex = EditorGUILayout.Popup(select.curChapterIndex, select.allChapterPopup.ToArray());

        if (select.curChapterIndex != chapterIndex)
        {
            select.curChapterIndex = chapterIndex;
        }

        int dungeonIndex = EditorGUILayout.Popup(select.curDungeonIndex, select.allDungeonPopup.ToArray());

        if (select.curDungeonIndex != dungeonIndex)
        {
            select.curDungeonIndex = dungeonIndex;
        }

        int configIndex = EditorGUILayout.Popup(select.curConfigIndex, select.allTablePopup.ToArray());

        if (configIndex != select.curConfigIndex)
        {
            select.curConfigIndex = configIndex;
        }

        GUILayout.EndHorizontal();
    }

    protected virtual void ShowOverrideGUI()
    {

    }


}
