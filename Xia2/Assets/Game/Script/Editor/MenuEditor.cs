/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-09   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;

public class MenuEditor
{
    private const string PATH_SCENE = "Assets/Scene/";
    private const string NAME_GAME = PATH_SCENE + "Game.unity";
    private const string NAME_MENU = PATH_SCENE + "Menu.unity";
    private const string NAME_WP_SCENE = PATH_SCENE + "UI_WP.unity";
    private const string NAME_MAP_EDITOR_DEBUG = PATH_SCENE + "MapEditor_Debug.unity";

    [MenuItem("WLSS/Level Config Editor")]
    public static void OpenMapEditor()
    {
        EditorWindow.GetWindow<EW_LevelConfig>(false, "Level Config", true).Show();
    }

    [MenuItem("WLSS/Level Camera Editor")]
    public static void OpenCameraPath()
    {
        EditorWindow.GetWindow<EW_LevelCamera>(false, "Level Camera", true).Show();
    }

    [MenuItem("WLSS/Level Achievement")]
    public static void OpenLevelAchievement()
    {
        EditorWindow.GetWindow<EW_LevelAchievem>(false, "Level Achievement", true).Show();
    }

    [MenuItem("WLSS/Go to WPScene", false)]
    public static void OpenWPScene()
    {
        EditorApplication.OpenScene(NAME_WP_SCENE);
    }

    [MenuItem("WLSS/Go to Game", false)]
    public static void OpenGameScene()
    {
        EditorApplication.OpenScene(NAME_GAME);
    }

    [MenuItem("WLSS/Go to Menu", false)]
    public static void OpenMenuScene()
    {
        EditorApplication.OpenScene(NAME_MENU);
    }

    [MenuItem("WLSS/Go to MapEditor_Debug", false)]
    public static void OpenMapDebug()
    {
        EditorApplication.OpenScene(NAME_MAP_EDITOR_DEBUG);
    }
}
