using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TaskStruct {

	private Dictionary<int, TaskItem> taskDict = new Dictionary<int, TaskItem>();
	public Dictionary<int, TaskItem> GetDict(){ return taskDict;}
	public bool isDirty = false;

	/// <summary>
	/// 添加任务
	/// </summary>
	public void addTask(TaskItem task)
	{
		if(taskDict.ContainsKey(task.templateID))
		{
			Debug.LogError("already has this task!");
			return;
		}
		taskDict.Add(task.templateID, task);
	}
	/// <summary>
	/// 删除任务
	/// </summary>
	public void removeTask(int templateID)
	{
		if(!taskDict.ContainsKey(templateID))
		{
			Debug.LogError("have not this task!");
			return;
		}
		taskDict.Remove(templateID);
	}
	/// <summary>
	/// 判断是否接受了这个任务
	/// </summary>
	/// <returns>true:has, false: not</returns>
	public bool hasTask(int templateID)
	{
		return taskDict.ContainsKey(templateID);
	}
	/// <summary>
	/// 任务是否完成
	/// </summary>
	/// <returns>true: finish, false: not finish</returns>
	public bool finishTask(int templateID)
	{
		if(!taskDict.ContainsKey(templateID))
		{
			Debug.LogError("have not this task!");
			return false;
		}
		return taskDict[templateID].isFinish();
	}
	/// <summary>
	///通过类型获取任务
	/// </summary>
	/// <returns></returns>
	public TaskItem getTaskByType(int type)
	{
		for(int i = 0; i < taskDict.Count; i++)
		{
			TaskItem task = taskDict.ElementAt(i).Value;
			if(task.target_type == type)
			{
				return task;
			}
		}
		return null;
	}
	/// <summary>
	///是否有这个类型的任务
	/// </summary>
	/// <returns></returns>
	public bool hasType(int type)
	{
		for(int i = 0; i < taskDict.Count; i++)
		{
			TaskItem task = taskDict.ElementAt(i).Value;
			if(task.target_type == type)
			{
				return true;
			}
		}
		return false;
	}
	/// <summary>
	///通过模板id获取任务
	/// </summary>
	/// <returns></returns>
	public TaskItem getTaskByID(int templateID)
	{
		if(taskDict.ContainsKey(templateID))
		{
			return taskDict[templateID];
		}
		return null;
	}
	/// <summary>
	///通过模板id获取任务
	/// </summary>
	/// <returns></returns>
	public TaskItem getTaskByIdx(int idx)
	{
		if(idx < 0 || idx >= taskDict.Count)
		{
			Debug.LogError("have not this task! idx: " + idx);
			return null;
		}
		return taskDict.ElementAt(idx).Value;
	}
	/// <summary>
	/// 增加任务进度
	/// </summary>
	public void addTaskParam(int type, int param1, int param2)
	{
		TaskItem task = getTaskByType(type);
		if(null == task)
		{
			Debug.LogError("have not this task! type:  " + type);
			return;
		}

		switch(task.target_type)
		{
		case (int)GlobalDef.TaskTargetType.T_DGBREAKER:  //完成指定副本
			break;
		case (int)GlobalDef.TaskTargetType.T_HEROGOT:  //获得指定英雄
			int heroid = task.num_1;
			if(heroid == param1)
			{
				task.param1_value = param1;
				task.param2_value = param2;
				isDirty = true;
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



	}
	public int getNum()
	{
		return taskDict.Count;
	}
}
