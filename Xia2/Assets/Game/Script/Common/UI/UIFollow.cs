using UnityEngine;
using System.Collections;

/// <summary>
/// UI 把对方的点转换成UI点
/// 
/// Maintaince Logs: 
/// 2014-12-08  WP      Initial version
/// </summary>
public class UIFollow : MonoBehaviour
{

    public Transform target;

    // Use this for initialization
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target && Camera.main)
        {
            Vector3 objPos = Camera.main.WorldToScreenPoint(target.transform.position);
            Vector3 gui = UICamera.currentCamera.ScreenToWorldPoint(objPos);

            gui.z = 0;

            transform.position = gui;
        }
    }

}
