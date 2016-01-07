using UnityEngine;
using System.Collections;

public class ClickLoginGameServerCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
		int idx = 0;
		if(PlayerPrefs.HasKey("currentServerId"))
		{
			idx = PlayerPrefs.GetInt("currentServerId");
		}
        MonoInstancePool.getInstance<UserData>().setServerIdx(idx);
        var manager = (PanelManager)FindObjectOfType(typeof(PanelManager));
        if (manager)
        {
            manager.hideLoginInfo();
        }

        //选择完服务器后，登录游戏服务器
        MonoInstancePool.getInstance<UserData>().setConnectNetWork(true);
        MonoInstancePool.getInstance<NetWorkScript>().init();
		MonoInstancePool.getInstance<SendMessageHander>().SendLoginMsg(MonoInstancePool.getInstance<UserData>().token);
    }

}
