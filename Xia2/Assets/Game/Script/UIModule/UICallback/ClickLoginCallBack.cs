using UnityEngine;
using System.Collections;

public class ClickLoginCallBack : MonoBehaviour {
	public UIInput input;
    public UIInput PasswordInput;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
        string text = input.value;
		if (string.IsNullOrEmpty (text)) 
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.NAMEISNULL);
			}
			return;		
		}
		string username = text;
        string password = PasswordInput.value;
		if (string.IsNullOrEmpty (password)) 
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.PASSWORDISNULL);
			}
			return;		
		}
		MonoInstancePool.getInstance<UserData>().userName = username;
        MonoInstancePool.getInstance<UserData>().passWord = password;
		var httpMsg = (HttpMsgManager)FindObjectOfType (typeof(HttpMsgManager));
		if (httpMsg) 
		{
            httpMsg.login(username, password);	
		}
	}
}
