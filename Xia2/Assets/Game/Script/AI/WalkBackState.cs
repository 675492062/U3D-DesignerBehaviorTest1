using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class WalkBackState : BaseState 
{
	float behaviour_delay = 2f;
	int behaviour = 0; 	
	AudioClip snd_move;
	Monster_efs script_monEf;

	float backDis = 0.15f;
	public WalkBackState(string name)
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
		backDis = data.walk_back;

		m_unit.m_animation.Stop ();
		int type = (int)m_unit.m_unitType;
		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "walk");
			m_unit.m_animation [ani_name].speed = -0.15f;
			//设置声音
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
			snd_move = script_monEf.snd_move[Random.Range(0,3)];
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "walk");
			m_unit.m_animation [ani_name].speed = -0.15f;
		}
		
		m_unit.m_animation.Stop ();
		m_unit.m_animation.CrossFade(ani_name);
	}
	
	public override void OnEnd()
	{
	}
	public override TaskStatus OnUpdate()
	{
		if(null == gameObject || null == m_unit)
		{
			return TaskStatus.Running;
		}	
		if(isDead())
			return TaskStatus.Success;
		if(isHiting())
			return TaskStatus.Success;

		setDir ();     // 设置方向
		walkBack ();   // 后退
		if(checkDis ())
			return TaskStatus.Success;

		return TaskStatus.Running;
	}
	public void walkBack()
	{
		Transform target = m_unit.target;
		float movespd = -0.1f;//(float)m_unit.getProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		transform.position += m_unit.m_directionVector * Time.deltaTime*movespd;
	}
	/// <summary>
	/// 检测切换下一个状态的条件
	/// </summary>
	public  override bool checkDis()
	{
		AI_Data data = m_unit.getAIData ();
		float curDis = getDistance ();
		float attackDis = m_unit.getAttackDis ();
		float rundis = data.rundis;

		if(curDis <= attackDis) //attack
		{
			return true;
		}
		else if (curDis > attackDis) 
		{
			return true;
		}		
		return false;
	}
}
