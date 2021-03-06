using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("出生状态，一般作为行为树的第一个状态")]
[TaskCategory("AI")]
public class Born : BaseState 
{
    public Born(string name)
		: base(name)
	{
		
	}

	public override void OnAwake()
	{
		
	}

	public override void OnStart()
	{
		initData ();
		int type = (int)m_unit.m_unitType; //单位类型
		string ani_name = "";              //动作名称

		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "idle");
			m_unit.m_animation[ani_name].speed = 0.34f;
			m_unit.m_animation.CrossFade(ani_name);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "idle");
			m_unit.m_animation[ani_name].speed = 0.34f;
			((Player)m_unit).setAnimation(ani_name);
		}
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

		m_unit.target = null;
		m_bornPos = transform.position;
		return TaskStatus.Success;
	}
}
