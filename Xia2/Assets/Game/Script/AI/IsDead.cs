using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
public class IsDead : Conditional {

	public override void OnAwake()
	{
		
	}
	public override void OnStart()
	{

	}

	public override void OnEnd()
	{
	}

	public override TaskStatus OnUpdate()
	{
		Unit unit = gameObject.GetComponentInChildren<Unit> ();
		if(unit != null && unit.m_isDead == true)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
