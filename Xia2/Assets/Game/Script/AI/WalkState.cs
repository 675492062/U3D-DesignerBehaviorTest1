using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
class WalkState : BaseState
{
	float behaviour_delay = 2f;
	int behaviour = 0; 	
	AudioClip snd_move;
	Monster_efs script_monEf;

	float maxdis; //距离判断
	float mindis; //距离判断
	float changeDis;// 随机中间取一个距离数值
	public WalkState(string name)
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
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "walk");
			m_unit.m_animation [ani_name].speed = 0.34f;	//speed_idle *(-0.5f);
			//设置声音
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
			snd_move = script_monEf.snd_move[Random.Range(0,3)];
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "walk");

			//设置声音
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
			snd_move = script_monEf.snd_move[Random.Range(0,3)];
			script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
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

		setDir ();      // 设置方向
		walk ();        // 
		if(checkDis())  // 检查是否可以切换状态
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}
	public void walk()
	{
		Transform target = m_unit.target;
		float movespd = (float)m_unit.getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_WALKSPD) / 100f;
		transform.position += m_unit.m_directionVector * Time.deltaTime*movespd;

		behaviour_delay -= Time.deltaTime;
		if (behaviour_delay < 0)
		{
			behaviour = Random.Range (0,6);
			if (behaviour == 0)
			{
				m_unit.m_audio.clip = snd_move;
				m_unit.m_audio.Play();
			}
			behaviour_delay = 2.0f;
		}
	}
	/// <summary>
	/// 检测切换下一个状态的条件
	/// </summary>
	public  override bool checkDis()
	{
		if(base.checkDis())
		{
			return true;
		}
		AI_Data data = m_unit.getAIData ();
		float curDis = getDistance ();
		float attackDis = m_unit.getAttackDis ();
		float rundis = data.rundis;

		if(curDis <= attackDis) //attack
		{
			return true;
		}
		else if (curDis > rundis) 
		{
			return true; 
		}	
		return false;
	}
}