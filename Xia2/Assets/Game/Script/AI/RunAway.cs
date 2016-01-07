using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class RunAway : BaseState {

	///
	float runAwayTime = 2f;
	float tempRunAwayTime = 0f;
	/// 播放走路声音
	float behaviour_delay = 2f;
	int behaviour = 0;
	AudioClip snd_move = new AudioClip();
	Monster_efs script_monEf;

	public RunAway(string name)
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

		setDir ( -1);      //设置方向
		runAway();		   //逃跑
		if(checkTime())    //
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}
	public void runAway()
	{
		Transform target = m_unit.target;
//		float speed = (float)m_unit.getProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		float speed = (float)m_unit.getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		transform.position += m_unit.m_directionVector * Time.deltaTime*speed;

	}
	/// <summary>
	/// 检测切换下一个状态的条件
	/// </summary>
	public  bool checkTime()
	{
		tempRunAwayTime += Time.deltaTime;
		if(tempRunAwayTime >= runAwayTime)
		{
			tempRunAwayTime = 0f;
			return true;
		}
		return false;
	}
	
}
