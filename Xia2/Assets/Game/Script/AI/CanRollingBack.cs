using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class CanRollingBack : Conditional {
	
	const int MAX_ROLLBACK_TIMES = 10;
	
	bool []canRoll = new bool[MAX_ROLLBACK_TIMES];		//记录这个区间是否已经翻滚过
	float  []hpPercent = new float[MAX_ROLLBACK_TIMES]; //翻滚的血量百分比

	public override void OnAwake()
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
	}

	public override void OnStart()
	{

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

		//检测翻滚
//		int energy = (int)m_unit.getCurProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
		for(int i = 0; i < hpPercent.Length; i++)
		{
			if(percent < hpPercent[i] && canRoll[i] /*&& energy > 0*/)
			{
				canRoll[i] = false;
				return true;
			}
		}
		return false;
	}
}
