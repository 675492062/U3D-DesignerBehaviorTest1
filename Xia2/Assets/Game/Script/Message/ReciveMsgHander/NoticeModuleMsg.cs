using UnityEngine;
using System.Collections;
using System;

public class NoticeModuleMsg : MonoBehaviour 
{
    void Start()
    {
    }

    void Update()
    {

    }
	public int parse(SocketModel module)
	{
		switch(module.messageID)
		{
		case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_CHAT:
			onChatMessage(module);
			break;
        case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_MAIL_LIST:
            onGetMailList(module);
            break;
        case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_MAIL_DELETE:
            onDeleteMail(module);
            break;
        case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_MAIL_NEW:
            onGetNewMail(module);
            break;
        case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_MAIL_COUNT:
            onGetMailCount(module);
            break;
		default:
			return -1;
		}
		return 0;
	}
	public void onChatMessage(SocketModel model)
	{
		NoticeMessage.MsgChatRep msg = MsgSerializer.Deserialize<NoticeMessage.MsgChatRep>(model);

        Chat chat = new Chat();
        chat.uid = msg.uid;
        chat.name = msg.name;
        chat.type = msg.type;
        chat.data = msg.data;
		chat.targetUid = msg.target;
		if (msg.item != null) {
			chat.goods.guid = msg.item.guid;
			//server changed, client not change
//			chat.goods.number = msg.item.number;	
		}
        chat.targetName = msg.tarname;
        ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
        if (chat.type == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
        {
            chatManager.setSystemChatList(chat);
			chatManager.setHaveNewSystemChat(true);
        }
        else if (chat.type == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
        {
            chatManager.setWorldChatList(chat);
			chatManager.setHaveNewWorldChat(true);
        }
        else if (chat.type == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
        {
            chatManager.setPrivateChatList(chat);
			chatManager.setHaveNewPrivateChat(true);
			//chatManager.setTargetId(chat.uid);
        }
        chatManager.setIsDirty(true);
	}

    public void onGetMailList(SocketModel model)
    {
        //FIX:
        //NoticeMessage.MsgMailListRep msg = MsgSerializer.Deserialize<NoticeMessage.MsgMailListRep>(model);
        //int count = msg.mailAry.Count;
        //Debug.Log("mail count : " + count);
        //for (int i = 0; i < count; i++)
        //{
        //    Mail mail = new Mail();
        //    mail.mailId = msg.mailAry[i].index;
        //    mail.from = msg.mailAry[i].from;
        //    mail.time = msg.mailAry[i].time;
        //    mail.mailTitle = msg.mailAry[i].title;
        //    mail.mailContent = msg.mailAry[i].body;
        //    mail.readed = msg.mailAry[i].reader;
            
        //    for (int j = 0; j < msg.mailAry[i].itemAry.Count; j++) 
        //    {
        //        Goods goods = new Goods();
        //        goods.guid = msg.mailAry[i].itemAry[j].guid;
        //        goods.templateId = msg.mailAry[i].itemAry[j].templateid;
        //        goods.number = msg.mailAry[i].itemAry[j].number;
        //        mail.itemAry.Add(goods);
        //    }
        //    MonoInstancePool.getInstance<MailManager>().mailList.Add(mail);
        //}
    }

    //删除邮件
    public void onDeleteMail(SocketModel model)
    {
		NoticeMessage.MsgMailDeleteRep msg = MsgSerializer.Deserialize<NoticeMessage.MsgMailDeleteRep>(model);
        long mailId = msg.index;
        bool del = msg.delete;
        MonoInstancePool.getInstance<MailManager>().deleteMailId = mailId;
        MonoInstancePool.getInstance<MailManager>().isDelete = del;
        
    }

    public void onGetNewMail(SocketModel model)
    {
        //FIX:
        //NoticeMessage.MsgMailNewRep msg = MsgSerializer.Deserialize<NoticeMessage.MsgMailNewRep>(model);
        //Mail mail = new Mail();
        //mail.mailId = msg.mail.index;
        //mail.from = msg.mail.from;
        //mail.time = msg.mail.time;
        //mail.mailTitle = msg.mail.title;
        //mail.mailContent = msg.mail.body;
        //mail.readed = msg.mail.reader;
        //int count = msg.mail.itemAry.Count;
        //for (int j = 0; j < count; j++)
        //{
        //    Goods goods = new Goods();
        //    goods.guid = msg.mail.itemAry[j].guid;
        //    goods.templateId = msg.mail.itemAry[j].templateid;
        //    goods.number = msg.mail.itemAry[j].number;
        //    mail.itemAry.Add(goods);
        //}
        //MonoInstancePool.getInstance<MailManager>().mailList.Add(mail);
    }

    public void onGetMailCount(SocketModel model)
    {
		NoticeMessage.MsgMailCountRep msg = MsgSerializer.Deserialize<NoticeMessage.MsgMailCountRep>(model);
        int count = msg.count;
        MonoInstancePool.getInstance<MailManager>().mailCount = count;
    }
}
