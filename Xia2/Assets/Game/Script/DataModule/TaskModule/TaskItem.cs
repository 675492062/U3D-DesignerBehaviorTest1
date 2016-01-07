using UnityEngine;
using System.Collections;

public class TaskItem : BaseItem 
{
	public TaskItem()
	{
		param1_value = 0;
		param2_value = 0;
//		progress_value = 0;
//		progress_value = 0;
	}
	public int param1_value{get; set;}
	public int param2_value{get; set;}
//	public int progress_value{get; set;}
//	public int progress_value{get; set;}
	public void parseData(TaskMessage.Task data)
	{
		templateID = data.taskId;
		param1_value = data.param1_value;
		param2_value = data.param2_value;
	}
	public void refresh()
	{
		switch(target_type)
		{
		case (int)GlobalDef.TaskTargetType.T_DGBREAKER: // = 1,  //完成指定副本
			break;
		case (int)GlobalDef.TaskTargetType.T_HEROGOT: //   = 2,  //获得指定英雄
			break;
		case (int)GlobalDef.TaskTargetType.T_KILLER: //    = 6,  //杀死指定数量的怪物
			break;
		case (int)GlobalDef.TaskTargetType.T_LOOTER: //    = 7,  //进行指定数量的抽卡
			break;
		case (int)GlobalDef.TaskTargetType.T_OLBATTLELV: //= 9,  //完成指定的势力死斗关卡
			break;
		case (int)GlobalDef.TaskTargetType.T_GARDCOUNT: // = 11,  //完成守城的次无数
			break;
		case (int)GlobalDef.TaskTargetType.T_DUELIST: //   = 14,  //进行指定数量的竞技
			break;
		case (int)GlobalDef.TaskTargetType.T_GUILDCOUNT: //= 16,  //加入指定数量的公会
			break;
		case (int)GlobalDef.TaskTargetType.T_GUILDACT: //  = 17,  //进行指定数量的工会活动
			break;
		case (int)GlobalDef.TaskTargetType.T_ROBBER: //    = 18,  //抢夺指定数量矿藏
			break;
		case (int)GlobalDef.TaskTargetType.T_FASTROBBER: //= 19,  //进行指定数量的夺宝
			break;
		case (int)GlobalDef.TaskTargetType.T_LOGIN: //     = 20,  //登陆指定数量
			break;
		}
	}
	public bool isFinish()
	{
		switch(target_type)
		{
		case (int)GlobalDef.TaskTargetType.T_DGBREAKER:  //完成指定副本
			break;
		case (int)GlobalDef.TaskTargetType.T_HEROGOT:  //获得指定英雄
			if(param1_value == num_1 && param2_value >= num_2)
			{
				return true;
			}
			break;
		case (int)GlobalDef.TaskTargetType.T_KILLER:  //杀死指定数量的怪物
			break;
		case (int)GlobalDef.TaskTargetType.T_LOOTER:  //进行指定数量的抽卡
			break;
		case (int)GlobalDef.TaskTargetType.T_OLBATTLELV:  //完成指定的势力死斗关卡
			break;
		case (int)GlobalDef.TaskTargetType.T_GARDCOUNT:  //完成守城的次无数
			break;
		case (int)GlobalDef.TaskTargetType.T_DUELIST:  //进行指定数量的竞技
			break;
		case (int)GlobalDef.TaskTargetType.T_GUILDCOUNT:  //加入指定数量的公会
			break;
		case (int)GlobalDef.TaskTargetType.T_GUILDACT:  //进行指定数量的工会活动
			break;
		case (int)GlobalDef.TaskTargetType.T_ROBBER:  //抢夺指定数量矿藏
			break;
		case (int)GlobalDef.TaskTargetType.T_FASTROBBER:  //进行指定数量的夺宝
			break;
		case (int)GlobalDef.TaskTargetType.T_LOGIN:  //登陆指定数量
			break;
		}

		if(param1_value >= num_1 && 
		   param2_value >= num_2)
		{
			return true;
		}
		return false;
	}

	public string name{ get{ return StaticMission.Instance().getStr(templateID, "name"); }}
	public string decribe{ get{ return StaticMission.Instance().getStr(templateID, "decribe"); }}
	public int type{ get{ return StaticMission.Instance().getInt(templateID, "type"); }}
	public int unlock_type{ get{ return StaticMission.Instance().getInt(templateID, "unlock_type"); }}
	public int unlock_tar{ get{ return StaticMission.Instance().getInt(templateID, "unlock_tar"); }}
	public int target_type{ get{ return StaticMission.Instance().getInt(templateID, "target_type"); }}
	public int num_1{ get{ return StaticMission.Instance().getInt(templateID, "num_1"); }}
	public int num_2{ get{ return StaticMission.Instance().getInt(templateID, "num_2"); }}
	public int getAwardtypeByIdx(int idx)
	{
		return StaticMission.Instance().getInt(templateID, ("awardtype"+ (idx)));
	}
	public int getAwardidByIdx(int idx)
	{
		return StaticMission.Instance().getInt(templateID, ("awardid"+ (idx)));
	}
	public int getAwardCountByIdx(int idx)
	{
		return StaticMission.Instance().getInt(templateID, ("awardcount"+ (idx)));
	}
	public string begin_date{ get{ return StaticMission.Instance().getStr(templateID, "begin_date"); }}
	public string end_date{ get{ return StaticMission.Instance().getStr(templateID, "end_date"); }}

}
