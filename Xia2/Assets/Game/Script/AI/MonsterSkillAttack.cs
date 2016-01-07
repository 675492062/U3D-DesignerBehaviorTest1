using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class MonsterSkillAttack : BaseState {

	//	bool attackstart = false;
	bool impact = false;
	Vector3 attackstartVector;
//	float moving_atk = 0.4f;
	
	bool  startWait = false;
	float waitTime = 0.2f;
	float tempWaitTime = 0f;

	
	public MonsterSkillAttack(string name)
		: base(name)
	{
		
	}
	
	
	public override void OnAwake()
	{

	}
	
	public override void OnStart()
	{	
		initData ();

//		if (checkTarget (fsm))
//			return;

		MyPlayer cha = m_unit.target.GetComponent<MyPlayer>();
		if (cha.m_curStat < 110)
		{
			gameObject.GetComponent<Animation>().Stop ();		
			gameObject.GetComponent<Animation>().Play("m_attack1");
			gameObject.GetComponent<Animation>().PlayQueued("m_attack1_i",QueueMode.CompleteOthers);
			//attack_impact.speed = obj.animation["m_attack1_i"].speed;

//			setDir(fsm); //更新次方向
			attackstartVector = m_unit.m_directionVector;
		}	
	}
	
	public override void OnEnd()
	{
		impact = false;
		startWait = false;
	}
	
	public override TaskStatus OnUpdate()
	{
		if(gameObject  == null || m_unit == null)
		{
			return TaskStatus.Failure;
		}
		if(isDead())
			return TaskStatus.Success;

		Transform target = m_unit.target;

		if(gameObject.GetComponent<Animation>().IsPlaying ("m_attack1"))
		{
			Quaternion lookrotation = Quaternion.LookRotation(attackstartVector);
			transform.rotation = Quaternion.Lerp (transform.rotation, lookrotation, Time.deltaTime *6.0f);
//			transform.position += attackstartVector * Time.deltaTime * moving_atk;
		}
		else if (gameObject.GetComponent<Animation>().IsPlaying ("m_attack1_i"))
		{
//<LEE DOTO
			if(!impact)
			{
				impact = true;
				SkillItem item = m_unit.getCanUseSkill();
				if(null == item)
					return TaskStatus.Failure;
				item.resetCD();
				item.priorityCount++; //优先级计数增加
				int skillID = item.templateID;
				Enemy enemy = gameObject.GetComponent<Enemy>();
				if(enemy != null)
				{
					enemy.skillData.GetSkillInfo(skillID);
					Bullet_tornado eff = ((GameObject)enemy.skillData.m_curSkillConfig.m_fx[0].obj).GetComponent<Bullet_tornado>();
					if(eff != null)
						eff.script_mon = (Enemy)m_unit;

					enemy.GetComponent<Skill>().PlaySkillMainFx(((GameObject)enemy.skillData.m_curSkillConfig.m_fx[0].obj).transform,skillID,Vector3.zero);
				}
				AudioClip snd_attack = Resources.Load("Sound/spear") as AudioClip;
				gameObject.GetComponent<AudioSource>().clip = snd_attack;
				gameObject.GetComponent<AudioSource>().Play();

				startWait = true;
				float attack_ani_time = gameObject.GetComponent<Animation>()["m_attack1_i"].length;
				float attack_ani_speed= gameObject.GetComponent<Animation>()["m_attack1_i"].speed;
				waitTime = attack_ani_time / attack_ani_speed - 0.05f;
			}
		}
		if(startWait == true ) 
		{
			tempWaitTime += Time.deltaTime;
			if(tempWaitTime >= waitTime)
			{
				tempWaitTime = 0f;
				startWait = false;
//				checkDis(fsm);
			}
		}
		return TaskStatus.Success;
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
		float returnDis = attackDis;

		if(curDis < returnDis * 0.8f) //back
		{
			return true;
		}
		else if (curDis > rundis) 
		{
			return true;
		}
		else 
		{
			return true;
		}
		return false;
	}
}
