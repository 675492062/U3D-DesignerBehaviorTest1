using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class Wait : BaseState 
{
	float waitTime = 1f;
	float tempTime = 0f;
	
	public Wait(string name)
		: base(name)
	{
			
	}
	public override void OnAwake()
	{

	}
	
	public override void OnStart()
	{
		initData ();

		int type = (int)m_unit.m_unitType;
		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr( m_unit.m_TemplateID, "idle");
			m_unit.m_animation [ani_name].speed = 0.15f;//speed_idle *(-0.5f);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr( m_unit.m_TemplateID, "idle");
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

		tempTime += Time.deltaTime;
		if(tempTime >= waitTime)
		{
			tempTime = 0;
			//切换到搜索状态
//			State search = fsm.GetState("search");
//			if(search != null)
//			{
//				fsm.SetCurState("search");
//			}
		}
		return TaskStatus.Running;
	}
}
