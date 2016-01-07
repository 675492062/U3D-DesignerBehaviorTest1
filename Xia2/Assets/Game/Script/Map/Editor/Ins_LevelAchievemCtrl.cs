using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// LevelAchievemCtrl 的Inspector
/// 
/// Maintaince Logs:
/// 2014-12-22  WP      Initial version. 
/// </summary>
[CustomEditor(typeof(LevelAchievemCtrl))]
public class Ins_LevelAchievemCtrl : Editor
{

    LevelAchievemCtrl script;

    void OnEnable()
    {
        script = (LevelAchievemCtrl)target;
    }

    public override void OnInspectorGUI()
    {
        LevelAchievem achievem;

        for (int i = 0; i < script.achieves.Length; i++)
        {
            EditorGUILayout.BeginVertical("Box");
            GUILayout.BeginHorizontal();

            achievem = script.achieves[i];

            achievem.id = WlssEditor.PopupAchievements(achievem.id);

            if (achievem.paramsCount > 0)
            {
                achievem.param1 = WlssEditor.ShowValueByAchieveType(achievem.parameterType1, achievem.param1);
            }
            if (achievem.paramsCount > 1)
            {
                achievem.param2 = WlssEditor.ShowValueByAchieveType(achievem.parameterType2, achievem.param2);
            }
            if (achievem.paramsCount > 2)
            {
                achievem.param3 = WlssEditor.ShowValueByAchieveType(achievem.parameterType3, achievem.param3);
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("UI中成就描述：" + achievem.descForMenu);
            GUILayout.Label("战斗中成就描述：" + achievem.descForGame);
            GUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            GUILayout.Space(10);
        }

        if (GUI.changed)
        {
            //Debug.Log("--------changed");
            EditorUtility.SetDirty(script);
        }
    }
}
