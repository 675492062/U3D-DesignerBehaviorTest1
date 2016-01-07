using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class HttpMsgManager : MonoBehaviour {

//	private string httpHost = "http://211.152.2.68:30001";
	private string httpHost = "http://192.168.1.72:30000";

	private bool showErrorWindow = false;
	private string errorString = "";
	private string userName = "";
	private string password = "";

	private const int MSG_REGISTER = 10001;      //注册
	private const int MSG_LOGIN = 10002;         //登录
	private const int MSG_GETSERVERLIST = 10003; //获取服务器列表
	private const int MSG_TOKEN_AUTH = 10004;    //token验证
	private const int MSG_THIRD_PLATFORM = 10005;//第三方平台授权登录
    private const int MSG_GETNOTICE = 10006;     //公告
    private const int MSG_QUICKLOGIN = 10007;    //游客登录
    private const int MSG_LOGINNOTICE = 10008;   //游客登录
	// Use this for initialization
	void Start () 
	{	

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if (showErrorWindow) 
		{
			GUI.Window (0, new Rect (400, 250, 250, 170), DoMyWindow, "错误");
		}
	}
	void DoMyWindow (int windowID) 
	{
		GUI.skin.label.fontSize = 20;
		GUI.Label(new Rect (10, 20, 220, 200), errorString);
		if (GUI.Button (new Rect (75, 140, 100, 30), "确定")) 
		{
			showErrorWindow = false;
		}

	}
	//注册
	public void register(string username, string password, string mail)
	{
		//注册请求 POST
		Dictionary<string,string> dic = new Dictionary<string, string> ();
		dic.Add("account",username);
		dic.Add("password",password);
        dic.Add("email", mail);
		this.userName = username;
		this.password = password;
		dic.Add ("msgId", MSG_REGISTER.ToString());
		
		StartCoroutine(POST(httpHost + "/regist",dic));
	}
	//Login
	public void login(string username, string password)
	{
		//注册请求 POST
		Dictionary<string,string> dic = new Dictionary<string, string> ();
		dic.Add("account",username);
		dic.Add("password",password);
		dic.Add ("msgId", MSG_LOGIN.ToString());
		
		StartCoroutine(POST(httpHost + "/login",dic));
	}

    public void quickLogin(string duid)
    {
        //快速注册 POST
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("device", duid);
        dic.Add("msgId", MSG_QUICKLOGIN.ToString());

        StartCoroutine(POST(httpHost + "/guest", dic));
    }
	//申请获取服务器列表
	public void getServerList()
	{
		//注册请求 POST
		Dictionary<string,string> dic = new Dictionary<string, string> ();
		dic.Add ("msgId", MSG_GETSERVERLIST.ToString());
		StartCoroutine(POST(httpHost + "/getServerList",dic));
	}
    public void getNotice()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("msgId", MSG_GETNOTICE.ToString());
        StartCoroutine(POST(httpHost + "/notice", dic));
    }
    public void getLoginNotice()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("msgId", MSG_LOGINNOTICE.ToString());
        StartCoroutine(POST(httpHost + "/loginNotice", dic));
    }
	//POST请求
	IEnumerator POST(string url, Dictionary<string,string> post)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string,string> post_arg in post)
		{
			form.AddField(post_arg.Key, post_arg.Value);
		}
		
		WWW www = new WWW(url, form);
		yield return www;
		
		if (www.error != null)
		{
			//POST请求失败
			Debug.Log("error is :"+ www.error);
			errorString = www.error;
			showErrorWindow = true;
			
		} else
		{
			JSONNode data = JSON.Parse(www.text);
			int querySuccess = System.Int32.Parse(data["querySuccess"].ToString());
			int code = System.Int32.Parse(data["code"].ToString());
            if (querySuccess > 0) //successs
			{
				int id = System.Int32.Parse(data["msgId"].ToString());
                var manager = (UIManager)FindObjectOfType(typeof(UIManager));
                
				switch(id)
				{
				case MSG_REGISTER:
					MonoInstancePool.getInstance<UserData>().userName = userName;
					MonoInstancePool.getInstance<UserData>().passWord = password;
					login(MonoInstancePool.getInstance<UserData>().userName, MonoInstancePool.getInstance<UserData>().passWord);
					break;
				case MSG_LOGIN:
                    PlayerPrefs.SetString("username", MonoInstancePool.getInstance<UserData>().userName);
                    PlayerPrefs.SetString("password", MonoInstancePool.getInstance<UserData>().passWord);
                    PlayerPrefs.Save();
					MonoInstancePool.getInstance<UserData>().token = data["token"].ToString(); 
					bool first = System.Boolean.Parse(data["first"].ToString()); 
                    if (first)
                    {
                        getLoginNotice();
                        getServerList();
                    }
                    else
                    {
                        getServerList();
                    }
                    
                    
					break;
				case MSG_GETSERVERLIST:
					JSONArray arr = data["serverInfoArray"].AsArray;
					if(arr != null)
					{
						MonoInstancePool.getInstance<UserData>().addServerListData(arr);
					}
                    if (manager)
                    {
						manager.hide("RegistPanel");// hideRegistWindow();
						manager.hide("Login"); //hideLoginWindow();
						manager.hide("ServerList"); //hideServerListWindow();
						manager.show("LoginInfoUI"); //showLoingInfo();
                    }
                    var loginInfoManager = (LoginSystemUIManager)FindObjectOfType(typeof(LoginSystemUIManager));
                    if (loginInfoManager)
                    {
                        loginInfoManager.setAccount(MonoInstancePool.getInstance<UserData>().userName);
                        loginInfoManager.setServer();
                    }
					break;
                case MSG_GETNOTICE:
					JSONArray notices = data["notices"].AsArray;
                    if (notices.Count > 0)
                    {
                        MonoInstancePool.getInstance<UserData>().addNoticeListData(notices);

                        var noticeListWindow = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
                        if (noticeListWindow)
                        {
                            noticeListWindow.showListWindow();
                        }
                    }
                    break;
                case MSG_QUICKLOGIN:
					bool first2 = System.Boolean.Parse(data["first"].ToString());
                    PlayerPrefs.SetInt("FASTSUCCESS", 1);
                    PlayerPrefs.Save();
					MonoInstancePool.getInstance<UserData>().userName = data["account"].ToString() ;
					MonoInstancePool.getInstance<UserData>().passWord = data["password"].ToString();
					PlayerPrefs.SetString("username", data["account"].ToString());
					PlayerPrefs.SetString("password", data["password"].ToString());
                    PlayerPrefs.Save();
					MonoInstancePool.getInstance<UserData>().token = data["token"].ToString();
                    if (first2)
                    {
                        getLoginNotice();
                        getServerList();
                    }
                    else
                    {
                        getServerList();
                    }
                    break;
                case MSG_LOGINNOTICE:  
					JSONArray loginNotices = data["notices"].AsArray;
                    if (loginNotices.Count > 0)
                    {
                        //获取公告
                        if (manager)
                        {
							manager.hide("RegistPanel");
							manager.hide("Login"); 
							manager.hide("ServerList"); 
							manager.show("Announcement"); 
                        }
                        MonoInstancePool.getInstance<UserData>().addNoticeListData(loginNotices);

                        var initNoticeCallback = (InitNoticeCallback)FindObjectOfType(typeof(InitNoticeCallback));
                        if (initNoticeCallback)
                        {
                            initNoticeCallback.addInfo();
                        }
                    }
                    break;
				case MSG_TOKEN_AUTH:	
					break;
				case MSG_THIRD_PLATFORM:
					break;
				}
			}
			else 
			{
                errorParse(code);
                //errorParse(code);
			}
		}
	}
	void errorParse(int code)
	{
		
		string err_str = StaticError.Instance().getStr(code,"text");
		if(string.Compare(err_str, "-1") == 0)
		{
			err_str = "" + code;
		}
		ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
		if(err != null)
		{
			err.showErrorWindow();
			err.setErrorText(err_str);
		}
	}

}
