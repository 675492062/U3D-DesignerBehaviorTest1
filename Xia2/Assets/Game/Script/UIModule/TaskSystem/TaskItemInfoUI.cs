using UnityEngine;
using System.Collections;

public class TaskItemInfoUI : MonoBehaviour {
	public UILabel TaskName;
	public UILabel TaskDes;
	public UILabel []AwardNum;
	public UISprite Title;
	public UISprite Finish;

	public int templateID{get; set;}
	public int type{get; set;}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void refresh(TaskItem item)
	{	
		templateID = item.templateID;
		type = item.type;

		TaskName.text = item.name;
		TaskDes.text = item.decribe;

		if(type == (int)GlobalDef.TaskType.T_ONECE)
		{
			Title.spriteName = "08";
		}
		else if(type == (int)GlobalDef.TaskType.T_EVERTYDAY)
		{
			Title.spriteName = "07";
		}
//		if(item.isFinish())
//		{
//			Finish.gameObject.SetActive(true);
//		}
//		else 
//		{
//			Finish.gameObject.SetActive(false);
//		}
	}
	public void OnClick()
	{
		TaskStruct taskList = MonoInstancePool.getInstance<TaskManager>().getTaskListByType(type);
		if(taskList == null)
		{
			return;
		}
		TaskItem item = taskList.getTaskByID(templateID);
		if(null == item)
		{
			return;
		}
//		if(item.isFinish())
//		{
//			//send msg
//			MonoInstancePool.getInstance<SendTaskSysMessage>().sendGetReward(templateID);
//		}
//		else 
//		{
//			Debug.Log("not finish " + templateID);
//		}
	}
}
