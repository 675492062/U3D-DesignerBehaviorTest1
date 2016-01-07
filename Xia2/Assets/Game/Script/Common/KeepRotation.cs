using UnityEngine;
using System.Collections;

/// <summary>
/// 保持旋转
/// 
/// Maintaince Logs: 
/// 2014-12-08  WP      Initial version
/// </summary>
[ExecuteInEditMode]
public class KeepRotation : MonoBehaviour
{

    // Use this for initialization
    void Start() { }

    void Update()
    {
        if (transform.rotation != Quaternion.identity) transform.rotation = Quaternion.identity;
    }
}
