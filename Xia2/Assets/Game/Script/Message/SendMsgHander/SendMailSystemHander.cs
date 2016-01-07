using UnityEngine;
using System.Collections;
using System.IO;

public class SendMailSystemHander : MonoBehaviour{

    //获取邮件总数
    public void SendGetMailCount()
    {
        NoticeMessage.MsgMailCountReq msg = new NoticeMessage.MsgMailCountReq();
       
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_MAIL_COUNT, msg);
    }

    //阅读邮件
    public void SendReadeMail(long index)
    {
        NoticeMessage.MsgMailReaderReq msg = new NoticeMessage.MsgMailReaderReq();
        msg.index = index;
        
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_MAIL_READER, msg);
    }

    //获取邮件列表
    public void SendGetMailList(int page)
    {
        NoticeMessage.MsgMailListReq msg = new NoticeMessage.MsgMailListReq();
        msg.page = page;
       
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_MAIL_LIST, msg);
    }
}
