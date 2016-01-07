using UnityEngine;
using System.Collections;

public class SelectedServerHost : MonoBehaviour {

// 	public string sceneName = "Game_NetNewScene";
//    public string sceneName = "Game_CreateTeam";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		var listWindow = (ServerListWindow)FindObjectOfType (typeof(ServerListWindow));
		int idx = 0;
		if (listWindow) 
		{
			idx = listWindow.getSelectedIdx();	
			MonoInstancePool.getInstance<UserData>().setServerIdx(idx);
		}

		var manager = (UIManager)FindObjectOfType(typeof(UIManager));
		if (manager) 
		{
			manager.hide("ServerList");// hideServerListWindow();
			manager.hide("Login");     // hideLoginWindow();
//			manager.refreshServerHost();
		}

        //选择完服务器后，登录游戏服务器
        MonoInstancePool.getInstance<UserData>().setConnectNetWork(true);
		MonoInstancePool.getInstance<NetWorkScript>().init ();
		MonoInstancePool.getInstance<SendMessageHander>().SendLoginMsg (MonoInstancePool.getInstance<UserData>().token);
	}
}
