/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-17   WP      Initial version
 * 
 * *****************************************************************************/

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Tools/变换/Keeping Transform(Editor)")]
public class KeepTransform : MonoBehaviour
{
    public bool keepPosition = true;
    public bool keepRotation = true;
    public bool keepLocalScale = false;

    void Update()
    {
        if (keepPosition && transform.position != Vector3.zero) transform.position = Vector3.zero;
        if (keepRotation && transform.rotation != Quaternion.identity) transform.rotation = Quaternion.identity;
        if (keepLocalScale && transform.localScale != Vector3.one) transform.localScale = Vector3.one;
    }
}

#endif
