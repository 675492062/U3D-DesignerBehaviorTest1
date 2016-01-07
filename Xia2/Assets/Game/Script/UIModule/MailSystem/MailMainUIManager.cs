using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MailMainUIManager : MonoBehaviour {
    public GameObject Table;
    public GameObject MailContentWindow;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MonoInstancePool.getInstance<MailManager>().isDelete)
        {
            MonoInstancePool.getInstance<MailManager>().isDelete = false;
            deleteMail();
        }
	}

    public void deleteMail()
    {
        MonoInstancePool.getInstance<MailManager>().mailList.Remove(MonoInstancePool.getInstance<MailManager>().currentMail);
        MonoInstancePool.getInstance<MailManager>().mailObject.Remove(MonoInstancePool.getInstance<MailManager>().currentObject);
        Destroy(MonoInstancePool.getInstance<MailManager>().currentObject);
        for (int i = 0; i < MonoInstancePool.getInstance<MailManager>().mailObject.Count; i++)
        {
            MonoInstancePool.getInstance<MailManager>().mailObject[i].transform.localPosition = new Vector3(-182, 230 - (i * 108), 0);
        }
    }

    public void DestroyRewardObject()
    {
        foreach (GameObject enclosureObject in MonoInstancePool.getInstance<MailManager>().enclosureObject)
        {
            Destroy(enclosureObject);
        }
    }

    //显示邮件列表
    public void showMailList()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<MailManager>().mailObject)
        {
            Destroy(obj);
        }
        MonoInstancePool.getInstance<MailManager>().mailObject.Clear();
        List<Mail> mailList = MonoInstancePool.getInstance<MailManager>().mailList;
        int index = 0;//计算位置的索引
        foreach (Mail mail in mailList)
        {
            Load(mail.mailTitle, index, "NGUI", mail.from, mail.time, mail.readed);
            index++;
        }
        if (MonoInstancePool.getInstance<MailManager>().currentPage < MonoInstancePool.getInstance<MailManager>().mailCount)
        {
            Destroy(MonoInstancePool.getInstance<MailManager>().addMoreObject);
            loadAddMore(mailList.Count);
        }
    }

    void Load(string title, int index, string spritName, string from, string time, bool readed)
    {
        GameObject instance = Instantiate(Resources.Load("Prefab/MailSystem/Mail", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = Table.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(-182, 230 - (index * 108), 0);
        ClickMailCallback s = instance.GetComponent<ClickMailCallback>();
        s.Sprite.name = spritName;
        s.Title.text = title;
        s.From.text = "发件人：" + from;
        s.Time.text = time;
        if (readed)
        {
            s.BackGround.color = Color.gray;
        }
        MonoInstancePool.getInstance<MailManager>().mailObject.Add(instance.gameObject);
    }

    void loadAddMore(int index)
    {
        GameObject instance = Instantiate(Resources.Load("AddMore", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = Table.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(-182, 230 - (index * 108), 0);
        ClickAddMoreCallback s = instance.GetComponent<ClickAddMoreCallback>();
        s.Label.text = "点击加载更多";
        //s.Sprite.name = spritName;
        //s.Title.text = title;
        //s.From.text = "发件人：" + from;
        //s.Time.text = time;
        MonoInstancePool.getInstance<MailManager>().addMoreObject = instance;
        //MonoInstancePool.getInstance<MailManager>().mailObject.Add(instance.gameObject);
    }

    public void showMailContentWindow()
    {
        if (MailContentWindow)
        {
            MailContentWindow.gameObject.SetActive(true);
        }
    }

    
}
