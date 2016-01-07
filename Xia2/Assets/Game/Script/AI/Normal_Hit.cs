using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class Normal_Hit : BaseState 
{
	public GameObject hitObj = null;
	public float waitTime = 1f;
	float tempWaitTime = 0;

	public Normal_Hit(string name)
		: base(name)
	{	
	}
	
	public override void OnAwake()
	{	
		if(null == hitObj)
		{
			return;
		}
	}
	
	public override void OnStart()
	{
		initData ();

	}
	
	public override void OnEnd()
	{
	}
	
	public override TaskStatus OnUpdate()
	{	
		if(null == gameObject || null == m_unit)
		{
			return TaskStatus.Failure;
		}
		if(isDead())
			return TaskStatus.Success;

		tempWaitTime += Time.deltaTime;
		if(tempWaitTime >= waitTime)
		{
			tempWaitTime = 0;
//			fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
			return TaskStatus.Success;
		}
		return TaskStatus.Success;
	}

}
