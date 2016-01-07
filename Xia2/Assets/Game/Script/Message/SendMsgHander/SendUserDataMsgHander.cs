using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;
using ProtoBuf.Meta;
using DataMessage;

public class SendUserDataMsgHander : MonoBehaviour{

	public void SendGetPlayerBaseReq()
	{
		MsgPlayerBaseReq msg = new MsgPlayerBaseReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_BASE, msg);	
	}
    public void SendGetMatchParamReq()
    {
		MsgHeroPropertyReq msg = new MsgHeroPropertyReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_PROPERTY, msg);		
    }
    
    public void SendBuyStaminaReq(){
    	MsgPlayerBuyStaminaReq msg = new MsgPlayerBuyStaminaReq();
    	MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_BUY_STAMINA , msg);
    }
    
    public void SendBuyGoldReq(){
    	MsgPlayerBuyGoldReq msg = new MsgPlayerBuyGoldReq();
    	MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_PLAYER_BUY_GOLD , msg);
    }
  }