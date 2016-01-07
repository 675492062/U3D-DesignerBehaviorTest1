using UnityEngine;
using System.Collections;

public class TaskModuleMsg : MonoBehaviour {

	public int parse(SocketModel module)
	{
		switch (module.messageID) 
		{
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_GET_TASK_LIST:          //= 80002; // 获取任务列表
			onGetTaskList(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_ADD_NEW_TASK:           //= 80003; // 增加新任务
			onAddTask(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_GET_REWARD:             //= 80005; // 获取奖励
			onGetTaskRework(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_GET_ACHIEVEMENT_LIST:   //= 80102; // 获取成就列表
			onGetAchievementList(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_UPDATE_ACHIEVEMENT:	//= 80103; // 更新成就进度
			onUpdateAchievement(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_FINISH_ACHIEVEMENT: 	//= 80104; // 成就达成 
			onFinishAchievement(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_ADD_NEW_ACHIEVEMENT:	//= 80105; // 添加新成就
			onAddAchievement(module);
			break;
		case (int)TaskMessage.TASK_MSG_ID.ID_S2C_GET_BLEED_SOUL:		//= 80202; // 获取血魂信息
			onGetBloodsoul(module);
			break;
		default:
			return -1;
		}
		return 0;
	}
	public void onGetTaskList(SocketModel module)
	{
		TaskMessage.MsgGetTaskListRep msg = MsgSerializer.Deserialize<TaskMessage.MsgGetTaskListRep>(module);
		for(int i = 0; i < msg.mainTaskList.Count; i++)
		{
			TaskItem item = new TaskItem();
			TaskMessage.Task data = msg.mainTaskList[i];
			item.parseData(data);
//			Debug.Log("---------------id: " + msg.mainTaskList[i].param1_value + " " + msg.mainTaskList[i].param2_value + " " + item.param1_value + " " + item.param2_value);
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().addTask(item);
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().isDirty = true;
		}
		for(int i = 0; i < msg.dailyTaskList.Count; i++)
		{
			TaskItem item = new TaskItem();
			TaskMessage.Task data = msg.mainTaskList[i];
			item.parseData(data);
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().addTask(item);
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().isDirty = true;
		}



	}
	public void onAddTask(SocketModel module)
	{
		TaskMessage.MsgAddNewTaskRep msg = MsgSerializer.Deserialize<TaskMessage.MsgAddNewTaskRep>(module);
	
		int templateID = msg.task.taskId;
		int type = StaticMission.Instance().getInt(templateID, "type");

		TaskItem item = new TaskItem();
		item.parseData(msg.task);
		if(type == (int)GlobalDef.TaskType.T_ONECE)
		{
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().addTask(item);
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().isDirty = true;
		}
		else if(type == (int)GlobalDef.TaskType.T_EVERTYDAY)
		{
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().addTask(item);
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().isDirty = true;
		}
	}
	public void onGetTaskRework(SocketModel module)
	{
		TaskMessage.MsgGetRewardRep msg = MsgSerializer.Deserialize<TaskMessage.MsgGetRewardRep>(module);

		//删除任务 播放完成任务的特效 
		int templateID = msg.taskId;
		int type = StaticMission.Instance().getInt(templateID, "type");
		if(type == (int)GlobalDef.TaskType.T_ONECE)
		{
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().removeTask(templateID);
			MonoInstancePool.getInstance<TaskManager>().getMainthreadTask().isDirty = true;
		}
		else if(type == (int)GlobalDef.TaskType.T_EVERTYDAY)
		{
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().removeTask(templateID);
			MonoInstancePool.getInstance<TaskManager>().getEveryDayTask().isDirty = true;
		}

	}

	// achievement and bloodsoul
	public void onGetAchievementList(SocketModel module)
	{
		TaskMessage.MsgGetAchievementListRep msg = MsgSerializer.Deserialize<TaskMessage.MsgGetAchievementListRep>(module);

		int i = 0;
		MonoInstancePool.getInstance<BloodSoulManager>().clearCurAchievementList();
		for (i = 0; i < msg.achieveList.Count; i++) {
			MonoInstancePool.getInstance<BloodSoulManager>().updateAchievement(msg.achieveList[i].achId, msg.achieveList[i].param1_value);
		}

		MonoInstancePool.getInstance<BloodSoulManager>().clearFinishedAchievement();
		for (i = 0; i < msg.finishList.Count; i++) {
			MonoInstancePool.getInstance<BloodSoulManager>().finishAchievement(msg.finishList[i]);
		}
	}
	
	public void onUpdateAchievement(SocketModel module)
	{
		TaskMessage.MsgUpdateAchieveRep msg = MsgSerializer.Deserialize<TaskMessage.MsgUpdateAchieveRep>(module);
		MonoInstancePool.getInstance<BloodSoulManager>().updateAchievement(msg.achieve.achId, msg.achieve.param1_value);
	}

	public void onFinishAchievement(SocketModel module)
	{
		// 用于表示完成一个成就
		TaskMessage.MsgFinishAchievementRep msg = MsgSerializer.Deserialize<TaskMessage.MsgFinishAchievementRep>(module);
		MonoInstancePool.getInstance<BloodSoulManager>().finishAchievement(msg.achId);
	}
	
	public void onAddAchievement(SocketModel module)
	{
		TaskMessage.MsgUpdateAchieveRep msg = MsgSerializer.Deserialize<TaskMessage.MsgUpdateAchieveRep>(module);
		MonoInstancePool.getInstance<BloodSoulManager>().updateAchievement(msg.achieve.achId, msg.achieve.param1_value);
	}
	
	public void onGetBloodsoul(SocketModel module)
	{
		TaskMessage.MsgGetBleedSoulRep msg = MsgSerializer.Deserialize<TaskMessage.MsgGetBleedSoulRep>(module);
		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		mng.recordBloodSoulInfo(msg.bleedsoul.bleedsoulId, msg.bleedsoul.progess);
		mng.extraHp = msg.hp;
		mng.extraAttack = msg.attack;
		mng.extraArmor = msg.armor;
		mng.extraCriticalLvl = msg.criticallv;
		mng.extraHitLvl = msg.hitlv;
		mng.extraDodgeLvl = msg.dodgelv;
		mng.extraTenacityLvl = msg.tenacitylv;
	}

}
