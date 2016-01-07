using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroProperty 
{
	/// <summary>
	/// 基础属性容器
	/// </summary>
	Dictionary<int, float> baseProperty = new Dictionary<int, float> ();

	public float getPro(int type)
	{
		if(baseProperty.ContainsKey(type))
		{
			return  baseProperty[type];
		}
		return 0;
	}

	public int country;           			  //国家 势力


	public void parseData(int templateid)
	{
		baseProperty.Clear ();
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_1,   StaticHero.Instance ().getFloat (templateid, "lifegrowth_1"));
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1, StaticHero.Instance ().getFloat (templateid, "attackgrowth_1"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_1,  StaticHero.Instance ().getFloat (templateid, "armorgrowth_1"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_2,   StaticHero.Instance ().getFloat (templateid, "lifegrowth_2"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_2, StaticHero.Instance ().getFloat (templateid, "attackgrowth_2"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_2,  StaticHero.Instance ().getFloat (templateid, "armorgrowth_2"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_3,   StaticHero.Instance ().getFloat (templateid, "lifegrowth_3"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_3, StaticHero.Instance ().getFloat (templateid, "attackgrowth_3"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_3,  StaticHero.Instance ().getFloat (templateid, "armorgrowth_3"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_4,   StaticHero.Instance ().getFloat (templateid, "lifegrowth_4"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_4, StaticHero.Instance ().getFloat (templateid, "attackgrowth_4"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_4,  StaticHero.Instance ().getFloat (templateid, "armorgrowth_4"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_5,   StaticHero.Instance ().getFloat (templateid, "lifegrowth_5"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_5, StaticHero.Instance ().getFloat (templateid, "attackgrowth_5"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_5,  StaticHero.Instance ().getFloat (templateid, "armorgrowth_5"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT	, StaticHero.Instance ().getFloat (templateid, "init_lifepoint"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATTACK		, StaticHero.Instance ().getFloat (templateid, "init_attack"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ARMOR		, StaticHero.Instance ().getFloat (templateid, "init_armor"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT	, StaticHero.Instance ().getFloat (templateid, "init_manapoint"));
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT_NUM	, StaticHero.Instance ().getFloat (templateid, "init_mana"));
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MANAGETPT	, StaticHero.Instance ().getFloat (templateid, "init_managetpt"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MANAHITPT	, StaticHero.Instance ().getFloat (templateid, "init_manahitpt"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MANARVRPT	, StaticHero.Instance ().getFloat (templateid, "init_manarvrpt"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER	, StaticHero.Instance ().getFloat (templateid, "init_movepower"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MOVECD		, StaticHero.Instance ().getFloat (templateid, "init_movecd"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_HITLV		, StaticHero.Instance ().getFloat (templateid, "init_hitlv"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_DODGELV	, StaticHero.Instance ().getFloat (templateid, "init_dodgelv"));		
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV	, StaticHero.Instance ().getFloat (templateid, "init_criticallv"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV, StaticHero.Instance ().getFloat (templateid, "init_tenacitylv"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE, StaticHero.Instance ().getFloat (templateid, "init_critical_damage"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_ATKSPD		, StaticHero.Instance ().getFloat (templateid, "init_atkspd"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD		, StaticHero.Instance ().getFloat (templateid, "init_movspd"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_WALKSPD	, StaticHero.Instance ().getFloat (templateid, "init_walkspd"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE	, StaticHero.Instance ().getFloat (templateid, "init_truedamage"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST, StaticHero.Instance ().getFloat (templateid, "init_truedgresist"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_HITREGEN	, StaticHero.Instance ().getFloat (templateid, "init_hitregen"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_KILLREGEN	, StaticHero.Instance ().getFloat (templateid, "init_killregen"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK	, StaticHero.Instance ().getFloat (templateid, "init_lifesteak"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_RECOVERY	, StaticHero.Instance ().getFloat (templateid, "init_recovery"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT	,50);	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_AIID	,   StaticHero.Instance ().getFloat (templateid, "aiid"));	
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MP_GETSEL ,StaticHero.Instance ().getFloat (templateid, "init_managetpt"));  //初始MP自我获取
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MP_GETHIT ,StaticHero.Instance ().getFloat (templateid, "init_manarvrpt"));  //初始MP被击获取
		baseProperty.Add ((int)GlobalDef.NewHeroProperty.PRO_MP_GETAUTO,StaticHero.Instance ().getFloat (templateid, "init_manarvrpt"));  //初始MP自动回复
	}

}
