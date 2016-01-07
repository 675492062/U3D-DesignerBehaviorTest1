using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {

	private TaskStruct everyDayTask = new TaskStruct();  //每日任务
	private TaskStruct mainThreadTask = new TaskStruct();//主线任务

	public TaskStruct getEveryDayTask(){ return everyDayTask; }
	public TaskStruct getMainthreadTask(){ return mainThreadTask; }


	public TaskManager()
	{
//		addTempData();
	}
	public TaskStruct getTaskListByType(int type)
	{
		if(type == (int)GlobalDef.TaskType.T_ONECE)
		{
			return mainThreadTask;
		}
		else if(type == (int)GlobalDef.TaskType.T_EVERTYDAY)
		{
			return everyDayTask;
		}
		return null;
	}
	public void addTempData()
	{
		for(int i = 0; i < 5; i++)
		{
			TaskItem item = new TaskItem();
			item.templateID = 800001 + i;
			everyDayTask.addTask(item);
			
			TaskItem item1 = new TaskItem();
			item1.templateID = 800001 + i;
			mainThreadTask.addTask(item1);
		}

	}
	public void addTaskParam(int type, int param1, int param2 = 0)
	{
		if(everyDayTask.hasType(type))
		{
			everyDayTask.addTaskParam(type, param1, param2);
		}
		else if(mainThreadTask.hasType(type))
		{
			mainThreadTask.addTaskParam(type, param1, param2);
		}
	}
}
