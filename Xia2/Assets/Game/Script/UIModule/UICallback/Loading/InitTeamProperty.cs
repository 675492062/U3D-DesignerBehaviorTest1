using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InitTeamProperty : MonoBehaviour {
    public UILabel headID;
    public UILabel Name;
    public UILabel Level;
    public UILabel Exp;
	public UILabel propertys;
    public GameObject AnnouncementWindow;
    public UIPanel noticeListPanel;
    public GameObject Table;
	// Use this for initialization
	void Start () {
        //触发公告
        var httpMsg = (HttpMsgManager)FindObjectOfType(typeof(HttpMsgManager));
        if (httpMsg)
        {
            httpMsg.getNotice();
        }

        headID.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().headID);
        Name.text = MonoInstancePool.getInstance<UserData>().teamName;
        Level.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().level);
        Exp.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().exp);

		string show = "";
		show += "vip     : " + MonoInstancePool.getInstance<UserData>().vipLevel + "\n";
		show += "vipExp  : " + MonoInstancePool.getInstance<UserData>().vipExp + "\n";
		show += "fighting: " + MonoInstancePool.getInstance<UserData>().fighting + "\n";
		show += "gold    : " + MonoInstancePool.getInstance<UserData>().gold + "\n";
		show += "diamond : " + MonoInstancePool.getInstance<UserData>().diamond + "\n";
		show += "soul    : " + MonoInstancePool.getInstance<UserData>().soulPoint + "\n";
		show += "stamina : " + MonoInstancePool.getInstance<UserData>().stamina + "\n";
		show += "lastChageStaminaTime : " + MonoInstancePool.getInstance<UserData>().lastChageStaminaTime + "\n";
		show += "todayShopRefreshCount: " + MonoInstancePool.getInstance<UserData>().todayShopRefreshCount + "\n";
		propertys.text = show;


        //清除邮件对象
        foreach (GameObject obj in MonoInstancePool.getInstance<MailManager>().mailObject)
        {
            Destroy(obj);
        }
        MonoInstancePool.getInstance<MailManager>().mailObject.Clear();
        MonoInstancePool.getInstance<MailManager>().mailList.Clear();
        //获取邮件总数
        //SendMailSystemHander.getInstance().SendGetMailCount();
        //加载场景时，获取邮件列表
//		MonoInstancePool.getInstance<SendMailSystemHander>().SendGetMailList(MonoInstancePool.getInstance<MailManager>().currentPage);

        //发送获取好友总数请求
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendCount((int)GlobalDef.FriendType.FriendList);
        //获取申请好友总数
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendCount((int)GlobalDef.FriendType.InviteList);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void addInfo()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().getNotice())
        {
            Destroy(obj);
        }
        List<string> titles = new List<string>();
        List<string> texts = new List<string>();
        List<int> imageIds = new List<int>();
        List<noticeInfo> noticeList = MonoInstancePool.getInstance<UserData>().getNoticeList();
        foreach (noticeInfo notice in noticeList)
        {
            titles.Add(notice.title + "     " + notice.time);
            texts.Add(notice.notice);
            imageIds.Add(notice.image);
        }

        for (int i = 0; i < titles.Count; i++)
        {
            Load(titles[i], texts[i], "NGUI");
        }
    }

    void Load(string title, string text, string spritName)
    {
		GameObject instance = Instantiate(Resources.Load("Prefab/Announcement/Announcement", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = Table.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(instance.transform.position.x, instance.transform.position.y, 0);
        ClickQuestCallBack s = instance.GetComponent<ClickQuestCallBack>();
        s.Label.text = text;
        s.Sprite.name = spritName;
        s.Title.text = title;
        MonoInstancePool.getInstance<UserData>().setNotice(instance);
    }

    public void showListWindow()
    {
        if (noticeListPanel)
        {
            noticeListPanel.gameObject.SetActive(true);
        }
    }
    public void hideListWindow()
    {
        if (noticeListPanel)
        {
            noticeListPanel.gameObject.SetActive(false);
        }
    }
    
	public void refreshData()
	{
		headID.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().headID);
		Name.text = MonoInstancePool.getInstance<UserData>().teamName;
		Level.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().level);
		Exp.text = Convert.ToString(MonoInstancePool.getInstance<UserData>().exp);
		
		string show = "";
		show += "vip     : " + MonoInstancePool.getInstance<UserData>().vipLevel + "\n";
		show += "vipExp  : " + MonoInstancePool.getInstance<UserData>().vipExp + "\n";
		show += "fighting: " + MonoInstancePool.getInstance<UserData>().fighting + "\n";
		show += "gold    : " + MonoInstancePool.getInstance<UserData>().gold + "\n";
		show += "diamond : " + MonoInstancePool.getInstance<UserData>().diamond + "\n";
		show += "soul    : " + MonoInstancePool.getInstance<UserData>().soulPoint + "\n";
		show += "stamina : " + MonoInstancePool.getInstance<UserData>().stamina + "\n";
		show += "lastChageStaminaTime : " + MonoInstancePool.getInstance<UserData>().lastChageStaminaTime + "\n";
		show += "todayShopRefreshCount: " + MonoInstancePool.getInstance<UserData>().todayShopRefreshCount + "\n";
		propertys.text = show;
	}
}
