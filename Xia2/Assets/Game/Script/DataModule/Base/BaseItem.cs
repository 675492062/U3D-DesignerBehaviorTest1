using UnityEngine;
using System.Collections;

//[System.Serializable]
public class BaseItem {

	int iType;
	public long guid{ get; set;}
	public int  templateID{ get; set;}	
	public int  haveNum{ get; set;}	
	public bool isDirty{ get; set;}

	public int  type
	{ 
		get
		{
			return ConfigManager.getInstance().getTypeByTemplateID(templateID);
		} 
	}


	public BaseItem()
	{
		haveNum = 1;
	}

	public virtual void parseData(Property.Item data)
	{
		guid = (long)data.guid;
		templateID = (int)data.templateid;
		haveNum = (int)data.number;
	}

	public void addNum(int num)
	{
		haveNum += num;
	}

    public string getAttriButeidName(int attr)
    {
        int subType = attr;
        string str = "";
        switch (subType)
        {
            case (int)GlobalDef.HeroProperty.PRO_LIFE:                      //生命
                str = "生命";
                break;
            case (int)GlobalDef.HeroProperty.PRO_STRENGTH:                  //力量
                str = "力量";
                break;
            case (int)GlobalDef.HeroProperty.PRO_INTELLIGENCE:              //智力
                str = "智力";
                break;
            case (int)GlobalDef.HeroProperty.PRO_SMART:                     //敏捷
                str = "敏捷";
                break;
            case (int)GlobalDef.HeroProperty.PRO_MANAPOINT:                 //无双段
                str = "无双段";
                break;
            case (int)GlobalDef.HeroProperty.PRO_CRITICALLV:                //爆击等级
                str = "爆击等级";
                break;
            case (int)GlobalDef.HeroProperty.PRO_CRITICALDAMAGE:            //爆机伤害
                str = "爆机伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_HITLV:                     //命中等级
                str = "命中等级";
                break;
            case (int)GlobalDef.HeroProperty.PRO_ATKDELTA:                  //攻击力伤害
                str = "攻击力伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_FIREDAMAGE:                //火焰伤害
                str = "火焰伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_ICEDAMAGE:                 //冰霜伤害
                str = "冰霜伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_POISONDAMAGE:              //毒素伤害
                str = "毒素伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_LIGHTNINGDAMAGE:           //雷电伤害
                str = "雷电伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_HITREGEN:                  //击中回复
                str = "击中回复";
                break;
            case (int)GlobalDef.HeroProperty.PRO_KILLREGEN:                 //击杀回复
                str = "击杀回复";
                break;
            case (int)GlobalDef.HeroProperty.PRO_LIFESTEAK:                 //生命窃取
                str = "生命窃取";
                break;
            case (int)GlobalDef.HeroProperty.PRO_RECOVERY:                  //战斗回复
                str = "战斗回复";
                break;
            case (int)GlobalDef.HeroProperty.PRO_TRUEDAMAGE:                //真实伤害
                str = "真实伤害";
                break;
            case (int)GlobalDef.HeroProperty.PRO_DODGELV:                   //闪避等级
                str = "闪避等级";
                break;
            case (int)GlobalDef.HeroProperty.PRO_TENACITYLV:                //韧性等级
                str = "韧性等级";
                break;
            case (int)GlobalDef.HeroProperty.PRO_FIRERESIST:                //火焰抗性
                str = "火焰抗性";
                break;
            case (int)GlobalDef.HeroProperty.PRO_ICERESIST:                 //冰霜抗性
                str = "冰霜抗性";
                break;
            case (int)GlobalDef.HeroProperty.PRO_POISONRESIST:              //毒素抗性
                str = "毒素抗性";
                break;
            case (int)GlobalDef.HeroProperty.PRO_LIGHTNINGRESIST:           //闪电抗性
                str = "闪电抗性";
                break;
            case (int)GlobalDef.HeroProperty.PRO_TRUEDGRESIST:              //真实伤害减免
                str = "真实伤害减免";
                break;
            case (int)GlobalDef.HeroProperty.PRO_REDHOLE:                   //红宝石孔
                str = "红宝石孔";
                break;
            case (int)GlobalDef.HeroProperty.PRO_PURPLEHOLE:                //绿色宝石孔
                str = "绿色宝石孔";
                break;
            case (int)GlobalDef.HeroProperty.PRO_BLUEHOLE:                  //蓝色宝石孔
                str = "绿色宝石孔";
                break;
            case (int)GlobalDef.HeroProperty.PRO_EXP:                       //经验
                str = "绿色宝石孔";
                break;
        }
        return str;

    }
}