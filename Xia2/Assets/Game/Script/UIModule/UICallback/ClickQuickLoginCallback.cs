using UnityEngine;
using System.Collections;

public class ClickQuickLoginCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        string duid = SystemInfo.deviceUniqueIdentifier;
        var httpMsg = (HttpMsgManager)FindObjectOfType(typeof(HttpMsgManager));
        if (httpMsg)
        {
            httpMsg.quickLogin(duid);//执行注册协议

            //httpMsg.getServerList();
        }
    }
}
