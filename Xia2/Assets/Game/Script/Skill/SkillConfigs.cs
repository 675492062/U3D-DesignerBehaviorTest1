using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Fx
{
	public Object obj = null;
	public string name = "";
	public float  frame = 0;
}

[System.Serializable]
public class Config
{
	public int		  	   m_skillID;
	public string 		   m_remark; //< 技能备注
	public string 		   m_aniName;
	public int			   m_aniType;
	public int   		   m_objType; //< 1 自己为中心 2点击点为中心
	public List<Fx>		   m_fx = new List<Fx> ();
	public Object		   m_sound;
	public float		   m_soundFrame = 0;
	public string		   m_soundName = "";

	public void Reset()
	{
	   m_skillID = 0;
	   m_remark = "";
	   m_aniName = "";
	   m_aniType = 0;
	   m_fx.Clear ();
	   m_sound = null;
	   m_soundFrame = 0;
		m_soundName = "";
	}

	public void Copy( Config other )
	{
		m_skillID = other.m_skillID;
		m_remark = other.m_remark;
		m_aniName = other.m_aniName;
		m_aniType = other.m_aniType;
		m_fx.Clear ();
		m_fx.InsertRange (0,other.m_fx);
		
		for (int i = 0; i < m_fx.Count; i++) {
			m_fx[i].obj = null;		
		}		

		m_sound = null;
		m_soundFrame = other.m_soundFrame;
		m_soundName = other.m_soundName;
	}
}

public class SkillConfigs : MonoBehaviour {

	public List<Config>		m_configs = new List<Config>();

	public Config GetConfigByID( int skillID )
	{
		return CheckIsHave (skillID);
	}

	public Config CheckIsHave( int skillID )
	{
		for (int i = 0; i < m_configs.Count; i++) {
			if( m_configs[i].m_skillID == skillID )
				return m_configs[i];
		}
		return null;
	}

	//< 把其他的复制添加到我这里
	public void Copy( SkillConfigs other )
	{
		for (int i = 0; i < other.m_configs.Count; i++) {
			Config o= other.m_configs[i];   		//< 其他资源
			Config m = CheckIsHave( o.m_skillID );	//< 监测 此技能ID	的资源是否存在我这里
			if( m == null )
			{
				m_configs.Add(new Config());
				m_configs[m_configs.Count-1].Copy(o);
			}else
			{
				m.Copy(o);							//< 存在覆盖
			}
		}
	}
}
