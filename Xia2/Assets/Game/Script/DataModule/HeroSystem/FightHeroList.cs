using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class FightHeroList
{
	Dictionary<int, long> fightHero = new Dictionary<int, long>(); //出战英雄列表
	public Dictionary<int, long> getFightHeroDict(){ return  fightHero; }
	public bool isDirty = false;
	public bool []isDirtyModel = new bool[(int)GlobalDef.MAXFIGHTHERONUM];//记录需要更换装备的标志
	public bool updateMenuModel = true; //更新主界面模型  

	public int curFightIdx{ get; set;}
	public FightHeroList()
	{
		for(int i = 0; i < isDirtyModel.Length; i++)
		{
			isDirtyModel[i] = true;
		}
	}

    /// <summary>
    /// 开始战斗
    /// </summary>
    public void initHeros()
    {
        foreach (HeroData hero in getHeros())
        {
            hero.init();
        }
    }

	public void setFightHero(int idx, long guid)
	{
		if(fightHero.ContainsKey(idx))
		{
			cancelFightHeroByGUID(guid); //先清除旧位置
			cancelFightHero(idx);        //再替换新位置
			fightHero[idx] = guid;
			isDirtyModel[idx] = true;
			HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
			if(null == data)
			{
				return;
			}
			data.battle = idx;
			return;
		}

		fightHero.Add (idx, guid);
		HeroData hero = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(null == hero)
		{
			return;
		}
		hero.battle = idx;
	}
	public void cancelFightHero(int idx)
	{
		if(!fightHero.ContainsKey(idx))
		{
			return;
		}
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (fightHero[idx]);
		if(null == data)
		{
			return;
		}
		isDirtyModel [data.battle] = true;
		data.battle = -1;
		fightHero.Remove (idx);
	}
	public void cancelFightHeroByGUID(long guid)
	{
		for(int i = 0; i < fightHero.Count; i++)
		{
			if(fightHero.ElementAt(i).Value == guid)
			{
				isDirtyModel[fightHero.ElementAt(i).Key] = true;
				fightHero.Remove (fightHero.ElementAt(i).Key);
			}
		}
	}
	public int getIdxByGuid(long guid)
	{
		for(int i = 0; i < fightHero.Count; i++)
		{
			if(fightHero.ElementAt(i).Value == guid)
			{
				return i;
			}
		}
		return -1;
	}
	public long getGuidByKey(int key)
	{
		if(fightHero.ContainsKey(key))
		{
			return fightHero[key];
		}
		return -1;
	}
	public void removeByGuid(long guid)
	{
		for(int i = 0; i < fightHero.Count; i++)
		{
			if(fightHero.ElementAt(i).Value == guid)
			{
				isDirtyModel[fightHero.ElementAt(i).Key] = true;
				fightHero.Remove(fightHero.ElementAt(i).Key);
				return;
			}
		}
	}
	public void clear()
	{
		fightHero.Clear ();
	}
	public bool hasKey(int key)
	{
		return fightHero.ContainsKey (key);
	}

    public HeroData getHeroData(int battleIndex)
    {
        if (battleIndex >= fightHero.Count) return null;
		if (!fightHero.ContainsKey (battleIndex))
			return null;
        HeroData data = MonoInstancePool.getInstance<HeroManager>().getHero(fightHero[battleIndex]);
        return data;
    }

    public List<HeroData> getHeros()
    {
        List<HeroData> heros = new List<HeroData>();
        for (int i = 0; i < fightHero.Count; i++)
        {
			if( !fightHero.ContainsKey(i) )
				continue;
            heros.Add(MonoInstancePool.getInstance<HeroManager>().getHero(fightHero[i]));
        }
        //Debug.Log(heros.Count + "-----------");
        return heros;
    }

    /// <summary>
    /// 是否有此英雄
    /// </summary>
    /// <returns></returns>
    public bool hasHeroTemplateId(int templateID)
    {
        foreach (HeroData d in getHeros())
        {
            if (d.templateID == templateID) return true;
        }
        return false;
    }
}
