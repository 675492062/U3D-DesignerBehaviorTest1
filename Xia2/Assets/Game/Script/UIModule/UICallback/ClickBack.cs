using UnityEngine;
using System.Collections;

public class ClickBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
		chatManager.reset ();
		Application.LoadLevel("Menu");
		MonoInstancePool.getInstance<NetWorkScript>().close ();
	}
}
