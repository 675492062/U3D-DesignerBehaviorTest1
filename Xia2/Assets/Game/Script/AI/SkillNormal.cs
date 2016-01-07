using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/AISkill")]
public class SkillNormal : SkillState {

	bool exit = false;
	public SkillNormal(string name)
		: base(name)
	{

	}

	/// <summary>
	/// First time to Update will trigger
	/// </summary>
	public override void OnAwake()
	{
		init ();
	}
	
	public override void OnStart()
	{
		initData ();
		SkillItem skill = m_unit.getCanUseSkill ();
		exit = checkConditional (skill, GlobalDef.SkillActionType.SKILL_ACT_NORMAL);
		if(exit)
			return;
		m_skillId = skill.templateID;
		EnterState (m_skillId);
		targetPos = transform.position;

		m_unit.m_bSkilling = true;

		//减蓝
		if(m_unit.m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			((Player)m_unit).OnMp(-1*skill.consume);
		}
		transform.LookAt (m_unit.target.transform);
	}
	
	public override void OnEnd()
	{
		m_unit.m_bSkilling = false;
	}
	
	public override TaskStatus OnUpdate()
	{
		if(m_unit.target == null || m_skillId <= 0)
		{
			return TaskStatus.Failure;
		}
		if (exit)
			return TaskStatus.Failure;
		if(isDead())
			return TaskStatus.Failure;

		m_delay += Time.deltaTime;
		float frame = ProcessAnimation ();
		if (frame == -1)
		{
			SkillItem item = m_unit.getUseSkillByTemplateID(m_skillId);
			if(item != null)
			{
				item.locked = false;
				item.resetCD();
			}
			return TaskStatus.Success;
		}
		
//		ProcessCasting ();
		PlayEffect (frame,targetPos);
		PlaySound (frame);

		return TaskStatus.Running;
	}
}
