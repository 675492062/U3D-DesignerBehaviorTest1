using UnityEngine;
using System.Collections;

public class ChangeManualSize : MonoBehaviour
{

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
//#if UNITY_EDITOR
//       
//#elif UNITY_ANDROID
////      #elif UNITY_EDITOR
////		UIRoot root = GetComponentInChildren<UIRoot>();
////		root.manualHeight = Screen.height;
//#else
//        Debug.Log("camera scale num: " + UICamera.mainCamera.orthographicSize);
//        UIRoot root = GetComponentInChildren<UIRoot>();
//        if (root != null)
//        {
//            int res = (int)((float)Screen.height / UICamera.mainCamera.orthographicSize);
//            root.manualHeight = res;
//        }
//#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
