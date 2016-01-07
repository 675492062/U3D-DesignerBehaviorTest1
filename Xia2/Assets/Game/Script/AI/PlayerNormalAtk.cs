using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI/Player")]
public class PlayerNormalAtk : BaseState {

	float waitTime = 0f;
	float tempWaitTime = 0f;
	public PlayerNormalAtk(string name)
		: base(name)
	{
		
	}
	public override void OnAwake()
	{

	}

	public override void OnStart()
	{	
		initData();
		setDir();
		Player otherPlayer = (Player)m_unit;
		if(null != otherPlayer)
		{
			waitTime = otherPlayer.OnAttack(otherPlayer.target);
		}
	}
	public override void OnEnd()
	{

	}
	public override TaskStatus OnUpdate()
	{
		if (gameObject == null || m_unit == null)
			return TaskStatus.Failure;
		if(isDead())
			return TaskStatus.Success;
		if(isHiting())
			return TaskStatus.Success;

		if(m_unit.target == null || m_unit.target.GetComponent<Unit>().m_isDead)
		{
			return TaskStatus.Failure;
		}

		setDir ();
		tempWaitTime += Time.deltaTime;
		if(tempWaitTime >= waitTime)
		{
			tempWaitTime = 0;
			if(checkDis())
			{
				return TaskStatus.Success;
			}
			Player otherPlayer = (Player)m_unit;
			waitTime = otherPlayer.OnAttack(otherPlayer.target);
		}
		return TaskStatus.Running;
	}
	public override bool checkDis()
	{
		float attackDis = m_unit.getAttackDis ();
		float dis = getDistance ();
		if(dis > attackDis + 0.1f)
		{
			return true;
		}
		SkillItem skill = m_unit.getCanUseSkill ();
		if(skill != null)
		{
			float curMp = m_unit.getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
			if(curMp > skill.consume)
				return true;
		}
		return false;
	}
}
