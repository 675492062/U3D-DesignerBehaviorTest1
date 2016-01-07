using UnityEngine;
using System.Collections;
using FightMessage;

public class SendChapterDgnHandler : MonoBehaviour {
	
	public void SendChapteredListReq(){
		MsgChapteredListReq msg = new MsgChapteredListReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_CHAPTERED_LIST , msg);
	}
	
	public void SendChapterBoxReq(int chapterId , int boxIndex){
		MsgChapteredBoxReq msg = new MsgChapteredBoxReq();
		msg.chaptered = chapterId;
		msg.box = boxIndex;
	}
}