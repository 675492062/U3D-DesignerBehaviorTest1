using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyProperty 
{
	/// <summary>
	/// 基础属性容器
	/// </summary>
	Dictionary<int, float> baseProperty = new Dictionary<int, float>();
	/// <summary>
	/// 可更改属性的容器
	/// </summary>
	Dictionary<int, float> resProperty = new Dictionary<int, float>();

	public int    m_templateID = 0;
	public string icon;
	public int    type;
	public string name;
	public string resname;
	public int    level;
	public int    exp;
	public int    []skillid = new int[5];
	public EnemyProperty()
	{
		for(int i = 0; i < 5; i++)
		{
			skillid[i] = 0;
		}
	}

	/// <summary>
	/// 获取基础属性 
	/// </summary>
	public float getBasePro(int type)
	{
		if(baseProperty.ContainsKey(type))
		{
			return baseProperty[type];
		}
		return 0;
	}
	/// <summary>
	/// 获取变属性 
	/// </summary>
	public float getResPro(int type)
	{
		if(resProperty.ContainsKey(type))
		{
			return resProperty[type];
		}
		return 0;
	}
	/// <summary>
	/// 设置属性
	/// </summary>
	public void setResPro(int type, float value)
	{
		if(resProperty.ContainsKey(type))
		{
			resProperty[type] = value;
		}
	}
	public void add2Dict(int type, float value)
	{
		if(baseProperty.ContainsKey(type))
		{
			baseProperty[type] = value;
			return;
		}
		baseProperty.Add (type, value);
	}
	public void parseData(int templateID)
	{
		m_templateID = templateID;
		icon = StaticMonster.Instance().getStr(templateID, "icon");
		type = StaticMonster.Instance().getInt(templateID, "type");
		name = StaticMonster.Instance().getStr(templateID, "name");
		resname = StaticMonster.Instance().getStr(templateID, "resname");
		level = StaticMonster.Instance ().getInt (templateID, "level");
		exp   = StaticMonster.Instance().getInt(templateID, "exp");


		skillid[0] = StaticMonster.Instance().getInt(templateID, "skillid1");
		skillid[1] = StaticMonster.Instance().getInt(templateID, "skillid2");
		skillid[2] = StaticMonster.Instance().getInt(templateID, "skillid3");
		skillid[3] = StaticMonster.Instance().getInt(templateID, "skillid4");
		skillid[4] = StaticMonster.Instance().getInt(templateID, "skillid5");

		add2Dict((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT, StaticMonster.Instance().getFloat(templateID, "life"));
		float min = StaticMonster.Instance ().getFloat (templateID, "MIN_attack");
		float max = StaticMonster.Instance ().getFloat (templateID, "MAX_attack");
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_MINATTACK, min);
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK, max);
//		baseProperty.Add((int)GlobalDef.NewHeroProperty.PRO_ATTACK, Random.Range(min, max));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_ARMOR, StaticMonster.Instance().getFloat(templateID, "armor"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT, StaticMonster.Instance().getFloat(templateID, "manapoint"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_HITLV, StaticMonster.Instance().getFloat(templateID, "hitlv"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_DODGELV, StaticMonster.Instance().getFloat(templateID, "dodgelv"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV, StaticMonster.Instance().getFloat(templateID, "criticallv"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE, StaticMonster.Instance().getFloat(templateID, "criticaldamage"));

		add2Dict((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV, StaticMonster.Instance().getFloat(templateID, "tenacitylv"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_ATKSPD, StaticMonster.Instance().getFloat(templateID, "atkspd"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_MOVSPD, StaticMonster.Instance().getFloat(templateID, "movspd"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_WALKSPD, StaticMonster.Instance().getFloat(templateID, "walkspd"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_ATKRANGE, StaticMonster.Instance().getFloat(templateID, "atkrange"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE, StaticMonster.Instance().getFloat(templateID, "truedamage"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST, StaticMonster.Instance().getFloat(templateID, "truedgresist"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_HITREGEN, StaticMonster.Instance().getFloat(templateID, "hitregen"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK, StaticMonster.Instance().getFloat(templateID, "lifesteak"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_RECOVERY, StaticMonster.Instance().getFloat(templateID, "recovery"));
		add2Dict((int)GlobalDef.NewHeroProperty.PRO_AIID,     StaticMonster.Instance ().getFloat (templateID, "aiid"));

//		baseProperty.Add((int)GlobalDef.NewHeroProperty.PRO_DODSKILL1,  StaticMonster.Instance ().getFloat (templateID, "dodskill1"));
//		baseProperty.Add((int)GlobalDef.NewHeroProperty.PRO_DODSKILL2,  StaticMonster.Instance ().getFloat (templateID, "dodskill2"));
//		baseProperty.Add((int)GlobalDef.NewHeroProperty.PRO_RUNAWAY_HP1,StaticMonster.Instance ().getFloat (templateID, "escape_hp1"));
//		baseProperty.Add((int)GlobalDef.NewHeroProperty.PRO_RUNAWAY_HP1,StaticMonster.Instance ().getFloat (templateID, "escape_hp2"));

		//更新结果数值
		for(int i = 0; i < baseProperty.Count; i++)
		{
			int key = baseProperty.ElementAt(i).Key;
			float value = baseProperty.ElementAt(i).Value;
			if(resProperty.ContainsKey(key))
			{
				resProperty[key] = value;
				continue;
			}
			resProperty.Add(key, value);
		}
	}
	public void OutPut()
	{
		for(int i = 0; i < baseProperty.Count; i++)
		{
			Debug.Log("base " + i + " key:" + baseProperty.ElementAt(i).Key + " value:"+ baseProperty.ElementAt(i).Value);
		}
		for(int i = 0; i < resProperty.Count; i++)
		{
			Debug.Log("base " + i + " key:" + resProperty.ElementAt(i).Key + " value:"+ resProperty.ElementAt(i).Value);
		}
	}
}
