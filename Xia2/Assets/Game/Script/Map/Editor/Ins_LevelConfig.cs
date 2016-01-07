using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// 检测值是否改变了，从而起到保存场景中的config
/// 
/// Maintaince Logs:
/// 2014-12-22  WP      Initial version. 
/// </summary>
[CustomEditor(typeof(LevelConfig))]
public class Ins_LevelConfig : Editor
{

    LevelConfig config;

    int actionCount = 0;
    void OnEnable()
    {
        config = (LevelConfig)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (actionCount != config.actions.Count)
        {
            actionCount = config.actions.Count;
            EditorUtility.SetDirty(config);
            //Debug.Log("------changed");
        }
    }
}
