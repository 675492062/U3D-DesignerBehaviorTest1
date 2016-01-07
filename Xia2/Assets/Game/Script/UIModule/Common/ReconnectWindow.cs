using UnityEngine;
using System.Collections;

public class ReconnectWindow : MonoBehaviour {

	public ErrorWindow errorWindow;
	public bool timeOut = false;
	bool re = false;
	public bool reconnect{
		get
		{
			return re;
		}
		set 
		{
			re = value;
			if(re)
			{
				showErrorWindow("连接断开，点击重连");
			}
		}
	}
	// Use this for initialization
	void Start () 
	{
		reconnect = false;
	}
	
	// Update is called once per frame
	void Update () 
	{


	}
	public void hideErrorWindow()
	{
		if(errorWindow != null)
		{
			errorWindow.gameObject.SetActive(false);
		}
	}
	public void showErrorWindow(string error)
	{
		if(errorWindow != null)
		{
			errorWindow.gameObject.SetActive(true);
			errorWindow.setText(error);
		}
	}


	public void onClick()
	{
		hideErrorWindow ();
		MonoInstancePool.getInstance<NetWorkScript> ().close();//
		MonoInstancePool.getInstance<NetWorkScript> ().reConnect ();//

		//waiting
		UIManager manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if(manager != null)
		{
			manager.show("Processing");
		}
	}
}
