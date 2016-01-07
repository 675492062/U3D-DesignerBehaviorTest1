using UnityEngine;
using System.Collections;
using System.IO;

public class SendTaskSysMessage : MonoBehaviour {

	//获取任务列表
	public void sendGetTaskList() 
	{
		TaskMessage.MsgGetTaskListReq msg = new TaskMessage.MsgGetTaskListReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_GET_TASK_LIST, msg);
	}
	//获取任务奖励
	public void sendGetReward(int taskID)
	{
		TaskMessage.MsgGetRewardReq msg = new TaskMessage.MsgGetRewardReq();
		msg.taskId = taskID;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_GET_REWARD, msg);
	}
	//初始化任务
	public void sendAcceptTask(int taskID)
	{
		TaskMessage.MsgInitTaskReq msg = new TaskMessage.MsgInitTaskReq();
		msg.taskId = taskID;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_INIT_TASK, msg);
	}
	//获取成就列表
	public void sendGetAchievementList()
	{
		TaskMessage.MsgGetAchievementListReq msg = new TaskMessage.MsgGetAchievementListReq();
		
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_GET_ACHIEVEMENT_LIST, msg);
	}
	//获取血魂信息
	public void sendGetSoulMessage(){
		TaskMessage.MsgGetBleedSoulReq msg = new TaskMessage.MsgGetBleedSoulReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_GET_BLEED_SOUL , msg);
	}
	//获取签到信息
	public void SendCheckInfo(){
		TaskMessage.MsgGetCheckInInfoReq msg = new TaskMessage.MsgGetCheckInInfoReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_GET_CHECKININFO , msg);
	}
	//签到
	public void SendCheckIn(){
		TaskMessage.MsgCheckInReq msg = new TaskMessage.MsgCheckInReq();
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)TaskMessage.TASK_MSG_ID.ID_C2S_CHECKIN , msg);
	}
}