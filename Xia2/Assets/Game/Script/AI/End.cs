using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
class End : BaseState
{
	public End(string name)
		: base(name)
	{
		
	}

	public override void OnAwake()
	{
		
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
		if(isDead())
		{
			return TaskStatus.Running;
		}
		return TaskStatus.Failure;
	}
}