using UnityEngine;
using System.Collections;
using FSMTestingProject;
using LitJson;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class WaitForAttack : BaseState 
{
	float waitTime = 0f;
	float tempTime = 0f;

	int type;             //单位类型
	int curIdleTimes = 0; //当前犯傻次数
	int maxIdleTimes = 0; //当前犯傻次数
	int waitPercent;      //犯傻几率
	public WaitForAttack(string name)
		: base(name)
	{
			
	}
	public override void OnAwake()
	{

	}
	
	public override void OnStart()
	{
		initData ();

		type = (int)m_unit.m_unitType;
		waitPercent = m_unit.getAIData().idle_pro;
		maxIdleTimes = m_unit.getAIData().idle_num;


		string ani_name = "";
		if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		{
			ani_name = StaticMonster.Instance().getStr( m_unit.m_TemplateID, "idle");
			m_unit.m_animation [ani_name].speed = 0.1f;//speed_idle *(-0.5f);
			m_unit.m_animation.Stop ();
			m_unit.m_animation.CrossFade(ani_name);
		}
		else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
//			ani_name = StaticHero.Instance().getStr( m_unit.m_TemplateID, "idle");
		}
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

		type = (int)m_unit.m_unitType;
		tempTime += Time.deltaTime;
		if(tempTime >= waitTime)
		{
			tempTime = 0;

			SkillItem skill = m_unit.getCanUseSkill();

			if( skill != null)
			{
				return TaskStatus.Success;
			}
		}
		return TaskStatus.Running;
			/*
			if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
			{
//				int res = Random.Range(0,100);
//				if(res >=0 && res < waitPercent && curIdleTimes < maxIdleTimes) //犯傻
//				{
//					fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
//				}
//				else //攻击
				{
					SkillItem skill = m_unit.getCanUseSkill();
					if(null != skill)
						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_MONSTER_SKILL_ATTACK);
					else 
						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
				}
			}
			else if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
			*/
//			{
//
//
//				SkillItem skill = m_unit.getCanUseSkill();
//
//				if( skill == null && type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER )
//				{
////					fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
//					return TaskStatus.Success;
//				}
//				float curMp = m_unit.getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
//				//消耗
//				int needMp = 0;
//				if(skill != null)
//				{
//					 needMp = skill.consume;
//					if( type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER )
//					{
//						needMp = 0;
//					}
//				}
//
//				if(skill != null && skill.consume <= curMp)
//				{
//					skill.locked = true;
//					int actionType = skill.actiontype;
//					if(type == (int)GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
//						((Player)m_unit).OnMp(-1*skill.consume);
//
//					if(actionType == (int)GlobalDef.SkillActionType.SKILL_ACT_NORMAL)
//					{
////						AI_SkillNormal state =  (AI_SkillNormal)m_unit.getAI().getState((int)AI_Define.AI_State.S_SKILL_NORMAL);
////						state.m_skillId = skill.templateID;
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_SKILL_NORMAL);
//					}
//					else if(actionType == (int)GlobalDef.SkillActionType.SKILL_ACT_JUMP)
//					{
////						AI_SkillJump state = (AI_SkillJump)m_unit.getAI().getState((int)AI_Define.AI_State.S_SKILL_JUMP);
////						state.m_skillId = skill.templateID;
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_SKILL_JUMP);
//					}
//					else if(actionType == (int)GlobalDef.SkillActionType.SKILL_ACT_WHEEL)
//					{
////						AI_SkillWheel state = (AI_SkillWheel)m_unit.getAI().getState((int)AI_Define.AI_State.S_SKILL_WHEEL);
////						state.m_skillId = skill.templateID;
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_SKILL_WHEEL);
//					}
//					else if(actionType == (int)GlobalDef.SkillActionType.SKILL_ACT_TELEPORT)
//					{
////						AI_SkillTeleport state = (AI_SkillTeleport)m_unit.getAI().getState((int)AI_Define.AI_State.S_SKILL_TELEPORT);
////						state.m_skillId = skill.templateID;
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_SKILL_TELEPORT);
//					}
//				}
//				else 
//				{
//					if(type == (int)GlobalDef.UnitType.UNIT_TYPE_MONSTER)
//					{
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_IDLE);
//					}
//					else 
//					{
//						return TaskStatus.Success;
////						fsm.SetParamValue(AI_Define.P_STATE, (int)AI_Define.AI_State.S_PLAYER_NORMAL_ATTACK);
//					}
//				}
////				fsm.Update();
//			}
//		}
//		return TaskStatus.Running;
	}
}
