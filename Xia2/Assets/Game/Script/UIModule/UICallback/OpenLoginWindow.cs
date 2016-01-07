using UnityEngine;
using System.Collections;

public class OpenLoginWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		var panelmanager = (PanelManager)FindObjectOfType (typeof(PanelManager));
		panelmanager.showLoginWindow ();
//		panelmanager.hideDefaultWindow();
		MonoInstancePool.getInstance<UserData>().setConnectNetWork (true);
	}
}
