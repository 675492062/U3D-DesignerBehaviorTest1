using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class MonsterNormalAttack : BaseState {

//	bool attackstart = false;
	bool impact = false;
	Vector3 attackstartVector;
	float moving_atk = 0.4f;

	bool  startWait = false;
	float waitTime = 0.2f;
	float tempWaitTime = 0f;
	public MonsterNormalAttack(string name)
		: base(name)
	{
	
	}


	public override void OnAwake()
	{



	}
	
	public override void OnStart()
	{	
		initData ();
		MyPlayer cha = m_unit.target.GetComponent<MyPlayer>();
		if (cha.m_curStat < 110)
		{
			m_unit.m_animation.Stop ();		
			m_unit.m_animation.Play("m_attack1");
			m_unit.m_animation.PlayQueued("m_attack1_i",QueueMode.CompleteOthers);
			//attack_impact.speed = obj.animation["m_attack1_i"].speed;
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

		if(m_unit.m_animation.IsPlaying ("m_attack1"))
		{
			Quaternion lookrotation = Quaternion.LookRotation(attackstartVector);
			transform.rotation = Quaternion.Lerp (transform.rotation, lookrotation, Time.deltaTime *6.0f);
			transform.position += attackstartVector * Time.deltaTime * moving_atk;
		}
		else if (gameObject.GetComponent<Animation>().IsPlaying ("m_attack1_i"))
		{
			if(!impact)
			{
				impact = true;

				AudioClip snd_attack = Resources.Load("Sound/spear") as AudioClip;
				gameObject.GetComponent<AudioSource>().clip = snd_attack;
				gameObject.GetComponent<AudioSource>().Play();
				gameObject.transform.position = Vector3.right* transform.position.x + Vector3.forward* transform.position.z;

				startWait = true;
				float attack_ani_time = gameObject.GetComponent<Animation>()["m_attack1_i"].length;
				float attack_ani_speed= gameObject.GetComponent<Animation>()["m_attack1_i"].speed;
				waitTime = attack_ani_time / attack_ani_speed;
			}
		}
		if(startWait == true ) 
		{
			tempWaitTime += Time.deltaTime;
			if(tempWaitTime >= waitTime)
			{
				tempWaitTime = 0f;
//				checkDistance(fsm);
			}
		}
		return TaskStatus.Success;
	}
}
