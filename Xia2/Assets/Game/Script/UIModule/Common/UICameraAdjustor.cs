using UnityEngine;
using System.Collections;

/// <summary>
/// 根据设备的宽高比，调整camera.orthographicSize. 以保证UI在不同分辨率(宽高比)下的自适应
/// 须与UIAnchor配合使用
/// 将该脚本添加到UICamera同一节点上
/// </summary>

[RequireComponent(typeof(UICamera))]
public class UICameraAdjustor : MonoBehaviour
{
    float standard_width = 960;
    float standard_height = 640;
    float device_width = 0f;
    float device_height = 0f;

    void Awake()
    {
        device_width = Screen.width;
        device_height = Screen.height;

#if UNITY_STANDALONE_WIN

#else
        SetCameraSize();
#endif
    }

    private void SetCameraSize()
    {
        float adjustor = 0f;
        float standard_aspect = standard_width / standard_height;
        float device_aspect = device_width / device_height;

        if (device_aspect < standard_aspect)
        {
            adjustor = standard_aspect / device_aspect;
            GetComponent<Camera>().orthographicSize = adjustor;
        }
        //		camera.orthographicSize = device_width/device_height;
//#if UNITY_ANDROID
////		//      #elif UNITY_EDITOR
////		//		UIRoot root = GetComponentInChildren<UIRoot>();
////		//		root.manualHeight = Screen.height;
//#else
//        Debug.Log("camera scale num: " + UICamera.mainCamera.orthographicSize);
//        UIRoot root = (UIRoot)FindObjectOfType(typeof(UIRoot));
//        if (root != null)
//        {
//            int res = (int)((float)Screen.height / UICamera.mainCamera.orthographicSize);
//            root.manualHeight = res;
//        }
//#endif
    }
}