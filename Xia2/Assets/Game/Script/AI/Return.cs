using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class Return : BaseState 
{
	bool exit = false;
	public Return(string name)
		: base(name)
	{
		
	}
	public override void OnAwake()
	{
		
	}
	
	public override void OnStart()
	{
		initData ();
		m_unit.m_animation.Stop ();

		int type = (int)m_unit.m_unitType;
		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "move");
			m_unit.m_animation [ani_name].speed = 0.34f;	//speed_idle *(-0.5f);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "move");
		}	
		m_unit.m_animation.Stop ();
		m_unit.m_animation.CrossFade(ani_name);

		exit = checkConditional ();
	}
	
	public override void OnEnd()
	{
	}
	public override TaskStatus OnUpdate()
	{	
		if (exit)
			return TaskStatus.Failure;
		if(isDead())
			return TaskStatus.Success;
		if(isHiting())
			return TaskStatus.Success;

		//setDir ();   // 设置方向
		walkBack (); // 后退
		float dis = Vector3.Distance (transform.position, m_bornPos);
		if (dis <= 0.05f)
			return TaskStatus.Success;

		return TaskStatus.Running;
	}
	public void walkBack()
	{
		float movespd = 0.3f;//(float)m_unit.getProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		transform.position += m_unit.m_directionVector * Time.deltaTime*movespd;
	}
	public override void setDir(int reverce)
	{
		if(m_unit == null || m_unit.target == null)
		{
			return;
		}
		m_unit.m_directionVector = (m_bornPos - transform.position);
		m_unit.m_directionVector [1] = 0;
		m_unit.m_directionVector = Vector3.Normalize(m_unit.m_directionVector);
		
		// 面向目标
		if (m_unit.m_directionVector != Vector3.zero)
		{
			Quaternion lookrotation = Quaternion.LookRotation(m_unit.m_directionVector);
			
			if (m_unit.m_animation != null && m_unit.m_animation.isPlaying)
			{
				transform.rotation = Quaternion.Lerp (transform.rotation, lookrotation, Time.deltaTime *3.0f);
			}
		}
	}
	public bool checkConditional()
	{
		exit = false;
		AI_Data data = m_unit.getAIData ();
		if (data == null)
			return false;
		float dis = Vector3.Distance (transform.position,m_unit.originPos);
		if(dis < data.eyedis)
		{
			exit = true;
		}
		return true;
	}
}
