using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class RollingBack : BaseState {

	float waitTime = 1f;
	float tempWaitTime = 0f;
	public RollingBack(string name)
		: base(name)
	{
		
	}
	public override void OnAwake()
	{
	}

	public override void OnStart()
	{
		initData ();
		if(m_unit.m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			string aniName = ((Player)m_unit).rollingBack ();
			if(m_unit.m_animation.GetClip(aniName) != null)
			{
				float length = m_unit.m_animation[aniName].length;
				float speed = m_unit.m_animation[aniName].speed;
				waitTime = length / speed;
			}
		}
	}
	
	public override void OnEnd()
	{
	}
	
	public override TaskStatus OnUpdate()
	{
		if(isDead())
			return TaskStatus.Failure;

		tempWaitTime += Time.deltaTime;
		if(tempWaitTime >= waitTime)
		{
			tempWaitTime = 0;
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}
}
