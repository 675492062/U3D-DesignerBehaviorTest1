using UnityEngine;
using System.Collections;

public class MailUIManager : MonoBehaviour {
    public GameObject MailWindow;
    public GameObject Table;
    public GameObject MailContentWindow;
    public UILabel UIMailTitle;
    public UILabel UIMailContent;
    public UILabel UIMailFrom;
    public GameObject DrawButton;
    public GameObject OKButton;
    public GameObject NewMailCountWindow;
    public UILabel UINewMailCount;
    public GameObject EnclosureWindow;

	// Use this for initialization
	void Start () {
        initWindow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    //显示邮件列表
    public void showMailList() 
    {
        int index = 0;//计算位置的索引
        foreach (Mail mail in MonoInstancePool.getInstance<MailManager>().mailList)
        {
            Load(mail.mailTitle, index, "NGUI", mail.from, mail.time, mail.readed);
            index++;
        }
    }

    //显示邮件内容
    public void showMailContent() 
    {
        Mail currentMail = MonoInstancePool.getInstance<MailManager>().currentMail;
        MonoInstancePool.getInstance<MailManager>().UIMailTitle.text = currentMail.mailTitle;
        MonoInstancePool.getInstance<MailManager>().UIMailContent.text = currentMail.mailContent;
        MonoInstancePool.getInstance<MailManager>().UIMailFrom.text = currentMail.from;
        if (currentMail.itemAry.Count > 0)
        {
            MonoInstancePool.getInstance<MailManager>().OkButton.gameObject.SetActive(false);
            MonoInstancePool.getInstance<MailManager>().DrawButton.gameObject.SetActive(true);
        }
        else
        {
            MonoInstancePool.getInstance<MailManager>().OkButton.gameObject.SetActive(true);
            MonoInstancePool.getInstance<MailManager>().DrawButton.gameObject.SetActive(false);
        }
    }

    public void showNew()
    {
        if (!NewMailCountWindow.gameObject.activeSelf)
        {
            NewMailCountWindow.gameObject.SetActive(true);
        }
    }

    public void hideNew()
    {
        if (NewMailCountWindow.gameObject.activeSelf)
        {
            NewMailCountWindow.gameObject.SetActive(false);
        }
    }

    //加载附件
    public void showEnclosure() 
    {
        for (int i = 0; i < MonoInstancePool.getInstance<MailManager>().currentMail.itemAry.Count; i++)
        {
            loadEnclosure("X" + MonoInstancePool.getInstance<MailManager>().currentMail.itemAry[i].number, i, "Flag-FR");
        }
    }

    void loadEnclosure(string title, int index, string spritName) 
    {
        GameObject instance = Instantiate(Resources.Load("MailReward", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = MonoInstancePool.getInstance<MailManager>().EnclosureWindow.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(120 + (index * 70), 0, 0);
        ClickMailRewardCallback s = instance.GetComponent<ClickMailRewardCallback>();
        s.Sprite.name = spritName;
        s.UIMailRewardContent.text = title;
        MonoInstancePool.getInstance<MailManager>().enclosureObject.Add(instance);
    }

    void Load(string title, int index, string spritName, string from, string time, bool readed)
    {
        GameObject instance = Instantiate(Resources.Load("Mail", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        //instance.gameObject.name = "Mail" + index;
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

    void initWindow()
    {
        MonoInstancePool.getInstance<MailManager>().MailWindow = MailWindow;
        MonoInstancePool.getInstance<MailManager>().MailContentWindow = MailContentWindow;
        MonoInstancePool.getInstance<MailManager>().Tabel = Table;
        MonoInstancePool.getInstance<MailManager>().UIMailContent = UIMailContent;
        MonoInstancePool.getInstance<MailManager>().UIMailTitle = UIMailTitle;
        MonoInstancePool.getInstance<MailManager>().DrawButton = DrawButton;
        MonoInstancePool.getInstance<MailManager>().OkButton = OKButton;
        MonoInstancePool.getInstance<MailManager>().NewMailCountWindow = NewMailCountWindow;
        MonoInstancePool.getInstance<MailManager>().UINewMailCount = UINewMailCount;
        MonoInstancePool.getInstance<MailManager>().UIMailFrom = UIMailFrom;
        MonoInstancePool.getInstance<MailManager>().EnclosureWindow = EnclosureWindow;
    }
}
