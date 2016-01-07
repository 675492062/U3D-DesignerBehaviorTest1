using UnityEngine;
using System.Collections;

public class ClickServerButtonCallback : MonoBehaviour {
//    public UIPanel listWindow;
//    public UIPanel LoginInfo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
//        if(listWindow)
//        {
//        	listWindow.gameObject.SetActive(true);
//
//        }
//        if (LoginInfo)
//        {
//            LoginInfo.gameObject.SetActive(false);
//        }

		var manager = (UIManager)FindObjectOfType(typeof(UIManager));
		if (manager) 
		{
			manager.show("ServerList");
			manager.hide("LoginInfoUI");
		}

        var serverListWindow = (ServerListWindow)FindObjectOfType(typeof(ServerListWindow));
        if(serverListWindow)
        {
            serverListWindow.addInfo();
        }
    }
}
