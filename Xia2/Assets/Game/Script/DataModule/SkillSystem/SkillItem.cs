/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-09-25   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;


public class SkillItem : BaseItem
{
	public struct EffectParam
	{
		public int type;
		public int obj;
		public float parameter1;
		public float parameter2;
		public int   RT_effect;
		public string acceptor_effectid;
		public int   formulaid1;
	};

 
    public HeroData hero;

	public int  level{ get; set;}
	public bool active{ get; set;}
	public int  slot{ get; set;}
	public float curCD{ get; set;}
	public bool locked{ get; set;}
	public int priorityCount{ get; set;} 	 // 记录使用次数用于区分优先级，使用次数越小的优先级越高
	public SkillItemDescribe effectDescribe = new SkillItemDescribe(); // 技能效果的描述
    public SkillItem() 
	{
		level = 1;
		curCD = 0;
		priorityCount = 0;
		locked = false;
	}

    public SkillItem(HeroData heroData, int id)
    {
        this.hero = heroData;
		level = 1;
        parseData(id);

		effectDescribe.parseData (id, heroData, this);
    }
	public SkillItem(int id)
	{
		this.hero = null;
		level = 1;
		parseData(id);
	}

    public virtual void parseData(int id)
    {
        templateID = id;
		SetEffects ();
    }
	public bool canUse()
	{
		return curCD == 0 && locked == false;
	}

	public  delegate void ResetCDEvent();
	public  ResetCDEvent resetCDEvent;

	public void resetCD ()
	{
		curCD = cd;
		if (resetCDEvent != null)
			resetCDEvent ();
	}
	public void SetEffects()
	{
		for (int i = 0; i < 5; i++) {
			m_effects[i].type = StaticSkill.Instance().getInt(templateID, "type_" + i);
			m_effects[i].obj = StaticSkill.Instance().getInt(templateID, "object_" + i);
			m_effects[i].parameter1 = StaticSkill.Instance().getFloat(templateID, "parameter1_" + i);
			m_effects[i].parameter2 = StaticSkill.Instance().getFloat(templateID, "parameter2_" + i);
			m_effects[i].RT_effect = StaticSkill.Instance().getInt(templateID, "RT_effect_" + i);
			m_effects[i].acceptor_effectid = StaticSkill.Instance().getStr(templateID, "acceptor_effectid_" + i);
			m_effects[i].formulaid1 = StaticSkill.Instance().getInt(templateID, "formulaid1_" + i);
		}
	}

    private static SkillItem _instance = null;
	public static SkillItem GetStaticData(int id)
    {
        if (_instance == null)
        {
            _instance = new SkillItem();
        }
		_instance.parseData(id);
        return _instance;
    }

    /// <summary>
    /// 是否已经解锁
    /// </summary>
    /// <returns></returns>
    public bool IsUnlock()
    { 
        //TODO:
        return true;
    }

	public string icon { get { return StaticSkill.Instance().getStr(templateID, "icon"); } }                            //< 技能图标
	//public int id { get { return StaticSkill.Instance().getInt(templateID, "id"); } }                                   //< 技能ID
	public string name { get { return StaticSkill.Instance().getStr(templateID, "name"); } }                            //< 技能名字
	public float cd { get { return StaticSkill.Instance().getInt(templateID, "cd") / 10.0f; } }                               //< 技能CD
	public int consume { get { return StaticSkill.Instance().getInt(templateID, "consume"); } }                         //< 消耗
	public string describe { get { return StaticSkill.Instance().getStr(templateID, "describe"); } }                    //< 描述
	public int realm { get { return StaticSkill.Instance().getInt(templateID, "realm"); } }                             //< 解锁
	
	public int object_type { get { return StaticSkill.Instance().getInt(templateID, "object_type"); } }                 //< 目标类型      1.自身 2.鼠标
	public int range_tyoe { get { return StaticSkill.Instance().getInt(templateID, "range_tyoe"); } }                   //< 范围类型
	public float range_R { get { return StaticSkill.Instance().getFloat(templateID, "range_R"); } }                     //< 范围半径
	public string singid { get { return StaticSkill.Instance().getStr(templateID, "singid"); } }                        //< 吟唱特效
	public string effectid { get { return StaticSkill.Instance().getStr(templateID, "effectid"); } }                    //< 技能特效
	public float effect_parameter { get { return StaticSkill.Instance().getFloat(templateID, "effect_parameter"); } }   //< 特效参数
	public string actionid { get { return StaticSkill.Instance().getStr(templateID, "actionid"); } }	                //< 动作ID
	public int actiontype { get { return StaticSkill.Instance().getInt(templateID, "actiontype"); } }                   //< 动作类型      0.普通 1.跳斩 2.旋转 3.方向  4.横移(奥巴马)
	
	public EffectParam[]  m_effects = new EffectParam[5];
	
	//    public int type_0 { get { return StaticSkill.Instance().getInt(templateID, "type_0"); } }                           //< 效果类型      1.伤害 2.治疗 3.buff 4.区域 5.瞬移 
	//    public int object_0 { get { return StaticSkill.Instance().getInt(templateID, "object_0"); } }                       //< 效果目标      0.自己 1.己方 2.敌方 3.召唤兽
	//    public float parameter1_0 { get { return StaticSkill.Instance().getFloat(templateID, "parameter1_0"); } }            //< 参数1
	//    public float parameter2_0 { get { return StaticSkill.Instance().getFloat(templateID, "parameter2_0"); } }           //< 参数2
	//    public int RT_effect_0 { get { return StaticSkill.Instance().getInt(templateID, "RT_effect_0"); } }                 //< 目标即时效果   1.击倒 2.击退 3.击飞
	//    public string acceptor_effectid_0 { get { return StaticSkill.Instance().getStr(templateID, "acceptor_effectid_0"); } } //< 受击特效ID
	//    public int formulaid1_0 { get { return StaticSkill.Instance().getInt(templateID, "formulaid1_0"); } }               //< 公式ID
	//
	//    public int type_1 { get { return StaticSkill.Instance().getInt(templateID, "type_1"); } }                           //< 效果类型      1.伤害 2.治疗 3.buff 4.区域 5.瞬移 
	//    public int object_1 { get { return StaticSkill.Instance().getInt(templateID, "object_1"); } }                       //< 效果目标      0.自己 1.己方 2.敌方 3.召唤兽
	//    public float parameter1_1 { get { return StaticSkill.Instance().getFloat(templateID, "parameter1_1"); } }            //< 参数1
	//    public float parameter2_1 { get { return StaticSkill.Instance().getFloat(templateID, "parameter2_1"); } }           //< 参数2
	//    public int RT_effect_1 { get { return StaticSkill.Instance().getInt(templateID, "RT_effect_1"); } }                 //< 目标即时效果   1.击倒 2.击退 3.击飞
	//    public string acceptor_effectid_1 { get { return StaticSkill.Instance().getStr(templateID, "acceptor_effectid_1"); } }  //< 受击特效ID
	//    public int formulaid1_1 { get { return StaticSkill.Instance().getInt(templateID, "formulaid1_1"); } }               //< 公式ID
	//
	//    public int type_2 { get { return StaticSkill.Instance().getInt(templateID, "type_2"); } }                           //< 效果类型      1.伤害 2.治疗 3.buff 4.区域 5.瞬移 
	//    public int object_2 { get { return StaticSkill.Instance().getInt(templateID, "object_2"); } }                       //< 效果目标      0.自己 1.己方 2.敌方 3.召唤兽
	//    public float parameter1_2 { get { return StaticSkill.Instance().getFloat(templateID, "parameter1_2"); } }            //< 参数1
	//    public float parameter2_2 { get { return StaticSkill.Instance().getFloat(templateID, "parameter2_2"); } }           //< 参数2
	//    public int RT_effect_2 { get { return StaticSkill.Instance().getInt(templateID, "RT_effect_2"); } }                 //< 目标即时效果   1.击倒 2.击退 3.击飞
	//    public string acceptor_effectid_2 { get { return StaticSkill.Instance().getStr(templateID, "acceptor_effectid_2"); } } //< 受击特效ID
	//    public int formulaid1_2 { get { return StaticSkill.Instance().getInt(templateID, "formulaid1_2"); } }               //< 公式ID
	//
	//    public int type_3 { get { return StaticSkill.Instance().getInt(templateID, "type_3"); } }                           //< 效果类型      1.伤害 2.治疗 3.buff 4.区域 5.瞬移 
	//    public int object_3 { get { return StaticSkill.Instance().getInt(templateID, "object_3"); } }                       //< 效果目标      0.自己 1.己方 2.敌方 3.召唤兽
	//    public float parameter1_3 { get { return StaticSkill.Instance().getFloat(templateID, "parameter1_3"); } }            //< 参数1
	//    public float parameter2_3 { get { return StaticSkill.Instance().getFloat(templateID, "parameter2_3"); } }           //< 参数2
	//    public int RT_effect_3 { get { return StaticSkill.Instance().getInt(templateID, "RT_effect_3"); } }                  //< 目标即时效果   1.击倒 2.击退 3.击飞
	//    public string acceptor_effectid_3 { get { return StaticSkill.Instance().getStr(templateID, "acceptor_effectid_3"); } } //< 受击特效ID
	//    public int formulaid1_3 { get { return StaticSkill.Instance().getInt(templateID, "formulaid1_3"); } }               //< 公式ID
	//
	//    public int type_4 { get { return StaticSkill.Instance().getInt(templateID, "type_4"); } }                            //< 效果类型      1.伤害 2.治疗 3.buff 4.区域 5.瞬移 
	//    public int object_4 { get { return StaticSkill.Instance().getInt(templateID, "object_4"); } }                        //< 效果目标      0.自己 1.己方 2.敌方 3.召唤兽
	//    public float parameter1_4 { get { return StaticSkill.Instance().getFloat(templateID, "parameter1_4"); } }            //< 参数1
	//    public float parameter2_4 { get { return StaticSkill.Instance().getFloat(templateID, "parameter2_4"); } }            //< 参数2
	//    public int RT_effect_4 { get { return StaticSkill.Instance().getInt(templateID, "RT_effect_4"); } }                  //< 目标即时效果   1.击倒 2.击退 3.击飞
	//    public string acceptor_effectid_4 { get { return StaticSkill.Instance().getStr(templateID, "acceptor_effectid_4"); } } //< 受击特效ID
	//    public int formulaid1_4 { get { return StaticSkill.Instance().getInt(templateID, "formulaid1_4"); } }               //< 公式ID

}
