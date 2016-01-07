using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeroRealm 
{
	public 	HeroRealm()
	{
		isDirty = true;
		curRealmLevel = 0;
		addRealmNum ();
	}
	public 	void setTemplateID(int heroTemplateID)
	{
		templateID = heroTemplateID;
	}
	public int templateID;
	public int curRealmLevel{ get; set;}   // 当前的境界等级
	public bool isDirty{ get; set;}        // 是否需要更新
	protected Dictionary<int, int> realmEffectPro = new Dictionary<int, int> (); //境界影响得属性列表

	//每页显示几个点
	Dictionary<int, int> realmNum = new Dictionary<int, int>();
	public Dictionary<int, int> getRealmNumDic(){ return  realmNum; }
	public void addRealmNum()
	{
		realmNum.Add (1,3);
		realmNum.Add (2,4);
		realmNum.Add (3,4);
		realmNum.Add (4,4);
		realmNum.Add (5,4);
		realmNum.Add (6,4);
		realmNum.Add (7,4);
		realmNum.Add (8,4);
		realmNum.Add (9,4);
		realmNum.Add (10,4);
		realmNum.Add (11,4);
		realmNum.Add (12,4);
		realmNum.Add (13,4);
		realmNum.Add (14,4);
		realmNum.Add (15,4);

		realmEffectPro.Add(0,100);
		realmEffectPro.Add(1,200);
	}
	public Dictionary<int, int> getRealmEffectDic()
	{ 
		return realmEffectPro; 
	}

	public void refreshEffectPro()
	{
		for(int i = 0; i < curRealmLevel; i++)
		{
			string key = ""+templateID+"_" + i;
			int life = StaticRealmpoint.Instance().getInt(key, "life");
			int attack = StaticRealmpoint.Instance().getInt(key, "attack");
			int defence = StaticRealmpoint.Instance().getInt(key, "defence");
			int hit = StaticRealmpoint.Instance().getInt(key, "hit");
			int critical = StaticRealmpoint.Instance().getInt(key, "critical");
			int dodge = StaticRealmpoint.Instance().getInt(key, "dodge");
			int tenacity = StaticRealmpoint.Instance().getInt(key, "tenacity");
			if(life != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_LIFE, life);
			}
			if(attack != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_ATTACK, attack);
			}
			if(defence != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_DEFENCE, defence);
			}
			if(hit != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_HITLV, hit);
			}
			if(critical != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_CRITICALLV, critical);
			}
			if(dodge != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_DODGELV, dodge);
			}
			if(tenacity != 0)
			{
				realmEffectPro.Add((int)GlobalDef.HeroProperty.PRO_TENACITY, tenacity);
			}
		}
	}


	public int curPage() // 获取当前是第几页
	{
		int page = 0;
		int temp = curRealmLevel;
		for(int i = 0; i < realmNum.Count; i++)
		{
			if(temp >= realmNum.ElementAt(i).Value)
			{
				temp -= realmNum.ElementAt(i).Value;
				page++;
			}
			else 
			{
				break;
			}
		}
		return page;
	}
	public int curStarIdx()
	{
		int temp = curRealmLevel;
		for(int i = 0; i < realmNum.Count; i++)
		{
			if(temp >= realmNum.ElementAt(i).Value)
			{
				temp -= realmNum.ElementAt(i).Value;
			}
			else 
			{
				break;
			}
		}
		return temp;
	}
	public int getLevelByIdx(int idx)
	{
		int page = curPage();
		int pageStartLevel = 0;
		for(int i = 0; i < page; i++)
		{
			pageStartLevel += realmNum.ElementAt(i).Value;
		}
		return pageStartLevel + idx;
	}
}