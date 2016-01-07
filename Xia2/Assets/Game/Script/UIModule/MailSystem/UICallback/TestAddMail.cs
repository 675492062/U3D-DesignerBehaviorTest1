using UnityEngine;
using System.Collections;

public class TestAddMail : MonoBehaviour {
    public GameObject NewMailCountWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        /**
        NewMailCountWindow = MonoInstancePool.getInstance<MailManager>().NewMailCountWindow;
        for (int i = 5; i < 10; i++)
        {
            Mail mail = new Mail();
            mail.mailId = i;
            mail.imageId = i;
            mail.mailTitle = "邮件" + i;
            mail.mailContent = "你好邮件系统你好邮件系统你好邮件系统你好邮件系统你好邮件系统你好邮件系统你好邮件系统你好邮件系统你好邮件系统";
            if (i == 2 || i == 4)
            {
                mail.saveStatus = true;
            }
            else
            {
                mail.saveStatus = false;
            }
            if (i < 3)
            {
                mail.goodsIds = "";
            }
            else
            {
                mail.goodsIds = i + "," + i+1 + "," + i+2;
            }

            mail.goodsNum = 10;
            MonoInstancePool.getInstance<MailManager>().mailList.Add(mail);
            MonoInstancePool.getInstance<MailManager>().newMailList.Add(mail);
        }
        **/
        if (MonoInstancePool.getInstance<MailManager>().newMailList.Count > 0)
        {
            if (!NewMailCountWindow.gameObject.activeSelf)
            {
                NewMailCountWindow.gameObject.SetActive(true);
            }
        }
    }
}
