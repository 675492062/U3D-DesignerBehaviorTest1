using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;
using ProtoBuf.Meta;

public class SendMessageHander : MonoBehaviour{
    public void SendLoginMsg(string token)
    {

        LoginMessage.MsgLoginReq msg = new LoginMessage.MsgLoginReq();
        msg.token = token;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)LoginMessage.LOGIN_MSG_ID.ID_C2S_LOGIN, msg);		
    }
	public void SendReconnectMsg(string token)
	{
		LoginMessage.MsgReconnectReq msg = new LoginMessage.MsgReconnectReq();
		msg.token = token;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)LoginMessage.LOGIN_MSG_ID.ID_C2S_RECONNECT, msg);		
	}
    public void SendChatRequest(int type, string content, int uid, ulong goodsId)
	{
		NoticeMessage.MsgChatReq msg = new NoticeMessage.MsgChatReq();
		msg.type = type;
		msg.data = content;
        msg.target = uid;
		if (goodsId > 0) {
			msg.item = (long)goodsId;		
		}
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_CHAT, msg);		
	}

    public void SendCreateTeamRequest(int headID, string name)
    {
        DataMessage.MsgPlayerCreateReq msg = new DataMessage.MsgPlayerCreateReq();
        //msg.headID = headID;
        msg.name = name;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_CREATE, msg);
    }

	public void SendCreatePlayerRequest(int imageId, string name)
	{
		DataMessage.MsgPlayerCreateReq msg = new DataMessage.MsgPlayerCreateReq();
        msg.image = imageId;
        msg.name = name;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_CREATE, msg);
	}

    public void SendPlayerSelectHeroRequest(int heroId)
    {
        DataMessage.MsgPlayerSelectHeroReq msg = new DataMessage.MsgPlayerSelectHeroReq();
        msg.heroid = heroId;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_SELECT_HERO, msg);
    }

	public void SendCreateGMRequest(int number,string content, long itemID = 0)
	{
		NoticeMessage.MsgGMCommandReq msgGm = new NoticeMessage.MsgGMCommandReq ();
		msgGm.id = itemID;
		msgGm.number = number;
		msgGm.key = content;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_GM_COMMAND,msgGm);
	}          
	//	心跳检测 message 
	public void SendHeartBeat()
	{
		NoticeMessage.MsgHeartbeatReq msg = new NoticeMessage.MsgHeartbeatReq ();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)NoticeMessage.NOTICE_MSG_ID.ID_C2S_HEARTBEAT,msg);
	}
}
