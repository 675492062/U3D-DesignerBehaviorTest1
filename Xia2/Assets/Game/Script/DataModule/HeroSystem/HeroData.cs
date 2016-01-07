using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class HeroData 
{
	public HeroData()
	{
		property = new HeroProperty ();
        equipmentList = new EquipmentList();
        realmList = new HeroRealm();
		skillList = new SkillManager();
		bufferController = new BufferController();
		battle = -1;
        level = 1;
	}

	public long guid{get; set;}             // 唯一ID
	public bool activate{get; set;}         // 是否被激活
	public int templateID{get; set;}        // 模板ID
	public int type{get; set;}              // 类型
	public EquipmentList equipmentList{ get; set;} // 装备列表
	public HeroProperty property{get; set;} // 属性列表
	public HeroRealm realmList{get; set;}   // 境界
	public int level{get; set;}             // 等级
	public int starLevel{ get; set;}        // 星级
	public int exp{get; set;}               // 经验
	public SkillManager skillList;          // 技能列表
	public BufferController bufferController;//buffer管理
	
    //TODO: 最后一级设定
    public int expByNextLv { get { return StaticLevel.Instance().getInt(level, "exp"); } }
    private HeroStar mHeroStar = new HeroStar();
    public HeroStar infoStar
    {
        get 
        {
            mHeroStar.Refresh(starLevel);
            return mHeroStar;
        }
    }

	public int debris{get; set;}            // 碎片个数
    /// <summary>
    /// 出战位置 0 ， 1 ， 2 ,3 4, 5, 6, 
    /// </summary>
	public int battle{ get; set;}           // 出战位置
	public int fighting{ get; set;}         // 战斗力
    public string name { get; set; }        // 名字
	public int heroType{get; set;}          // 英雄类型
	public string icon { get; set; }        // 默认 
	public string icon_gray { get; set; }   // 灰色 
	public string icon_circle { get; set; } // 圆形图标 
	public string icon_body { get; set; }   // 半身像
	public string icon_middle { get; set; } // 
	public string icon_middle_gray { get; set; }// 半身像
    public string resname { get; set; }     // 资源名字
	public string description{ get; set;}   // description
	public int    modelsize{ get; set;}		// model pool type
	public int	  whoop_type{ get; set;}	// whoop type

	Dictionary<int, int>   effectProNum = new Dictionary<int, int>();          //属性加成 数值
	Dictionary<int, float> effectProPercent = new Dictionary<int, float>();    //属性加成 百分比

	//property save 
	Dictionary<int, float> resProNum = new Dictionary<int, float>();         //属性数值
	Dictionary<int, float> curProNum = new Dictionary<int, float>();         //属性数值
	Dictionary<int, float> addPercent = new Dictionary<int, float>();        //加成百分比数值
	Dictionary<int, float> addRealNum = new Dictionary<int, float>();        //加成数目数值
	public Dictionary <int, StateParams> state = new Dictionary<int, StateParams>();

	public void parseData(int templateid)
	{
        templateID = templateid;
		realmList.setTemplateID(templateid);
		heroType = StaticHero.Instance().getInt(templateid,"hero_type");
//		type = StaticHero.Instance().getInt(templateid,"hero_type");
        name = StaticHero.Instance().getStr(templateid, "name");    		//name
        resname = StaticHero.Instance().getStr(templateid, "resname");      //
		description = StaticHero.Instance ().getStr (templateid, "description");
		icon = StaticHero.Instance().getStr(templateid, "icon");       		//icon1
		icon_gray = StaticHero.Instance().getStr(templateid, "icon_gray");  //icon2
		icon_circle = StaticHero.Instance().getStr(templateid, "icon_circle");//icon3
		icon_body = StaticHero.Instance().getStr(templateid, "icon_body");  //icon4
		icon_middle = StaticHero.Instance ().getStr (templateid, "icon_middle");
		icon_middle_gray = StaticHero.Instance ().getStr (templateid,"icon_middle_gray");
		int init_star = StaticHero.Instance().getInt(templateid,"init_star");
		if(starLevel <= 0)
		{
			starLevel = init_star;
		}
		modelsize = StaticHero.Instance().getInt(templateid, "modelsize");  //modelsize
		property.country         = StaticHero.Instance ().getInt (templateid, "force");          //势力
		whoop_type			     = StaticHero.Instance().getInt(templateid,"whoop_type"); //whoop type

		property.parseData (templateid);//

        init();
	}

    public void init()
    {
        for (int i = 1; i <= 4; i++)
        {
            int skillId = StaticHero.Instance().getInt(templateID, "init_skillid" + i);
            if (skillId == 0)
                continue;
            SkillItem skill = new SkillItem(this, skillId);
			skillList.Add(skill);
        }
		for(int i = 0; i < 3; i++)
		{
			skillList.useSkills[i] = i;
		}

		//updateProperty
		refreshProperty ();
		refreshCurPorperty ();
    }

	/// 计算英雄HP
	public float getMaxHP()
	{
		float basehp = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		int star = (starLevel-1) < 0 ? 0 : starLevel;
		float growth = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_1 + star*3);
		float res = (basehp + (level * growth*40)) * (100 + percent) / 100  + num;
		return res;
	}
	//能量
	public float getMaxEnergy()
	{
		float res = (property.getPro ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER));
		return res;
	}
	/// 计算最小攻击力
	public float getMinAttack()
	{
		float res = 0;
		int a = 1;
		float initAttack = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACK);
		int star = (starLevel-1) < 0 ? 0 : starLevel;
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		float growth = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1 + star*3);
		res = (initAttack + level * growth)* ( 100 + percent)/100 + num;
		return res;
	}
	/// 计算最大攻击力
	public float getMaxAttack()
	{
		float res = 0;
		int a = 1;
		float initAttack = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACK);
		int star = (starLevel-1) < 0 ? 0 : starLevel;
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		float growth = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1 + star*3);
		res = (initAttack + level * growth)* ( 100 + percent)/100 + num;
		return res;
	}
	/// 计算护甲
	public float getArmor()
	{
		float res = 0;
		int a = 1;
		float initArmor = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		int star = (starLevel-1) < 0 ? 0 : starLevel;
		float growth = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_1 + star*3);
		res = ( initArmor + level * growth ) * (100 + percent) / 100 + num;
		return res;
	}
	/// 计算爆击等级
	public float getCriticallv()
	{
		float res = 0;
		int a = 1;
		float initCri = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);

		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);
		res = initCri * (100 + percent )/100 + num;
		return res;
	}
	/// 计算爆击伤害
	public float getCriticalDamage()
	{
		float res = 0;
		int a = 1;
		float initCri = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE);
		
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE);
		res = initCri * (100 + percent )/100 + num;
		return res;
	}
	/// 计算爆击率
	public float getCriticalRate()
	{
		int   lv = level;
		float criticallv = getCriticallv ();
		
		float a = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_b;
		float c = MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_c;
		float falloff = a * Mathf.Pow(lv, 2) + b * lv + c;
		
		float param_a = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_b;
		float res = (param_a * criticallv + param_b) / 100 * falloff;
		if (res > 1) res = 1;
		if (res < 0.005f) res = 0.005f;
		return res;
	}
	/// 计算韧性
	public float getTenacitylv()
	{
		float res = 0;
		float initTen = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV);

		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV);
		res = initTen * (100 + percent)/100 + num;
		return res;
	}
	/// 计算闪避
	public float getDodgelv()
	{
		float res = 0;
		float initDod = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_DODGELV);

		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_DODGELV);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_DODGELV);
		res = initDod * (100 + percent)/100 + num;
		return res;
	}
	public float getDodgeRate()
	{
		float lv = level;
		float dodLv = getDodgelv ();
		
		float a = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_b;
		float c = MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_c;
		float falloff = a * Mathf.Pow(lv, 2) + b * lv + c;
		
		float param_a = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().crirate_coefficient_b;
		float res = (param_a * dodLv + param_b) / 100 * falloff;
		if (res > 1) res = 1;
		if (res < 0.005f) res = 0.005f;
		return res;
	}
	/// 计算命中等级
	public float getHitLv()
	{
		float res = 0;
		float initHit = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_HITLV);

		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_HITLV);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_HITLV);
		res = initHit * (100 + percent)/100 + num;
		return res;
	}
	public float getHitRate()
	{
		float lv = level;
		float dodLv = getHitLv ();
		
		float a = MonoInstancePool.getInstance<MathParam>().hit_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().hit_attenuation_coefficient_b;
		float c = MonoInstancePool.getInstance<MathParam>().hit_attenuation_coefficient_c;
		float falloff = a * Mathf.Pow(lv, 2) + b * lv + c;
		
		float param_a = MonoInstancePool.getInstance<MathParam>().hitrate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().hitrate_coefficient_b;
		float res = (param_a * dodLv + param_b) / 100 * falloff;
		if (res > 1) res = 1;
		if (res < 0.005f) res = 0.005f;
		return res;
	}
	/// 计算无双段
	public float getManapoint()
	{
		float res = 0;
		float initMan = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);

		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
		res = initMan * (100 + percent)/100 + num;
		return res;
	}
	/// 计算攻击速度
	public float getAttackSpeed()
	{
		float res = 0;
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_ATKSPD);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_ATKSPD);
		res = (float)property.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATKSPD) * 100 * (float)(1.0f + percent)/100 + num;
		res /= 100;
		return res;
	}
	/// 计算移动速度
	public float getMoveSpeed()
	{
		float res = 0;
		float initMov = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
		res = initMov * (1 + percent)/100 + num;
		return res;
	}

	/// 计算真实伤害
	public float getRealAttack()
	{
		float res = 0;
		float initRealAtk = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		res = initRealAtk * (100 + percent)/100 + num;
		return res;
	}
	/// 计算真实伤害减免
	public float getReduceRealAttack()
	{
		float res = 0;
		float initReduceRealAtk = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST);
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		res = initReduceRealAtk * (100 + percent)/100 + num;
		return res;
	}
	/// 计算伤害减免
	public float getReduceDamage()
	{
		float a = MonoInstancePool.getInstance<MathParam>().armor_attenuation_coefficient_a;
		float b = MonoInstancePool.getInstance<MathParam>().armor_attenuation_coefficient_b;
		float c = MonoInstancePool.getInstance<MathParam>().armor_attenuation_coefficient_c;
		float param_a = MonoInstancePool.getInstance<MathParam>().armorrate_coefficient_a;
		float param_b = MonoInstancePool.getInstance<MathParam>().armorrate_coefficient_b;

		float armor = getArmor ();
		float res = (param_a * armor + param_b) * (a * Mathf.Pow (level, 2) + b * level + c);
		return res;
	}
	/// Gets the hitregen.
	public float getHitregen()
	{
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_HITREGEN);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_HITREGEN);
		float res = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_HITREGEN) * (100 + percent) /100 + num;
		return res;
	}
	/// Gets the killregen.
	public float getKillregen()
	{
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_KILLREGEN);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_KILLREGEN);
		float res = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_KILLREGEN) * (100 + percent) /100 + num;
		return res;
	}
	/// Gets the lifesteak.
	public float getLifesteak()
	{
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK);
		float res = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK) * (100 + percent) /100 + num;
		return res;
	}
	/// Gets the recovery.
	public float getRecovery()
	{
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_RECOVERY);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_RECOVERY);
		float res = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_RECOVERY) * (100 + percent) /100 + num;
		return res;
	}

	/// Gets the HardStraight
	public float getHardStraight()
	{
		float percent = getAddEffectPercent((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT);
		float num = getAddEffectNum((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT);
		float res = property.getPro ((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT) * (100 + percent) /100 + num;
		return res;
	}

	public void refreshProperty()
	{
		effectProPercent.Clear ();
		effectProNum.Clear ();

		refreshWeaponEffect ();
		refreshRealmEffect ();
		refreshBufEffect ();
		refreshResValues ();
	}
	public void addPro2Dict(int type, float value)
	{
		if (resProNum.ContainsKey (type)) 
		{
			resProNum[type] = value;
			return;
		}
		resProNum.Add (type, value);
	}
	public void refreshResValues ()
	{
		for(int i = 0; i < (int)GlobalDef.NewHeroProperty.MAX; i++)
		{
			addPro2Dict(i, property.getPro(i));
		}

		//默认添加上各种影响属性
		defaultAddEffectProperty ();

		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT, getMaxHP ());
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_MINATTACK, getMinAttack()); 
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_MAXATTACK, getMaxAttack()); 
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_ATTACK, Random.Range( getMinAttack(), getMaxAttack()));//攻击力
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_ARMOR,getArmor());                  //护甲
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_MANAPOINT,getManapoint());          //无双段 mp
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_ATKSPD, getAttackSpeed());          //攻击速度
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_MOVSPD,getMoveSpeed());             //移动速度
		addPro2Dict( (int)GlobalDef.NewHeroProperty.PRO_CRITICALLV,getCriticallv());        //爆击等级
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_HITLV, getHitLv ());                //命中等级
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_HITREGEN, getHitregen());  
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_KILLREGEN, getKillregen());
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK, getLifesteak());
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_RECOVERY, getRecovery());
//		truedamage =              				//真是伤害
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_DODGELV, getDodgelv());             //闪避等级
//		dodgerare = ;              				//闪避几率
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV, getTenacitylv());       //韧性等级
//		tenacityrare;           	//韧性几率
//		tenacity =;                 //韧性程度
//		truedgresist ;           	//真实伤害
//		hrecoverrare;           	//硬直几率
//		htrecoverdmg ;           	//硬直伤害
		addPro2Dict ((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT, getHardStraight());

	}
	public void defaultAddEffectProperty()
	{
		for(int i = 0; i < effectProNum.Count; i++)
		{
			int key = effectProNum.ElementAt(i).Key;
			if( resProNum.ContainsKey(key) ) 
			{
				resProNum[key] += effectProNum[key];
			}
		}
		for(int i = 0; i < effectProPercent.Count; i++)
		{
			int key = effectProPercent.ElementAt(i).Key;
			if( effectProPercent.ContainsKey(key) ) 
			{
				resProNum[key] += property.getPro(key) * effectProPercent[key];
			}
		}
	}

	public void refreshCurPorperty()
	{
		curProNum.Clear ();
		for(int i = 0; i < (int)GlobalDef.NewHeroProperty.MAX; i++)
		{
			if(!curProNum.ContainsKey(i))
			{
				curProNum.Add(i,resProNum[i]);
			}
			else 
			{
				curProNum[i] = resProNum[i];
			}
//			if(i == (int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER)
//			{
//				float a = curProNum[i];
//				float b = resProNum[i];
//			}
		}
	}
	public float getResPro(int type)
	{
		if(resProNum.ContainsKey(type))
		{
			return resProNum[type];
		}
		return 0;
	}
	public void setResPro(int type, int value)
	{
		if(resProNum.ContainsKey(type))
		{
			resProNum[type] = value;
		}
	}
	public float getCurPro(int type)
	{
		if(curProNum.ContainsKey(type))
		{
			return curProNum[type];
		}
		return 0;
	}
	public void setCurPro(int type, float value)
	{
		if(curProNum.ContainsKey(type))
		{
			curProNum[type] = value;
		}
	}
	/// Refreshs the weapon effect.
	public void refreshWeaponEffect()
	{
		int count = equipmentList.getCountEquipment ();

//		for(int i = 0; i < count; i++)
//		{
//			EquipmentItem item = equipmentList.getItemByIdx(i);
//			if(null == item)
//			{
//				continue;
//			}
//			Dictionary<int, int> property = item.getAddProDict();
//			for(int j = 0; j < property.Count; j++)
//			{
//				int id = property.ElementAt(j).Key;
//				int value = property.ElementAt(j).Value;
//				addEffectProNum( id, value);
//			}
//		}
	}
	
	public void refreshBufEffect(){
		List<AttrTimeBuffer> buffers = bufferController.FindAttrBuffers ();
		for (int i = 0; i < buffers.Count; i++) {
			AttrTimeBuffer buff = buffers[i];		
			if( buff == null )
				continue;
			int heroProId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buff.id);
			if(heroProId == -1){
				continue;
			}

			if(buff.addNum != 0)
			{
				addEffectProNum( heroProId, buff.addNum);
			}
			if (buff.addPercent != 0)
			{
				addEffectProPercent( heroProId, buff.addPercent);
			}
		}
	}

	public void refreshRealmEffect()
	{
//		realmList.refreshEffectPro ();
//		Dictionary<int, int> property = realmList.getRealmEffectDic();
//		for(int i = 0; i < property.Count; i++)
//		{
//			int id = property.ElementAt(i).Key;
//			int value = property.ElementAt(i).Value;
//			addEffectProNum(id, value);
//		}
	}
	public void addEffectProNum(int type, int num)
	{
		if(effectProNum.ContainsKey(type))
		{
			effectProNum[type] += num;
		}
		else
		{
			effectProNum.Add(type, num);
		}
	}
	public void addEffectProPercent(int type, float num)
	{
		if(effectProPercent.ContainsKey(type))
		{
			effectProPercent[type] += num;
		}
		else
		{
			effectProPercent.Add(type, num);
		}
//		Debug.LogError ("----- type" + type + "===" + effectProPercent [type]);
	}
	public float getAddEffectPercent(int type)
	{
		if(effectProPercent.ContainsKey(type))
		{
			return effectProPercent[type];
		}
		return 0f;
	}
	public float getAddEffectNum(int type)
	{
		if(effectProNum.ContainsKey(type))
		{
			return effectProNum[type];
		}
		return 0f;
	}

	public void outputResult()
	{
		string temp = "";
		temp += "hp: " + getMaxHP() + "\n";
		temp += "hp: " + getMinAttack() + "\n";
		temp += "hp: " + getMaxAttack() + "\n";
		temp += "hp: " + getArmor() + "\n";
		temp += "hp: " + getCriticallv() + "\n";
		temp += "hp: " + getTenacitylv() + "\n";
		temp += "hp: " + getDodgelv() + "\n";
		temp += "hp: " + getHitLv() + "\n";
		temp += "hp: " + getManapoint() + "\n";
		temp += "hp: " + getAttackSpeed() + "\n";
		temp += "hp: " + getMoveSpeed() + "\n";
		temp += "hp: " + getRealAttack() + "\n";
		temp += "hp: " + getReduceRealAttack() + "\n";
		temp += "hp: " + getHitregen() + "\n";
		temp += "hp: " + getKillregen() + "\n";
		temp += "hp: " + getLifesteak() + "\n";
		temp += "hp: " + getRecovery() + "\n";
	}

    public float getPercentByHP()
    {
		float max = getResPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
//        Debug.Log(" curHp  max is " + max + " cur value is  " + curHp);
		float cur = getCurPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
        return cur * 1.0f / max;
    }

    public float getPercentByMP()
    {
		float max = getResPro((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
		float curMp = getCurPro ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
        //Debug.Log(" curMp  max is " + max + " cur value is  " + curMp);
        return curMp * 1.0f / max;
    }

    public float getPercentByEXP()
    {
        //TODO:最后一级的设定
        int max = expByNextLv;
        //Debug.Log(" exp  max is " + max + " cur value is  " + exp);
        return exp * 1.0f / max;
    }

    public float getPercentByHardStraight()
    { 
        float hardS = getCurPro((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT);
        float max = getResPro((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT);
        return hardS * 1.0f / max;
    }
    
	public float calcCriticalPercent()
	{
		return  getCriticallv() /  level;
	}


	/// <summary>
	/// 这个状态是否存在
	/// </summary>
	public bool hasState(int type)
	{
		return state.ContainsKey (type);
	}
	/// <summary>
	/// 设置状态
	/// </summary>
	public void setState(int type, StateParams param)
	{
		if(state.ContainsKey(type))
		{
			state.Remove(type);
		}
		state.Add (type,param);
	}
	/// <summary>
	/// 获取状态参数
	/// </summary>
	public StateParams getStateParam(int type)
	{
		if(state.ContainsKey(type))
		{
			return state[type];
		}
		return null;
	}
	/// <summary>
	/// 删除状态
	/// </summary>
	public void removeState(int type)
	{
		if(state.ContainsKey(type))
		{
			state.Remove(type);
		}
	}
	/// <summary>
	/// 解析从服务器接收到的数据
	/// </summary>
	public void parseServerHero(Property.Hero data)
	{
		//template Data
		parseData(data.heroid);

		guid = (long)data.guid;
		templateID = data.heroid;
		activate = data.activate;
		level = data.level;
		if(data.starLevel > starLevel ){starLevel = data.starLevel;}
		exp = data.exp;
		debris = data.debris;
		realmList.curRealmLevel = data.realm;
		battle = data.battle;
		fighting = data.fighting;

		equipmentList.clear ();
		for(int j = 0; j < data.items.Count; j++)
		{
			EquipmentItem item = new EquipmentItem();
			Property.Equip item_data = data.items[j];
			item.parseData(data.items[j]);	
			equipmentList.addItem(item.guid, item);
			
			item.gemList.Clear();
			for(int k = 0; k < item_data.gemAry.Count; k++)
			{
				DiamondItem gemItem = new DiamondItem();
				Property.Item gemData = item_data.gemAry[k];
				gemItem.guid = (long)gemData.guid;
				gemItem.templateID = (int)gemData.templateid;
				gemItem.haveNum = (int)gemData.number;
				//					gemItem.type = (int)gemData.type;
				item.gemList.Add(gemItem.guid, gemItem);
			}			
		}
		Property.Horse horse = data.horse;
		//skill
		skillList.Clear();
		skillList.clearUseSkill();
		for(int s = 0; s < data.skills.Count; s++)
		{
			Property.Skill skillData = data.skills[s];
			int skillId = skillData.skillid;
			
			SkillItem skill = new SkillItem(this, skillId);
			skill.level = skillData.level;
			skill.active = skillData.activate;
			skill.slot = skillData.slot;
			skillList.Add(skill);
			if(skill.slot != -1 && skill.slot < skillList.useSkills.Length)
			{
				skillList.useSkills[skill.slot] = s;
			}
		}
	}
	/// <summary>
	/// 计算战斗力
	/// </summary>
	public int calcFight()
	{
		float res = 0;
		float max = getResPro ((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		float min = getResPro ((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		float atk = (max + min) / 2;
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) * StaticGlobal_parameter.Instance ().getFloat (850103,"parameter");
		res += atk * StaticGlobal_parameter.Instance ().getFloat (850104,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR)     * StaticGlobal_parameter.Instance ().getFloat (850105,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT) * StaticGlobal_parameter.Instance ().getFloat (850106,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_ATKSPD)    * StaticGlobal_parameter.Instance ().getFloat (850107,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD)    * StaticGlobal_parameter.Instance ().getFloat (850108,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE)* StaticGlobal_parameter.Instance ().getFloat (850109,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST) * StaticGlobal_parameter.Instance ().getFloat (850110,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV) * StaticGlobal_parameter.Instance ().getFloat (850111,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_DODGELV) * StaticGlobal_parameter.Instance ().getFloat (850112,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_HITLV) * StaticGlobal_parameter.Instance ().getFloat (850113,"parameter");
		res += getResPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE) * StaticGlobal_parameter.Instance ().getFloat (850114,"parameter");
		for(int i = 0; i < skillList.count(); i++)
		{
			SkillItem skill = skillList.getSkillByIdx(i);
			if(skill.active)
			{
				res += skill.level * StaticGlobal_parameter.Instance ().getFloat (850115,"parameter");
			}
		}
		return (int)res;
	}
}
