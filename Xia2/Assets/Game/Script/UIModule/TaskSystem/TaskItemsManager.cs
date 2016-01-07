using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskItemsManager : MonoBehaviour 
{
	public UISprite TaskItemUI;
	public UIScrollView parent;
	public int filterType; // 1 一次性任务; 2 日常任务
	public int H_Interval = 10; 
	public int H_GridHeight = 120;

	Dictionary<int, UIWidget> taskDict = new Dictionary<int, UIWidget>();

//	TaskStruct taskList = null;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		TaskStruct taskList = MonoInstancePool.getInstance<TaskManager>().getTaskListByType(filterType);
		if(taskList.isDirty)
		{
			taskList.isDirty = false;
			refreshTaskList();
		}
	}
	public void refreshTaskList()
	{
		TaskStruct taskList = MonoInstancePool.getInstance<TaskManager>().getTaskListByType(filterType);
		if(null == taskList)
		{
			return;
		}
		clear();
		int initNum = taskList.getNum();
		for(int i = 0; i < initNum; i++)
		{
			Vector3 pos = new Vector3 (-10,0,0);
			pos.y = i  * -1*H_GridHeight + -1*H_Interval*i - H_Interval;
			
			UIWidget instance = Instantiate(TaskItemUI) as UIWidget;
			instance.gameObject.SetActive(true);
			instance.transform.parent = parent.transform;
			instance.transform.localScale = Vector3.one;

			pos.y += parent.panel.height / 2 - instance.height/2;
			instance.transform.localPosition = pos;
			
			taskDict.Add (i, instance);

			//refres ui
			TaskItemInfoUI info = instance.GetComponentInChildren<TaskItemInfoUI>();
			TaskItem item = taskList.getTaskByIdx(i);
			info.refresh(item);
		}
	}
	public void clear()
	{
		foreach (Transform child in parent.transform)
		{
			Destroy(child.gameObject);
		}
		taskDict.Clear();
	}
}
