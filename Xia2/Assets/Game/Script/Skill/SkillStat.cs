#define GAME

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;

#if GAME
using FSMTestingProject;
#endif
[TaskCategory("AI/PlayerSkill")]
public class SkillState : BaseState
{	
	public SkillState(string name)
		: base(name)
	{
		this.name = name;
		init ();
	}
	public void init()
	{
		m_fxOnlyOne = new List<bool>();
	}
	private string 	   name;
	protected float    m_delay;

//	public Unit  	   m_unit;
	public Animation   m_ani;
	public int		   m_skillId;
#if GAME
//	public override void OnAwake(){}
//	public override void EnterState(FSM fsm){}
//	public override void LeaveState(FSM fsm){}
//	public override void Excute(FSM fsm){}
	public SkillItem   m_skill;
#endif

	public Transform   m_fxs;
	public string	   m_strBuffFx;
	public float       m_param;
	public string      m_aniName;
	public string 	   m_aniCastName = "";
	public float	   m_fxStartTriggerDelay;
	public float	   m_aniType;
	public Transform   m_buffFx = null;
	public int         m_objtype = 1;
	
	public Config 	   m_curSkillConfig; 		  
	public List<bool>  m_fxOnlyOne;
	public bool		   m_soundOnlyOne;

	public Vector3    targetPos;
	public string Name
	{
		get { return name; }
	}
	
	public override string ToString()
	{
		return string.Format("state name : {0}", name);
	}

	public bool GetSkillInfo( int skillId)
	{
		m_skillId = skillId;
		if (m_unit == null) {
			Debug.LogError("unit is error");		
			return false;
		}
		m_skill = m_unit.getUseSkillByTemplateID (skillId);
		if (m_skill == null)
			return false;

		SkillConfigs configs = GameObject.FindObjectOfType(typeof(SkillConfigs)) as SkillConfigs;
		m_curSkillConfig = configs.GetConfigByID (skillId);
		if (m_curSkillConfig == null)
		{
			Debug.LogError("GetConfig Failed! skillid:" + skillId);
			return false;
		}
		m_aniName = m_curSkillConfig.m_aniName;

		int fxCount = m_curSkillConfig.m_fx.Count;	
		m_fxOnlyOne.Clear ();
		for (int i = 0; i < fxCount; i++) {
			m_fxOnlyOne.Add(false);
		}
		m_soundOnlyOne = false;

		string soundPath = m_curSkillConfig.m_soundName;
		if (!string.IsNullOrEmpty (soundPath)) {
			string name = soundPath.Split('/')[3];
			name = name.Split('.')[0];
			m_curSkillConfig.m_sound = PrefabManager.Instance ().GetAudio ("Sound",name) as Object;
		}
		return true;
	}

	public bool ProcessCasting()
	{
		if (m_delay <= 0.26f) {
			if (m_unit.m_directionVector != Vector3.zero)
				m_unit.m_transform.rotation = Quaternion.Lerp (m_unit.m_transform.rotation, Quaternion.LookRotation (m_unit.m_directionVector), Time.deltaTime * 200);
			return true;
		} 
		m_unit.m_rigidbody.drag = 5;
		m_unit.m_skillScript.SetDirArrow (false);
		Time.timeScale = 1;
		return false;
	}

	public float ProcessAnimation()
	{
		if(m_unit == null || m_unit.m_animation == null || m_unit.m_animation.GetClip(m_aniName) == null)
		{
			Debug.LogError("have not ani: " + m_aniName);
			return -1;
		}
		float aniTime = m_unit.m_animation[m_aniName].time;
		if( aniTime >= m_unit.m_animation[m_aniName].length-0.01f )
		{
			m_unit.m_bSkilling = false;
			return -1;
		}
		if (!m_unit.m_animation.IsPlaying (m_aniName)) {
			m_unit.m_bSkilling  = false;
			Debug.LogError("skill state Error!");
			return -1;
		}
		return aniTime;
	}

	public void Init( Unit unit )
	{
		m_unit = unit;
	}
	
	public virtual bool EnterState( int skillId )
	{
		if (!GetSkillInfo (skillId))
			return false;

		m_delay = 0;
		if(m_unit.m_animation.GetClip(m_aniName) != null)
		{
			m_unit.m_animation.Play(m_aniName);
		}
		else 
		{
			Debug.LogError("have not ani: " + m_aniName);
		}
		if( !string.IsNullOrEmpty(m_aniCastName))
			m_unit.m_animation.PlayQueued(m_aniCastName,QueueMode.CompleteOthers);
		return true;
	}

	public virtual bool PlayEffect( float frame,Vector3 touchPos )
	{
		bool b = false;
		for (int i = 0; i < m_curSkillConfig.m_fx.Count; i++) {
			float tmp_frame = m_curSkillConfig.m_fx[i].frame;
			if( !m_fxOnlyOne[i] && tmp_frame <= frame )
			{
				m_fxOnlyOne[i] = true;

				string srcPath = m_curSkillConfig.m_fx[i].name;
				if( srcPath == "" )
					continue;
				string notprefabPath = srcPath.Split('.')[0];

				string[] lit = notprefabPath.Split('/');
				int len = lit.Length;
				string name = lit[len - 1 ];

				notprefabPath = notprefabPath.Substring(17);
				Transform tmp_fx = PrefabManager.Instance ().GetFx (notprefabPath,name);
				if( i == 0 )
				{
					m_unit.m_skillScript.PlaySkillMainFx( tmp_fx,m_skillId,touchPos );
					b = true;
				}else
				{
					m_unit.m_skillScript.PlaySkillFx( tmp_fx );
				}
			}
		}
		if (b) {
			#if GAME
			m_skill.resetCD();	
			#endif
		}
		return b;
	}

	public virtual bool PlaySound ( float frame )
	{
		if ( !m_soundOnlyOne && m_curSkillConfig.m_sound != null && m_curSkillConfig.m_soundFrame <= frame ) {
			m_unit.m_audio.clip = m_curSkillConfig.m_sound as AudioClip;
			m_unit.m_audio.Play();
			m_soundOnlyOne = true;
			return true;
		}	
		return false;
	}

	public virtual bool Update()
	{
//		m_delay += Time.deltaTime;
//		float frame = ProcessAnimation ();
//		if (frame == -1)
//			return true; 
//		
//		ProcessCasting ();
//
//		PlayEffect (frame);
//
//		PlaySound (frame);

		return true;
	}
}
[TaskCategory("AI/PlayerSkill")]
//normal state
public class NormalState : SkillState
{
	public NormalState(string name)
		: base(name)
	{
		
	}

	public override bool Update()
	{
		m_delay += Time.deltaTime;
		float frame = ProcessAnimation ();
		if (frame == -1)
			return true; 
		
		ProcessCasting ();
		PlayEffect (frame,((MyPlayer)m_unit).currentTouchPos);
		PlaySound (frame);

		return true;
	}
}
[TaskCategory("AI/PlayerSkill")]
//jump state
public class JumpState : SkillState
{
	private float 	m_jumpMoveFactor = 0.7f;
	private Vector3 m_jumpDir;
	public JumpState(string name)
		: base(name)
	{
		
	}
	
	public override bool EnterState( int skillId )
	{
		m_jumpMoveFactor = 0.7f;
		m_jumpDir = Vector3.zero;
		base.EnterState (skillId);
		return true;
	}
	
	public override bool Update()
	{
		m_delay += Time.deltaTime;
		float frame = ProcessAnimation ();
		if (frame == -1)
			return true; 

		if (!ProcessCasting ()) {		
			m_jumpMoveFactor = m_jumpMoveFactor-0.015f;
			if( m_jumpMoveFactor <= 0 )
				m_jumpMoveFactor = 0;
			((MyPlayer)m_unit).m_curPos += m_jumpDir * Time.deltaTime * m_jumpMoveFactor;
		}else
		{
			m_jumpDir = m_unit.m_directionVector;
		}

		PlayEffect (frame,((MyPlayer)m_unit).currentTouchPos);
		PlaySound (frame);
		
		return true;
	}
}
[TaskCategory("AI/PlayerSkill")]
//wheel state
public class WheelState : SkillState
{
	public WheelState(string name)
		: base(name)
	{
		
	}

	public override bool Update()
	{
		m_delay += Time.deltaTime;
		float frame = ProcessAnimation ();
		if (frame == -1)
			return true; 
		
		if (!ProcessCasting ()) {
			if( frame >= m_param )
				((MyPlayer)m_unit).m_curStat = 222;
			else
				((MyPlayer)m_unit).m_curStat = 100;
		}
		
		PlayEffect (frame,((MyPlayer)m_unit).currentTouchPos);
		PlaySound (frame);
			
		return true;
	}
}
[TaskCategory("AI/PlayerSkill")]
//shun yi
public class TeleportState : SkillState
{
	public TeleportState(string name)
		: base(name)
	{
		
	}

	
	public override bool Update()
	{
		m_delay += Time.deltaTime;
		float frame = ProcessAnimation ();
		if (frame == -1)
			return true; 
		
		ProcessCasting ();
		
		if (PlayEffect (frame,((MyPlayer)m_unit).currentTouchPos)) {
			((MyPlayer)m_unit).m_curPos = ((MyPlayer)m_unit).currentTouchPos;
			((MyPlayer)m_unit).m_curPos.y = 0;
		}
		
		PlaySound (frame);
		return true;
	}
}


//public class TeleportCharmState : SkillState
//{
//	public TeleportCharmState(string name)
//		: base(name)
//	{
//		
//	}
//
//	public override bool PlayEffect( float frame,Vector3 touchPos )
//	{
//		bool b = false;
//		for (int i = 0; i < m_curSkillConfig.m_fx.Count; i++) {
//			float tmp_frame = m_curSkillConfig.m_fx[i].frame;
//			if( !m_fxOnlyOne[i] && tmp_frame <= frame )
//			{
//				m_fxOnlyOne[i] = true;
//				
//				string srcPath = m_curSkillConfig.m_fx[i].name;
//				if( srcPath == "" )
//					continue;
//				string notprefabPath = srcPath.Split('.')[0];
//				
//				string[] lit = notprefabPath.Split('/');
//				int len = lit.Length;
//				string name = lit[len - 1 ];
//				
//				notprefabPath = notprefabPath.Substring(17);
//				Transform tmp_fx = PrefabManager.Instance ().GetFx (notprefabPath,name);
//				if( i == 0 )
//				{
//					CreateUnrealFx(tmp_fx);
//					m_unit.m_skillScript.PlaySkillMainFx( tmp_fx,m_skillId,touchPos );
//					b = true;
//				}else
//				{
//					m_unit.m_skillScript.PlaySkillFx( tmp_fx );
//				}
//			}
//		}
//		if (b) {
//			#if GAME
//			m_skill.resetCD();	
//			#endif
//		}
//		return b;
//	}
//
//	public void CreateUnrealFx( out Transform fx )
//	{
//		MyPlayer player = ((MyPlayer)m_unit);
//		string name = player.GetCurCharData ().resname;
//		Transform hero = player.m_transform.Find (name);
//		hero = (Transform)Instantiate (hero, hero.position, hero.rotation);
//		hero.gameObject.SetActive (true);
//		hero.animation.Play ("");
//	}
//
//	public override bool Update()
//	{
//		m_delay += Time.deltaTime;
//		float frame = ProcessAnimation ();
//		if (frame == -1)
//			return true; 
//		
//		ProcessCasting ();
//		
//		if (PlayEffect (frame,((MyPlayer)m_unit).currentTouchPos)) {
//			((MyPlayer)m_unit).m_curPos = ((MyPlayer)m_unit).currentTouchPos;
//			((MyPlayer)m_unit).m_curPos.y = 0;
//		}
//		
//		PlaySound (frame);
//		return true;
//	}
//}



//public class CastingState : SkillState
//{
//	Transform	fx;
//	bool 		onlyOneCast = false;
//	public CastingState(string name)
//		: base(name)
//	{
//		
//	}
//	
//	public int ProcessCastingAnimation()
//	{
//		if (!onlyOneCast) {
//			if (m_unit == null || m_unit.m_animation == null || m_unit.m_animation.GetClip (m_aniName) == null) {
//				onlyOneCast = true;
//				Debug.LogError ("have not ani: " + m_aniName);
//				return -1;
//			}
//			
//			float aniTime = m_unit.m_animation [m_aniName].time;
//			if (aniTime >= m_unit.m_animation [m_aniName].length - 0.01f) {
//				onlyOneCast = true;
//			}
//			if (!m_unit.m_animation.IsPlaying (m_aniName)) {
//				onlyOneCast = true;
//			}
//			return 1;
//		} else {
//			if (m_unit == null || m_unit.m_animation == null || m_unit.m_animation.GetClip (m_aniCastName) == null) {
//				Debug.LogError ("have not ani: " + m_aniName);
//				return -1;
//			}
//			
//			float aniTime = m_unit.m_animation [m_aniCastName].time;
//			if (aniTime >= m_unit.m_animation [m_aniCastName].length - 0.01f) {
//				return -1;
//			}
//			if (!m_unit.m_animation.IsPlaying (m_aniCastName)) {
//				return -1;
//			}
//			return 2;
//		}
//	}
	
	//	public override bool Update()
	//	{
	//		if (ProcessCasting ())
	//			return true;
	//		int res = ProcessCastingAnimation ();
	//		if (res == -1) {
	//			//fx del
	//			return true;		
	//		}
	//		if (res == 1)
	//			return true;
	//
	//		//start paly fx
	//	}
//}

