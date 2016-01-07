using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Mail{
    public Mail() { }
    public long mailId = 0;              // 索引
    public int imageId = 0;             // 头像ID
    public string from = "";            // 发件人  
    public string time = "";            // 时间
    public string mailTitle = "";       // 标题
    public string mailContent = "";     // 正文
    public bool readed = false;         // 是否阅读
    public List<Goods> itemAry = new List<Goods>();          // 附件
}

public class MailManager : MonoBehaviour{
    
    public int mailCount = 0;

    public int currentPage = 1;

    //保存临时生成的邮件显示对象
    public List<GameObject> mailObject = new List<GameObject>();

    //邮件临时缓存
    public List<Mail> mailList = new List<Mail>();

    //新邮件缓存
    public List<Mail> newMailList = new List<Mail>();

    //邮件内容标签
    public UILabel UIMailId;
    public UILabel UIImageId;
    public UILabel UIMailTitle;
    public UILabel UIMailContent;
    public UILabel UIMailFrom;
    public UILabel UISaveStatus;
    public UILabel UIGoodsId;
    public UILabel UIGoodsNum;
    public GameObject MailWindow;
    public GameObject MailContentWindow;
    public GameObject Tabel;
    public GameObject DrawButton;  //领取按钮
    public GameObject OkButton;     //确认按钮
    public UISprite UIMailBackground;

    public GameObject NewMailCountWindow;
    public UILabel UINewMailCount;

    //附件承载对象
    public GameObject EnclosureWindow;

    //当前读取的邮件
    public Mail currentMail = null;
    public GameObject currentObject = null;

    public GameObject addMoreObject = null;

    //附件显示对象列表
    public List<GameObject> enclosureObject = new List<GameObject>();

    public long deleteMailId = 0;

    public bool isDelete = false;

    public void setCurrentMail(string mailName)
    {
        
        foreach (Mail mail in mailList)
        {
            if (mail.mailTitle == mailName)
            {
                this.currentMail = mail;
                
                if (mail.itemAry.Count <= 0)
                {
                    mail.readed = true;//标记为已读
                }
            }
        }
    }
}
