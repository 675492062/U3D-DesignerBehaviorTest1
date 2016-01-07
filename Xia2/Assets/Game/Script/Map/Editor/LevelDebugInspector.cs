using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// LevelFlowDebug 的Inspector类
/// 
/// Maintaince Logs:
/// 2014-12-03  WP      Initial version. 
/// </summary>
//[CustomEditor(typeof(LevelFlowDebug))]
//public class LevelDebugInspector : Editor
//{
//    public bool expandPrefabs = true;

//    public override void OnInspectorGUI()
//    {
//        var script = (LevelFlowDebug)target;

//        EditorGUI.indentLevel = 0;
//        PGEditorUtils.LookLikeControls();

//        this.expandPrefabs = PGEditorUtils.SerializedObjFoldOutList<LevelFlowDebug.HeroDebugData>
//                            (
//                                "Per-Prefab Pool Options",
//                                script.heroDatas,
//                                this.expandPrefabs,
//                                ref script._editorListItemStates,
//                                true
//                            );

//        // Flag Unity to save the changes to to the prefab to disk
//        if (GUI.changed)
//            EditorUtility.SetDirty(target);
//    }

//}
