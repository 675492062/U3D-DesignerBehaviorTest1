using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/AISkill")]
public class SkillWheel : SkillState {

	bool exit = false;
	public SkillWheel(string name)
		: base(name)
	{
		
	}
	
	public override void OnAwake()
	{
		init ();
	}
	
	public override void OnStart()
	{
		initData ();

		SkillItem skill = m_unit.getCanUseSkill ();
		exit = checkConditional (skill,GlobalDef.SkillActionType.SKILL_ACT_WHEEL);
		if(exit)
			return;

		m_skillId = skill.templateID;
		EnterState (m_skillId);

		transform.LookAt (m_unit.target.transform);
		setDir (); //设置方向
		targetPos = m_unit.m_transform.position;

		m_unit.m_bSkilling = true;
		//减蓝
		if(m_unit.m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			((Player)m_unit).OnMp(-1*skill.consume);
		}
	}
	
	public override void OnEnd()
	{
		m_unit.m_bSkilling = false;
	}
	
	public override TaskStatus OnUpdate()
	{
		if (gameObject == null || m_unit == null || m_unit.target == null)
			return TaskStatus.Failure;
		if(exit)
			return TaskStatus.Failure;
		if(isDead())
			return TaskStatus.Success;

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
		
		if (!ProcessCasting ()) {
			if( frame >= m_param )
			{
//				((MyPlayer)m_unit).m_curStat = 222;
				float speed = (float)m_unit.getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
				m_unit.m_transform.position += m_unit.m_directionVector * Time.deltaTime*speed;
			}
			else
			{
				float speed = (float)m_unit.getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
				m_unit.m_transform.position += m_unit.m_directionVector * Time.deltaTime*speed;
			}
		}
		
		PlayEffect (frame,targetPos);
		PlaySound (frame);
		return TaskStatus.Running;
	}
}