using UnityEngine;
using System.Collections;

public class ErrorParse : MonoBehaviour {

	public UIPanel errorWindow;
	public bool exit = false;
	public bool timeOut = false;
	public bool relogin = false;
	ErrorWindow window;
	// Use this for initialization
	void Start () 
	{
		ErrorWindow window = errorWindow.GetComponentInChildren<ErrorWindow>();
		exit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(exit == true && errorWindow.gameObject.activeSelf == false)
		{
			exit = false;
			showErrorWindow("连接断开! 请重新登录!");
		}
	}
	public void showErrorWindow()
	{
		if(errorWindow != null)
		{
			errorWindow.gameObject.SetActive(true);
		}
	}
	public void showErrorWindow(string error)
	{
		if(errorWindow != null)
		{
			errorWindow.gameObject.SetActive(true);
			setErrorText(error);
		}
	}
	public void hideErrorWindow()
	{
		if(errorWindow != null)
		{
			errorWindow.gameObject.SetActive(false);
		}
	}
	public void setErrorText(string text)
	{
		if(errorWindow.gameObject.activeSelf)
		{
			if(window == null)
			{
				window = errorWindow.GetComponentInChildren<ErrorWindow>();
			}
			window.setText(text);
		}
	}
	public void onClick()
	{
		if(exit || timeOut)
		{
			Application.Quit();
		}
		if(relogin)
		{
			relogin = false;
			SceneCtrl.ToLogin();
		}
		hideErrorWindow ();
	}
	void OnDestroy()
	{
//		MonoInstancePool.destroy ();
	}
	public void showByErrorID(int errorID)
	{
		string err_str = StaticError.Instance().getStr(errorID,"text");
		ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
		if(err != null)
		{
			err.showErrorWindow();
			err.setErrorText(err_str);
		}
	}
}
