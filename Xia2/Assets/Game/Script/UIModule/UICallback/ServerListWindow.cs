using UnityEngine;
using System.Collections;
using LitJson;

//[System.inp
using System.Collections.Generic;
using System;


public class ServerListWindow : MonoBehaviour {

	public UIToggle []checkBoxes;
	public UIPanel serverListPanel;
    public GameObject SubPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addInfo()
	{
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().serverObject)
        {
            Destroy(obj);
        }
		List<serverInfo> list = MonoInstancePool.getInstance<UserData>().getServerList();
		for (int i = 0; i < list.Count; i++) 
		{
 			string serverName = list[i].serverName;
 			string serverHost = list[i].serverHost;
 			string serverPort = list[i].serverPort;
 			string serverStatus = list[i].serverStatus;
            string title = "";
            if (Convert.ToInt32(serverStatus) == (int)GlobalDef.ServerStatusType.SERVERTYPEGOOD)
            {
                title = (i + 1) + "区  " + serverName + "    良好";
            }
            else if (Convert.ToInt32(serverStatus) == (int)GlobalDef.ServerStatusType.SERVERTYPEHOT)
            {
                title = (i + 1) + "区  " + serverName + "    爆满";
            }
            else if (Convert.ToInt32(serverStatus) == (int)GlobalDef.ServerStatusType.SERVERTYPEMOTIFY)
            {
                title = (i + 1) + "区  " + serverName + "    维护中";
            }
            else
            {
                title = (i + 1) + "区  " + serverName;
            }
            //string title = i + "区  " + serverName + "    " + serverStatus;
            LoadServerList(title, i, serverStatus);
		}
	}

    void LoadServerList(string title, int index,string status)
    {
        GameObject instance = Instantiate(Resources.Load("Prefab/LoginSystem/Server", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = SubPanel.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(-200, 96 - (index * 80), 0);
        ClickServerCallback s = instance.GetComponent<ClickServerCallback>();
        s.Label.text = title;
        MonoInstancePool.getInstance<UserData>().serverObject.Add(instance);
    }

	public int getSelectedIdx()
	{
        checkBoxes = GetComponentsInChildren<UIToggle>();
		for(int i = 0; i < checkBoxes.Length; i++)
		{
			if(checkBoxes[i].isChecked)
			{
                PlayerPrefs.SetInt("currentServerId", i);
                PlayerPrefs.Save();
				return i;
			}
		}
		return 0;
	}
	public void showListWindow()
	{
		if(serverListPanel)
		{
			serverListPanel.gameObject.SetActive(true);
		}
	}
	public void hideListWindow()
	{
		if(serverListPanel)
		{
			serverListPanel.gameObject.SetActive(false);
		}
	}
}
