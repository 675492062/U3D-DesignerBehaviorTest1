using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
public class IsSkilling : Conditional {

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
		if(unit != null && unit.m_bSkilling == true)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
