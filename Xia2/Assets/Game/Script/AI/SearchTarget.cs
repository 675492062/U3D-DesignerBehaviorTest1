using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class SearchTarget : BaseState 
{
	float eyeRange = 1f;  //视野范围
	float eyeAngle = 0.3f;//视野角度
	int type;             //单位类型
	public string targetTag;//目标标记

	public SearchTarget(string name)
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
		eyeRange = data.eyedis;
		eyeAngle = data.eyeangle;

		type = (int)m_unit.m_unitType; //单位类型
		string ani_name = "";         //动作名称
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "search");
			m_unit.m_animation[ani_name].speed = 0.34f;
			m_unit.m_animation.CrossFade(ani_name);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "search");
			((Player)m_unit).setAnimation(ani_name);
		}
	}
	
	public override void OnEnd()
	{
	}

//	int count = 0;
//	float time = 0;
	public override TaskStatus OnUpdate()
	{
		if(isDead())
			return TaskStatus.Success;

		if(isHiting())
			return TaskStatus.Success;

		if(m_unit.target == null)
		{
			Transform targetObj = GameObject.FindWithTag(targetTag).transform;
			if(targetObj != null)
			{
				m_unit.target = targetObj;
			}
		}
		if(m_unit.target != null)
		{
			setDir();  //设置朝向
			return TaskStatus.Success;
		}

		return TaskStatus.Running;
	}
}
