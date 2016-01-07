using UnityEngine;
using System.Collections;
using FSMTestingProject;
using BehaviorDesigner.Runtime.Tasks;

[TaskDescription("")]
[TaskCategory("AI")]
public class MonsterDeadState : BaseState {
	/// <summary>
	/// 怪物特效
	/// </summary>
	Monster_efs script_monEf; 	
	SoundEf_slash script_sound;

	public MonsterDeadState(string name)
		: base(name)
	{	
	}
	
	public override void OnAwake()
	{	

	}
	
	public override void OnStart()
	{
		initData ();

		script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
		script_sound = GameObject.FindWithTag("sound").GetComponent<SoundEf_slash>();
	}
	
	public override void OnEnd()
	{
	}
	
	public override TaskStatus OnUpdate()
	{
		if (!isDead()) 
		{
			return TaskStatus.Failure;		
		}

		//死亡相关事件
		m_unit.OnDeadEvent();
		Vector3 deadpos = m_unit.m_transform.position;
		m_unit.attackdir[1] = 0;
		
		script_sound.SoundOn(4);
		MonoBehaviour.Destroy (gameObject,0.01f);
		int type = Random.Range (1, 3);
		
		//杀敌效果相关
		script_monEf.EnemyDead(type, deadpos, m_unit.m_render.material.mainTexture, gameObject.transform.localScale, Vector3.zero, m_unit.m_TemplateID);

		
		//移除
		//EnemyCtrl.instance.existEnemies.Remove((Enemy)script);
		
		script_monEf.SetItemBox(((Enemy)m_unit).property.level,m_unit.m_transform.position,((Enemy)m_unit).m_dropItems);

		return TaskStatus.Success;
	}
}
