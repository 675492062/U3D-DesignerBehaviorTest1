using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeroManager : MonoBehaviour
{
	Dictionary<long, HeroData> heroDict = new Dictionary<long, HeroData>(); //所有英雄列表
	public Dictionary<long, HeroData> getHeroDict(){ return  heroDict; }

	public bool isDirty{get; set;}
	public int curSelectHero{get; set;}
	public long curSelectHeroGUID{get; set;}
	public int curShowEquipType{get; set;}
	public FightHeroList fightHeroList{ get; set;}
	

	void Update(){
		foreach(HeroData heroData in heroDict.Values){
			heroData.bufferController.Update();
			heroData.skillList.Update();
		}
	}
	/// <summary>
	/// Clear this instance.
	/// </summary>
	public void clear()
	{
		heroDict.Clear();
		curSelectHero = 0;
	}

	public HeroManager()
	{
		isDirty = false;
		fightHeroList = new FightHeroList ();
//        addTempHero();
	}

	public int getCount()
	{
		return heroDict.Count;
	}
	public void addTempHero()
	{
        for (int i = 0; i < 10; i++)
        {
            HeroData hero = new HeroData();
			hero.level = 50;
			hero.equipmentList.addTempItem();
            hero.templateID = 100001 + i;
//			if( hero.templateID == 100002 )
//				hero.templateID = 100017;
            hero.guid = (long)1111111 + i;
            hero.parseData(hero.templateID);
			hero.property.country = i + 1 ;
			hero.activate = true;
            hero.battle = i;
            addHero(hero.guid, hero);
			hero.refreshProperty();
            fightHeroList.setFightHero(hero.battle, hero.guid);

//			float minAtk = hero.getMinAttack();
//			float maxAtk = hero.getMaxAttack();
//			float armor = hero.getArmor();
//			float hitLv = hero.getHitLv();
//			float dodLv = hero.getDodgelv();
//			float criticallv = hero.getCriticallv();
//			float criticalDamage = hero.getCriticalDamage();
//			float trueDamage = hero.getRealAttack();
//			float trueDamageReduce = hero.getReduceRealAttack();
//
//			float damageReduce = hero.getReduceDamage();
//			float hitRate = hero.getHitRate();
//			float dodRate = hero.getDodgeRate();
//			float criticalRate = hero.getCriticalRate();
//
////			float normalDamage =  
//
//			int a = 0;


            //Debug.Log(" ----------------------"+fightHeroList.getFightHeroDict().Count);
        }

//		for (int i = 0; i < 3; i++)
//		{
//			HeroData hero = new HeroData();
//			hero.templateID = 100001 + i;
//			hero.guid = (long)22222 + i;
//			hero.parseData(hero.templateID);
//			hero.property.country = i + 1 ;
//			addHero(hero.guid, hero);
//		}
		isDirty = true;
	}
	/// <summary>
	/// 添加英雄
	/// </summary>
	/// <param name="guid">GUID.</param>
	/// <param name="data">Data.</param>
	public void addHero(long guid, HeroData data)
	{
		if(heroDict.ContainsKey(guid))
		{
			Debug.LogError("already has this hero! guid: " + guid);
			return;
		}
		heroDict.Add (guid, data);
	}
	/// <summary>
	/// 删除英雄
	/// </summary>
	/// <param name="guid">GUID.</param>
	/// <param name="data">Data.</param>
	public void removeHero(long guid, HeroData data)
	{
		if(!heroDict.ContainsKey(guid))
		{
			Debug.LogError("have not this hero! guid: " + guid);
			return;
		}
		heroDict.Remove(guid);
	}
	/// <summary>
	/// 获取IDX
	/// </summary>
	public int getIdxByGUID(long guid)
	{
		for(int i = 0; i < heroDict.Count; i++)
		{
			if(heroDict.ElementAt(i).Key == guid)
				return i;
		}
		return -1;
	}
	/// <summary>
	/// 获取英雄
	/// </summary>
	/// <returns>The hero.</returns>
	/// <param name="guid">GUID.</param>
	public HeroData getHero(long guid)
	{
		if(!heroDict.ContainsKey(guid))
		{
//			Debug.LogError("have not this hero! guid: " + guid);
			return null;
		}
		return heroDict[guid];
	}
	/// <summary>
	/// 获取英雄
	/// </summary>
	/// <returns>The hero.</returns>
	/// <param name="guid">GUID.</param>
	public HeroData getCurShowHero()
	{
		if(curSelectHero < 0 || curSelectHero >= heroDict.Count)
		{
			//Debug.LogError("you have not selected any hero! curIdx:  " + curSelectHero);
			return null;
		}
		return heroDict.ElementAt(curSelectHero).Value;
	}
	/// <summary>
	/// 获取英雄 通过索引
	/// </summary>
	/// <returns>The hero.</returns>
	/// <param name="guid">GUID.</param>
	public HeroData getHeroByIdx(int idx)
	{
		if(idx < 0 || idx >= heroDict.Count)
		{
			Debug.LogError("idx out range! idx: " + idx);
			return null;
		}
		return heroDict.ElementAt(idx).Value;
	}

	//calc fight num
	/// <summary>
	/// 计算英雄攻击力
	/// </summary>
	/// <returns>The attack.</returns>
	/// <param name="hero">Hero.</param>
	public int calcAttack(HeroData hero)
	{
		int res = (int)Random.Range( hero.getMinAttack(), hero.getMaxAttack());
		return res;
	}
	/// <summary>
	/// 计算普通攻击伤害
	/// </summary>
	/// <returns>The normal attack.</returns>
	/// <param name="atk">Atk.</param>
	/// <param name="self">Self.</param>
	/// <param name="other">Other.</param>
	public int calcNormalAttack(int atk, HeroData self, HeroData other)
	{
		float res = (atk - other.getArmor())  + self.getRealAttack() - other.getReduceRealAttack();
		return (int)res;
	}
	/// <summary>
	/// 计算使用技能伤害
	/// </summary>
	/// <returns>The skill attack.</returns>
	/// <param name="atk">Atk.</param>
	/// <param name="self">Self.</param>
	/// <param name="other">Other.</param>
	public int calcSkillAttack(int atk, HeroData self,HeroData other)
	{
		int skill = 1;
		float res = (atk - other.getArmor()) * skill /100 + (self.getRealAttack() - other.getReduceRealAttack());
		return (int)res;
	}
	/// <summary>
	/// Calculates the dodge.
	/// </summary>
	/// <returns>The dodge.</returns>
	/// <param name="src">Source.</param>
	/// <param name="target">Target.</param>
	public int calcDodge(HeroData src,HeroData target)
	{
		int offset = target.level - src.level;
		if(offset <= 0) offset = 0;
		if(offset >= 10) offset = 10;
		
		float a = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_b;
		float c = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_c;
		float falloff = a * Mathf.Pow(target.level, 2) + b * target.level + c;

		float param_a = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_b;
		float res = ((target.getDodgelv() - src.getHitLv()) * param_a + param_b) / 10000*100*falloff/1000;
		return (int)res;
	}
	/// <summary>
	/// Calculates the critical.
	/// </summary>
	/// <returns>The critical.</returns>
	/// <param name="src">Source.</param>
	/// <param name="target">Target.</param>
	public int calcCritical(HeroData src,HeroData target)
	{
		int offset = target.level - src.level;
		if(offset <= 0) offset = 0;
		if(offset >= 10) offset = 10;
		
		float a = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_a;
		float c = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_a;
		float falloff = a * Mathf.Pow(target.level, 2) + b * target.level + c;

		float param_a = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_b;
		float res = ((src.getCriticallv() - target.getTenacitylv()) * a + b) / 10000*100*falloff;
		return (int)res;
	}
	/// <summary>
	/// Calculates the normal critical attack.
	/// </summary>
	/// <returns>The normal critical attack.</returns>
	/// <param name="atk">Atk.</param>
	/// <param name="src">Source.</param>
	/// <param name="target">Target.</param>
	public int calcNormalCriticalAttack(int atk,HeroData src,HeroData target)
	{
		float res = (atk - target.getArmor())*2 + (src.getRealAttack() - target.getReduceRealAttack());
		return (int)res;
	}
	/// <summary>
	/// Calculates the attack critical attack.
	/// </summary>
	/// <returns>The attack critical attack.</returns>
	/// <param name="atk">Atk.</param>
	/// <param name="src">Source.</param>
	/// <param name="target">Target.</param>
	public int calcAttackCriticalAttack(int atk, HeroData src,HeroData target)
	{
		int skill = 1;
		float res = (atk - target.getArmor()) * skill * 2 + (src.getRealAttack() - target.getReduceRealAttack());
		return (int)res;
	}
	public HeroData getFightHeroByIdx(int idx)
	{
		long guid = fightHeroList.getGuidByKey (idx); //队长
		if(guid > 0)
		{
			return getHero(guid);
		}
		return null;
	}

//	public HeroData getCenterHero()
//	{
//		long guid = fightHeroList.getGuidByKey (0); //队长
//		if(guid > 0)
//		{
//			return getHero(guid);
//		}
//		return null;
//	}
//	public HeroData getLeftHero()
//	{
//		long guid = fightHeroList.getGuidByKey (1); //第一个
//		if(guid > 0)
//		{
//			return getHero(guid);
//		}
//		return null;
//	}
//	public HeroData getRightHero()
//	{
//		long guid = fightHeroList.getGuidByKey (2);// 第二个
//		if(guid > 0)
//		{
//			return getHero(guid);
//		}
//		return null;
//	}
}
