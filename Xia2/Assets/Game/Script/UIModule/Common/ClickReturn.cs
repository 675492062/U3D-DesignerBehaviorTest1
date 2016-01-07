using UnityEngine;
using System.Collections;

public class ClickReturn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		var manager = (UIManager)FindObjectOfType(typeof(UIManager));
		if(manager)
		{
//			manager.hideRegistWindow();
//			manager.hideServerListWindow();
//          manager.hideLoginInfo();
//			manager.showLoginWindow();
			manager.hide("RegistPanel");
			manager.hide("ServerList");
			manager.hide("LoginInfoUI");
			manager.show("Login");
		}
	}
}
