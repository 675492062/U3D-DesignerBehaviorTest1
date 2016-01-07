using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class CanRunAway : Conditional {

	const int MAX_RUNAWAY_TIMES = 2;
	const int MAX_ROLLBACK_TIMES = 10;
	
	bool []canRunaway = new bool[MAX_RUNAWAY_TIMES];		  //记录这个区间是否已经逃跑过
	float  []hpPercentRunaway = new float[MAX_RUNAWAY_TIMES]; //逃跑的血量百分比

	public override void OnAwake()
	{
		//先置为true 用过就置为false
		for (int i = 0; i < canRunaway.Length; i++)
		{
			canRunaway [i] = true;
		}
	}

	public override void OnStart()
	{
		Unit m_unit = gameObject.GetComponent<Unit> ();
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
		if(gameObject.GetComponent<Unit>().m_isDead)
			return TaskStatus.Failure;
		
		if(canDo())
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
	public bool canDo()
	{
		Unit m_unit = gameObject.GetComponent<Unit>();
		float curHP = m_unit.getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float maxHP = m_unit.getProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float percent = curHP / maxHP;

		//检测逃跑
		for(int i = 0; i < hpPercentRunaway.Length; i++)
		{
			if(percent <= hpPercentRunaway[i] && canRunaway[i] == true)
			{
				canRunaway[i] = false;
				return true;
			}
		}
		return false;
	}
}
