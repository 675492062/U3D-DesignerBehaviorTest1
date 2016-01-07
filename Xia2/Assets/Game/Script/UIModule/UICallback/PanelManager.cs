using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {
//	public UIPanel register;
	public UIPanel Login;
//	public UIPanel defaultWindow;
	public UIPanel ServerList;
//	public UILabel lastestLoginServer;
    public UIPanel RegistPanel;
//    public UIPanel CreateRole;
//	public UIInput userName;
//	public UIInput passWord;
//    public UIPanel ErrorNotice;
    public GameObject NoticeWindow;
    public UIPanel LoingInfo;
    public UIButton FastLoginButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showLoingInfo()
    {
        if (LoingInfo)
        {
            LoingInfo.gameObject.SetActive(true);
            int fastSuccess = PlayerPrefs.GetInt("FASTSUCCESS", 0);
            if (fastSuccess == 1)
            {
                FastLoginButton.gameObject.SetActive(false);
            }
        }
    }

    public void hideLoginInfo()
    {
        if (LoingInfo)
        {
            LoingInfo.gameObject.SetActive(false);
        }
    }

//	public void showRegWindow()
//	{
//		if (register) {
//			register.gameObject.SetActive(true);		
//		}
//	}
//	public void hideRegWindow()
//	{
//		if (register) {
//			register.gameObject.SetActive(false);		
//		}
//	}

	public void showLoginWindow()
	{
		if (Login) 
		{
			Login.gameObject.SetActive(true);		
			InitDataCallback defaultData = Login.GetComponentInChildren<InitDataCallback>();
			if(defaultData != null)
			{
				defaultData.refresh();
			}
		}
	}
	public void hideLoginWindow()
	{
		if (Login) {
			Login.gameObject.SetActive(false);		
		}
	}

	public void showServerListWindow()
	{
		if (ServerList) {
			ServerList.gameObject.SetActive(true);		
		}
	}
	public void hideServerListWindow()
	{
		if (ServerList) {
			ServerList.gameObject.SetActive(false);		
		}
	}
//	public void showDefaultWindow ()
//	{
//		if (defaultWindow) {
//			defaultWindow.gameObject.SetActive(true);		
//		}
//	}
//	public void hideDefaultWindow ()
//	{
//		if (defaultWindow) {
//			defaultWindow.gameObject.SetActive(false);		
//		}
//	}
//	public void refreshServerHost()
//	{
//		if (Login.gameObject.activeSelf) 
//		{
//			serverInfo info = MonoInstancePool.getInstance<UserData>().getCurSelectedServer();
//			if(lastestLoginServer && info != null)
//			{
//				lastestLoginServer.text = info.serverHost + " : " + info.serverPort + " : " + info.serverStatus;
//				if(!string.IsNullOrEmpty(MonoInstancePool.getInstance<UserData>().userName))
//					userName.text = MonoInstancePool.getInstance<UserData>().userName;
//
//				if(!string.IsNullOrEmpty(MonoInstancePool.getInstance<UserData>().passWord))
//					passWord.text = MonoInstancePool.getInstance<UserData>().passWord;
//
//				MonoInstancePool.getInstance<NetWorkScript>().host = info.serverHost;
//				MonoInstancePool.getInstance<NetWorkScript>().port = System.Int32.Parse(info.serverPort);
//			}
//        }
//    }
    public void showRegistWindow()
    {
        if (RegistPanel)
        {
            RegistPanel.gameObject.SetActive(true);
        }
    }
    public void hideRegistWindow()
    {
        if (RegistPanel)
        {
            RegistPanel.gameObject.SetActive(false);
        }
    }
//    public void showCreateRoleWindow()
//    {
//        if (CreateRole)
//        {
//            CreateRole.gameObject.SetActive(true);
//        }
//    }
//    public void hideCreateRoleWindow()
//    {
//        if (CreateRole)
//        {
//            CreateRole.gameObject.SetActive(false);
//        }
//    }
//    public void showErrorWindow()
//    {
//        if (ErrorNotice)
//        {
//            ErrorNotice.gameObject.SetActive(true);
//        }
//    }

    public void showNoticeWindow()
    {
        if (NoticeWindow)
        {
            NoticeWindow.gameObject.SetActive(true);
        }
    }

    public void hideNoticeWindow()
    {
        if (NoticeWindow)
        {
            NoticeWindow.gameObject.SetActive(false);
        }
    }
}
