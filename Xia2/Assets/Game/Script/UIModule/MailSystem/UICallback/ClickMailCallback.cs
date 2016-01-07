using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickMailCallback : MonoBehaviour {
    public UILabel Title;
    public UISprite Sprite;
    public UILabel From;
    public UILabel Time;
    public UISprite BackGround;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
		Debug.Log ("asdsadas------------------------------------------");
        MonoInstancePool.getInstance<MailManager>().UIMailBackground = BackGround;
        var manager = (MailMainUIManager)FindObjectOfType<MailMainUIManager>();
        manager.DestroyRewardObject();
        string mailName = Title.text;
        MonoInstancePool.getInstance<MailManager>().setCurrentMail(mailName);
        MonoInstancePool.getInstance<MailManager>().currentObject = this.gameObject;
        manager.showMailContentWindow();
        var rManager = (MailRewardUIManager)FindObjectOfType<MailRewardUIManager>();
        if (rManager)
        {
            rManager.showMailContent();
            rManager.showEnclosure();
            if (MonoInstancePool.getInstance<MailManager>().currentMail.itemAry.Count > 0)
            {

                rManager.showEnclosure();
            }
            else
            {
                BackGround.color = Color.gray;
				MonoInstancePool.getInstance<SendMailSystemHander>().SendReadeMail(MonoInstancePool.getInstance<MailManager>().currentMail.mailId);
            }
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
//         if (!haveNoReadMail)
//         {
//             if (mailUiManager)
//             {
//                 mailUiManager.hideNew();
//             } 
//         }
    }
}
