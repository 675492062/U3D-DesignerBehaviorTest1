using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillStateMgr
{
	int 	 m_curStat = -1;
	MyPlayer m_char;
	Dictionary< int,SkillState>	m_aryStats = new Dictionary<int,SkillState>(); 

	public SkillStateMgr( MyPlayer cha )
	{
		m_char = cha;
		m_aryStats.Add ( 0,new NormalState("normal") );
		m_aryStats.Add ( 1,new JumpState("jump") );
		m_aryStats.Add ( 2,new WheelState("wheel") );
		m_aryStats.Add ( 3,new TeleportState("teleport") );
	}

	public bool Start( int skillId )
	{
		SkillConfigs configs = GameObject.FindObjectOfType(typeof(SkillConfigs)) as SkillConfigs;
		if (configs.GetConfigByID (skillId) == null) {
			Debug.LogError("in configs Skill is not have id=" + skillId);
			return false;
		}
		m_curStat = configs.GetConfigByID (skillId).m_aniType;
		m_aryStats [m_curStat].Init ( m_char );
		m_aryStats [m_curStat].EnterState (skillId);
		return true;
	}

	public void Update()
	{
		if (m_curStat < 0)
			return;
		m_aryStats [m_curStat].Update ();
	}
}
