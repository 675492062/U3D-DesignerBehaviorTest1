using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class Player_Hit : BaseState 
{
	public float waitTime = 1f;
	float tempWaitTime = 0;
	const int MAX_ROLLBACK_TIMES = 10;
	const int MAX_RUNAWAY_TIMES = 2;

	bool []canRoll = new bool[MAX_ROLLBACK_TIMES];		//记录这个区间是否已经翻滚过
	float  []hpPercent = new float[MAX_ROLLBACK_TIMES]; //翻滚的血量百分比


	bool []canRunaway = new bool[MAX_RUNAWAY_TIMES];		  //记录这个区间是否已经逃跑过
	float  []hpPercentRunaway = new float[MAX_RUNAWAY_TIMES]; //逃跑的血量百分比

	public Player_Hit(string name)
		: base(name)
	{	
		//先置为true 用过就置为false
		for (int i = 0; i < canRoll.Length; i++)
		{
			canRoll [i] = true;
		}
		//这个是读全局参数表
		for(int i = 850072; i < 850081; i++)
		{
			hpPercent[i - 850072] = (float)StaticGlobal_parameter.Instance().getInt(i,"parameter") / 100f;
		}
		//先置为true 用过就置为false
		for (int i = 0; i < canRunaway.Length; i++)
		{
			canRunaway [i] = true;
		}

	}
	
	public override void OnAwake()
	{	
	}
	
	public override void OnStart()
	{
		initData ();

		AI_Data data = m_unit.getAIData ();
		if(data != null)
		{
			hpPercentRunaway [0] = data.runAwayHp1;
			hpPercentRunaway [1] = data.runAwayHp2;
		}
	}
	
	public override void OnEnd()
	{

	}
	
	public override TaskStatus OnUpdate()
	{
		if(null == gameObject || null == m_unit)
		{
			return TaskStatus.Failure;
		}
		if(isDead())
			return TaskStatus.Success;

		tempWaitTime += Time.deltaTime;
		if(tempWaitTime >= waitTime)
		{
			tempWaitTime = 0;
//			if(checkLife(fsm))
//			{
//				return;
//			}
//			else 
//			{
//				fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
//			}
		}
		return TaskStatus.Success;
	}
	
	public bool checkLife(FSM fsm)
	{
		float curHP = m_unit.getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float maxHP = m_unit.getProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float percent = curHP / maxHP;

		//检测逃跑
		for(int i = 0; i < hpPercentRunaway.Length; i++)
		{
			if(percent <= hpPercentRunaway[i] && canRunaway[i] == true)
			{
				canRunaway[i] = false;
				fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_RUN_AWAY);
				return true;
			}
		}
		//检测翻滚
		int energy = (int)m_unit.getCurProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
		for(int i = 0; i < hpPercent.Length; i++)
		{
			if(percent < hpPercent[i] && canRoll[i] && energy > 0)
			{
				canRoll[i] = false;
				fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_ROLLINGBACK);
				return true;
			}
		}
		return false;
	}
}
