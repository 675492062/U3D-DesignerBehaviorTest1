using UnityEngine;
using System.Collections;
using FightMessage;

public class SendAreanHandler : MonoBehaviour {
	//获取竞技场信息
	public void SendAreanUserInfoReq(){
		int lvLimit = StaticGlobal_parameter.Instance().getInt(850048 , "parameter");
		if(lvLimit > MonoInstancePool.getInstance<UserData>().level){
			Debug.LogWarning("[the level of openning the arean is ] " + lvLimit);
			return;
		}
		MsgArenaInfoReq msg = new MsgArenaInfoReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_INFO , msg);
	}
	
	// 获取竞技场排行榜
	public void SendAreanRankListReq(){
		MsgArenaRanklistReq msg = new MsgArenaRanklistReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_RANKLIST , msg);
	}
	
	//获取排行榜用户信息
	public void SendAreanOtherUserInfoReq(int uid){
		MsgArenaOtherInfoReq msg = new MsgArenaOtherInfoReq();
		msg.uid = uid;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_OTHER_INFO , msg);
	}
	
	//购买挑战次数
	public void SendAreanBuyCountReq(){
		MsgArenaBuyCountReq msg = new MsgArenaBuyCountReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_BUY_COUNT , msg);
	}
}