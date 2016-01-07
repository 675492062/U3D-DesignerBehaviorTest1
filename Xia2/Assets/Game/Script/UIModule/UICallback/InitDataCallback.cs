using UnityEngine;
using System.Collections;

public class InitDataCallback : MonoBehaviour {
    public UIInput username;
    public UIInput password;
    public UIPanel LoginWindow;
	// Use this for initialization
    void Start()
    {
		refresh();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public void refresh()
	{
		string name = PlayerPrefs.GetString("username", "");
		string pwd = PlayerPrefs.GetString("password", "");
		username.value = name;
		password.value = pwd;
	}
	public void login()
	{
		if (string.Compare(username.value, "") != 0 && string.Compare(password.value, "") != 0)
		{
			//LoginWindow.gameObject.SetActive(false);
			var httpMsg = (HttpMsgManager)FindObjectOfType(typeof(HttpMsgManager));
			if (httpMsg)
			{
				MonoInstancePool.getInstance<UserData>().userName = username.value;
				MonoInstancePool.getInstance<UserData>().passWord = password.value;
				httpMsg.login(username.value, password.value);
			}
		}
	}

}
