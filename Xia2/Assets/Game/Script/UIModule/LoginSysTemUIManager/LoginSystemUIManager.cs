using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoginSystemUIManager : MonoBehaviour {
    public UILabel Account;
    public UILabel Server;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setAccount(string account)
    {
        Account.text = account;
    }

    public void setServer()
    {
        List<serverInfo> serverList = MonoInstancePool.getInstance<UserData>().getServerList();
        serverInfo serverInfo = null;
        if (serverList.Count > 0)
        {
			if(PlayerPrefs.HasKey("currentServerId"))
			{
            	serverInfo = serverList[PlayerPrefs.GetInt("currentServerId", serverList.Count - 1)];
				Server.text = serverInfo.serverName;
			}
			else 
			{
				Server.text = "未选择";
			}
            
        }
        
        
        
    }
}
