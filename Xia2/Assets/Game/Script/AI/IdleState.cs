using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
class IdleState : BaseState
{
	public float  waitTime = 1f;
	float  tempTime = 0f;
	public IdleState(string name)
		: base(name)
	{
		
	}

	public override void OnAwake()
	{

	}
	public override void OnStart()
	{
		initData ();

		AI_Data data = m_unit.getAIData ();
		waitTime = data.idle_time;

		int type = (int)m_unit.m_unitType;
		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "idle");
			m_unit.m_animation[ani_name].speed = 0.3f;//speed_idle *(-0.5f);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "idle");
		}
	
		m_unit.m_animation.Stop ();
		m_unit.m_animation.CrossFade(ani_name);
	}
	
	public override void OnEnd()
	{

	}

	public override TaskStatus OnUpdate()
	{
		if(isDead())
			return TaskStatus.Success;
		if(isHiting())
			return TaskStatus.Success;

		setDir ();	//设置方向
		tempTime += Time.deltaTime;
		if(tempTime >= waitTime)
		{
			tempTime = 0;
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}
}