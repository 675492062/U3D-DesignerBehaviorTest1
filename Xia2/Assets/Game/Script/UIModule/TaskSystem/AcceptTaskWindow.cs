using UnityEngine;
using System.Collections;

public class AcceptTaskWindow : MonoBehaviour 
{
	public int taskID{ get; set; }

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnClick()
	{
		MonoInstancePool.getInstance<SendTaskSysMessage>().sendAcceptTask(taskID);


		this.gameObject.SetActive(false);
		//发送进入战斗请求
		MonoInstancePool.getInstance<SendFightMsgHander>().SendEnterFightReq(1);
	}
}
