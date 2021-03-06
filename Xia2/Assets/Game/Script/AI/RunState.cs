using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]

class RunState : BaseState
{
	float attack_dis = 0.2f;

	/// 播放走路声音
	float behaviour_delay = 2f;
	int behaviour = 0;
	AudioClip snd_move = new AudioClip();
	Monster_efs script_monEf;

	float maxdis;   //距离判断
	float mindis;   //距离判断
	float changeDis;//随机中间取一个距离数值

	bool exit = false;
	public RunState(string name)
		: base(name)
	{
		
	}

	public override void OnAwake()
	{

	}
	
	public override void OnStart()
	{
		initData ();
		exit = checkDis ();
		if(exit)
			return;

		AI_Data data = m_unit.getAIData ();
		maxdis = data.max_startwalkdis;
		mindis = data.min_startwalkdis;	
		changeDis = Random.Range (mindis, maxdis);

		//设置声音
		script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
		snd_move = script_monEf.snd_move[Random.Range(0,3)];
		script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();

		int type = (int)m_unit.m_unitType;
		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr(m_unit.m_TemplateID, "move");
			m_unit.m_animation [ani_name].speed = 0.4f;	
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			ani_name = StaticHero.Instance().getStr(m_unit.m_TemplateID, "move");
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

		setDir ();     //设置方向
		run ();		   //
		if(checkDis()) //检查是否可以切换到下一个状态
		{
			return TaskStatus.Success; 
		}
		return TaskStatus.Running;
	}
	public void run()
	{
		Transform target = m_unit.target;
//		float speed = (float)m_unit.getProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		float speed = (float)m_unit.getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		transform.position += m_unit.m_directionVector * Time.deltaTime*speed;

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
		float curDis = getDistance ();
		float attackDis = m_unit.getAttackDis ();

		if(curDis <= attackDis) //attack
		{
			return true;
		}
		else if(curDis <= changeDis && m_unit.m_unitType != GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO) //走路 
		{
			return true;
		}
		return false;
	}
}