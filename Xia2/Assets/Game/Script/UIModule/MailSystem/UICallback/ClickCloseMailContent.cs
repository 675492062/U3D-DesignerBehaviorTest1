using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickCloseMailContent : MonoBehaviour {
    public UISprite Sprite;
    public GameObject MailContentWindow;
    public GameObject Table;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        MonoInstancePool.getInstance<MailManager>().UIMailBackground.color = Color.gray;
        List<Mail> mailList = MonoInstancePool.getInstance<MailManager>().mailList;
        foreach (Mail mail in mailList)
        {
            if (mail.mailTitle == MonoInstancePool.getInstance<MailManager>().currentMail.mailTitle)
            {
                mail.readed = true;//标记为已读
            }
        }
        if (MailContentWindow.gameObject.activeSelf)
        {
            MailContentWindow.gameObject.SetActive(false);
        }
        else
        {
            MailContentWindow.gameObject.SetActive(true);
        }
        if (MonoInstancePool.getInstance<MailManager>().currentMail.itemAry.Count > 0)
        {
			MonoInstancePool.getInstance<SendMailSystemHander>().SendReadeMail(MonoInstancePool.getInstance<MailManager>().currentMail.mailId);
        }
        //是否有未读邮件
//         bool haveNoReadMail = false;
//         foreach (Mail mail2 in MonoInstancePool.getInstance<MailManager>().mailList)
//         {
//             if (!mail2.readed)
//             {
//                 haveNoReadMail = true;
//             }
//         }
//         MailUIManager mailUiManager = (MailUIManager)FindObjectOfType(typeof(MailUIManager));
//         if (!haveNoReadMail)
//         {
//             if (mailUiManager)
//             {
//                 mailUiManager.hideNew();
//             }
//         }
    }
}
