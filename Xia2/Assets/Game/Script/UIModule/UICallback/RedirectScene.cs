using UnityEngine;
using System.Collections;

public class RedirectScene : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if(string.Compare(Application.loadedLevelName, sceneName) == 0)
		{
			return;
		}
		//memery clear
		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();

		if(string.Compare(sceneName, "Game_NetNewScene") == 0)
		{
			MonoInstancePool.getInstance<UserData>().redirectSceneName = "Game_NetNewScene";
			Application.LoadLevel("LoadingBar");
		}
		else if(string.Compare(sceneName, "MainScene") == 0)
		{
			MonoInstancePool.getInstance<UserData>().redirectSceneName = "MainScene";
			Application.LoadLevel("LoadingBar");
		}
		else if(string.Compare(sceneName, "Game") == 0)
		{
			MonoInstancePool.getInstance<SendFightMsgHander>().SendEnterFightReq(1);
		}
		else 
		{
			MonoInstancePool.getInstance<UserData>().redirectSceneName = sceneName;
			Application.LoadLevel("LoadingBar");
		}
	}
}
