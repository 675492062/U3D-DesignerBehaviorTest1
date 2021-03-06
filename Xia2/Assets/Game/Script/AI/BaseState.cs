using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

[TaskDescription("状态基类")]
[TaskCategory("AI")]
public abstract class BaseState : Action
{
	string stateName;
	public BaseState(string name)

	{
		stateName = name;
	}

	public Unit 	    m_unit;     //脚本对象
	public Vector3      m_bornPos{ get; set;}  //保存出生点

	float checkDisTime = 1f;
	float tempCheckDisTime = 0f;

	/// <summary>
	/// 初始化公用数据
	/// </summary>
	public void initData()
	{
		if (gameObject != null) 
		{
			m_unit = gameObject.GetComponent<Unit>();
		}
	}

	/// <summary>
	/// update 更新朝向 始终是朝向目标
	/// </summary>
	public virtual void setDir(int reverse = 1)
	{
		if(m_unit == null || m_unit.target == null)
		{
			return;
		}

		float attackrange = Vector3.Distance (transform.position,m_unit.target.position);

		if(reverse  == -1) //反方向
		{
			m_unit.m_directionVector = (transform.position - m_unit.target.position);
		}
		else 
		{
			m_unit.m_directionVector = (m_unit.target.position - transform.position);
		}

		m_unit.m_directionVector [1] = 0;
		m_unit.m_directionVector = Vector3.Normalize(m_unit.m_directionVector);

//		m_unit.m_directionVector *= reverse;
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

	public float getDistance()
	{
		if(null == gameObject || null == m_unit)
		{
			return -1;
		}

		Transform target = m_unit.target;
		if(null == target)
		{
			return -1;
		}
		float dis = Vector3.Distance (transform.position,target.position);
		return dis;
	}

	public virtual bool checkDis()
	{
//		AI_Data data = m_unit.getAIData ();
//		if (data == null)
//			return false;
//		float dis = Vector3.Distance (transform.position,m_unit.originPos);
//		if(dis > data.eyedis)
//		{
//			return true;
//		}
		return false;
	}

    
	public bool checkConditional(SkillItem item, GlobalDef.SkillActionType type)
	{
		if(item == null)
			return true;

		if(item.actiontype != (int)type)
			return true;

		float curMp = m_unit.getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);

		if(curMp < item.consume)
			return true;

		float range = item.range_R / 100f;
		float dis = getDistance ();
		if(dis > range)
		{
			return true;
		}
		return false;
	}

	public bool isDead()
	{
		if(m_unit.m_isDead)
			return true;
		return false;
	}

	public bool isSkilling()
	{
		if(m_unit.m_bSkilling)
			return true;
		return false;
	}

	public bool isHiting()
	{
		if(m_unit.m_bHiting)
			return true;
		return false;
	}
}
