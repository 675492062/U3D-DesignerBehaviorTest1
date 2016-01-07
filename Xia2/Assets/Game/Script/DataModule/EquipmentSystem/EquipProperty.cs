/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 用于存放和计算装备的属性
/// </summary>
public class EquipProperty
{
    private int lv = 0;
    /// <summary>
    /// 装备品质 ：1=白色  2=绿色  3=蓝色  4=紫色  5=橙色
    /// </summary>
    private int quality = 0;
    /// <summary>
    /// 装备类型 ： 1=武器 2=胸甲 3=护腿 4=手套  5=靴子 6=视频
    /// </summary>
    private int equipType = 0;

    /// <summary>
    /// 1=生命值   2=攻击力   3=护甲    4=暴击等级  5=韧性等级  6=闪避等级  7=命中等级
    /// </summary>
    private int basePropType = 0;

    /// <summary>
    /// 装备附加品质属性类型列表，下标0对应附加属性1
    /// </summary>
    private List<int> inctPropTypes = new List<int>();

    /// <summary>
    /// 装备品质属性值列表，与inctPropTypes相对应
    /// </summary>
    private List<int> inctPropValues = new List<int>();

    #region Calc params

    /// <summary>
    /// key值根据：GlobalDef.EquipProperty 取
    /// </summary>
    public Dictionary<int, int> dictProperty;

    /// <summary>
    /// 攻击力,非最终伤害
    /// </summary>
    public int attack = 0;

    public int minDamage = 0;
    public int maxDamage = 0;

    public int hp = 0;
    public int armor = 0;
    /// <summary>
    /// 闪避
    /// </summary>
    public int dodge = 0;
    /// <summary>
    /// 命中
    /// </summary>
    public int hit = 0;
    /// <summary>
    /// 韧性
    /// </summary>
    public int tenacity = 0;
    /// <summary>
    /// 战斗力 TODO:计算公式未出
    /// </summary>
    public int fightingCapacity = 0;

    /// <summary>
    /// 暴击
    /// </summary>
    public int crit = 0;


    private EquipITItem mEquipITItem;
    /// <summary>
    /// 品质对应的加成的属性表
    /// </summary>
    public EquipITItem infoQualityAttribute
    {
        get
        {
            if (mEquipITItem == null) mEquipITItem = new EquipITItem(equipType, quality);
            return mEquipITItem;
        }
    }

    private EquipIAItem mEquipIAItem;
    /// <summary>
    /// 装备强化属性表
    /// </summary>
    public EquipIAItem infoBaseAttribute
    {
        get
        {
            if (mEquipIAItem == null) mEquipIAItem = new EquipIAItem();
            mEquipIAItem.parseData(equipType);
            return mEquipIAItem;
        }
    }

    #endregion

    public EquipProperty(EquipmentItem item)
    {
        this.quality = item.quality;
        this.equipType = item.equitype;
        this.basePropType = item.base_attribute_type;
        if (quality > 1) { inctPropTypes.Add(item.quality_attribute_id1); inctPropValues.Add(infoQualityAttribute.int1); }
        if (quality > 2) { inctPropTypes.Add(item.quality_attribute_id2); inctPropValues.Add(infoQualityAttribute.int2); }
        if (quality > 3) { inctPropTypes.Add(item.quality_attribute_id3); inctPropValues.Add(infoQualityAttribute.int3); }
        if (quality > 4) { inctPropTypes.Add(item.quality_attribute_id4); inctPropValues.Add(infoQualityAttribute.int4); }

        if (item.equitype == 1)
        {
            //lv1:基本属性
            minDamage = item.mindamage;
            maxDamage = item.maxdamage;
        }
        else
            //  lv1:基本属性 
            CalcProp(item.base_attribute_type, item.base_attribute_int);

        //lv1:品质属性：0级一般不开启
        if (IsEnableQualityProp(0))
        {
            Debug.LogError("0 level Enable Quality prop???");
        }

        Refresh(item.equiplev);
    }

    /// <summary>
    /// 只用于等级提升，等级降低请另做
    /// </summary>
    /// <param name="level"></param>
    public void Refresh(int level)
    {
        if (lv < level)
        {
            for (; lv < level; )
            {
                // 基本属性
                int baseInct = GetInctByBaseOfNextLv();
                CalcProp(basePropType, baseInct);

                //品质属性的叠加
                if (IsEnableQualityProp(lv))
                {
                    int index = GetIndexForQualityIncts(lv);
                    int inctType = inctPropTypes[index];
                    int inctValue = inctPropValues[index];
                    CalcProp(inctType, inctValue);
                }

                lv++;
            }
        }

        if (dictProperty == null)
        {
            // 1=生命值   2=攻击力   3=护甲    4=暴击等级  5=韧性等级  6=闪避等级  7=命中等级
            dictProperty = new Dictionary<int, int>();
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT, hp);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_ATTACK, attack);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_ARMOR, armor);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV, crit);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV, tenacity);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_DODGELV, dodge);
            dictProperty.Add((int)GlobalDef.NewHeroProperty.PRO_HITLV, hit);
        }
        else
        {
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT] = hp;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_ATTACK] = attack;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_ARMOR] = armor;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_CRITICALLV] = crit;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_TENACITYLV] = tenacity;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_DODGELV] = hp;
            dictProperty[(int)GlobalDef.NewHeroProperty.PRO_HITLV] = hit;
        }
    }

    /// <summary>
    /// 属性叠加
    /// </summary>
    /// <param name="propType"></param>
    /// <param name="addValue"></param>
    void CalcProp(int propType, int addValue)
    {
        switch (propType)
        {
            //非武器基础属性类型

            case (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT: hp += addValue; break;       //1=生命值
            case 0:
            case (int)GlobalDef.NewHeroProperty.PRO_ATTACK: attack += addValue; minDamage += addValue; maxDamage += addValue; break;        //2=攻击力
            case (int)GlobalDef.NewHeroProperty.PRO_ARMOR: armor += addValue; break;        //3=护甲
            case (int)GlobalDef.NewHeroProperty.PRO_CRITICALLV: crit += addValue; break;    //4=暴击等级
            case (int)GlobalDef.NewHeroProperty.PRO_TENACITYLV: tenacity += addValue; break;//5=韧性等级
            case (int)GlobalDef.NewHeroProperty.PRO_DODGELV: dodge += addValue; break;      //6=闪避等级
            case (int)GlobalDef.NewHeroProperty.PRO_HITLV: hit += addValue; break;          //7=命中等级
            default: break;
        }
    }

    /// <summary>
    /// 取属性值0 =武器攻击 1=生命值   2=攻击力   3=护甲    4=暴击等级  5=韧性等级  6=闪避等级  7=命中等级
    /// </summary>
    /// <param name="propertyIndex">属性编号</param>
    /// <returns></returns>
    public int GetPropertyValue(int propType)
    {
        int value = 0;
        switch (propType)
        {
            case 0: value = attack; break;
            case (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT: value = hp; break;
            case (int)GlobalDef.NewHeroProperty.PRO_ATTACK: value = attack; break;
            case (int)GlobalDef.NewHeroProperty.PRO_ARMOR: value = armor; break;
            case (int)GlobalDef.NewHeroProperty.PRO_CRITICALLV: value = crit; break;
            case (int)GlobalDef.NewHeroProperty.PRO_TENACITYLV: value = tenacity; break;
            case (int)GlobalDef.NewHeroProperty.PRO_DODGELV: value = dodge; break;
            case (int)GlobalDef.NewHeroProperty.PRO_HITLV: value = hit; break;
        }
        return value;
    }

    /// <summary>
    /// 取下一级基本属性的增量
    /// </summary>
    public int GetInctByBaseOfNextLv()
    {
        int value = 0;
        //意为基本属性
        switch (equipType)
        {
            // 1=武器 2=胸甲 3=护腿 4=手套  5=靴子 6=视频
            case 1: value = infoBaseAttribute.equip1_attribute1; break;
            case 2: value = infoBaseAttribute.equip2_attribute1; break;
            case 3: value = infoBaseAttribute.equip3_attribute1; break;
            case 4: value = infoBaseAttribute.equip4_attribute1; break;
            case 5: value = infoBaseAttribute.equip5_attribute1; break;
            case 6: value = infoBaseAttribute.equip6_attribute1; break;
        }
        //Debug.Log("equiptype is " + equipType + "      value is " + value);
        return value;
    }

    /// <summary>
    /// 是否是高品质武器
    /// </summary>
    /// <returns></returns>
    public bool IsHighQuality()
    {
        //TODO:
        return quality >= 2;
    }

    /// <summary>
    /// 判断此等级下是否开启品质属性加成
    /// </summary>
    /// <returns></returns>
    public bool IsEnableQualityProp(int level)
    {
        bool isEnable = false;
        if (quality < 2) return false;
        if (level > infoQualityAttribute.level)
        {
            isEnable = true;
        }
        return isEnable;
    }

    /// <summary>
    /// 取当前附加属性类型的下数组下标
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    private int GetIndexForQualityIncts(int level)
    {
        int index = (level - infoQualityAttribute.level) % infoQualityAttribute.step;

        if (index >= inctPropTypes.Count) index %= inctPropTypes.Count;

        return index;
    }



    /// <summary>
    /// 取下一级加成属性数
    /// </summary>
    /// <param name="names">属性名</param>
    /// <param name="defaults">默认值</param>
    /// <param name="incts">下一级增量值</param>
    /// <returns></returns>
    public int GetCountByInct(out List<string> names, out List<int> defaults, out List<int> incts)
    {
        int count = 0;
        names = new List<string>(); defaults = new List<int>(); incts = new List<int>();

        Dictionary<int, int> proys = GetPropsByNextLevel();
        for (int i = 0; i < proys.Count; i++)
        {
            names.Add(EquipProperty.GetPropertyName(proys.ElementAt(i).Key));
            defaults.Add(GetPropertyValue(proys.ElementAt(i).Key));
            incts.Add(proys.ElementAt(i).Value);
            count++;
        }
        return count;
    }

    /// <summary>
    /// 取属性名 例：  +3700 生命值
    /// </summary>
    /// <returns></returns>
    public string GetDetailsByProps()
    {
        List<string> names = new List<string>();
        List<int> values = new List<int>();
        List<int> incts = new List<int>();
        GetCountByInct(out names, out values, out incts);
        string desc = "";

        //TODO: 百分比
        for (int i = 0; i < names.Count; i++)
        {
            desc += "+" + values[i] + " " + names[i] + "\n";
        }

        return desc;
    }

    /// <summary>
    ///  取增量 例 :   + 140
    /// </summary>
    /// <returns></returns>
    public string GetInctByProps()
    {
        List<string> names = new List<string>();
        List<int> values = new List<int>();
        List<int> incts = new List<int>();
        GetCountByInct(out names, out values, out incts);
        string desc = "";

        for (int i = 0; i < names.Count; i++)
        {
            desc += "+" + incts[i] + "\n";
        }
        return desc;
    }

    /// <summary>
    /// 取下一级强化对应属性增量表：(属性编号，属性值)
    /// </summary>
    /// <returns></returns>
    private Dictionary<int, int> GetPropsByNextLevel()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        //下一级基本属性增量
        dict.Add(basePropType, GetInctByBaseOfNextLv());

        //下一级品质加成属性
        if (IsEnableQualityProp(lv))
        {
            int tp = 0;
            int index = GetIndexForQualityIncts(lv);
            tp = inctPropTypes[index];

            int tpValue = inctPropValues[index];
            if (dict.ContainsKey(tp))
            {
                dict[tp] += tpValue;
            }
            else
            {
                dict.Add(tp, tpValue);
            }
        }

        return dict;
    }

    /// <summary>
    /// 属性中文名称
    /// </summary>
    /// <param name="index">属性编号 0 =武器攻击 1=生命值   2=攻击力   3=护甲    4=暴击等级  5=韧性等级  6=闪避等级  7=命中等级</param>
    /// <returns></returns>
    public static string GetPropertyName(int pType)
    {
        string str = "";
        switch (pType)
        {
            case 0: str = AllStrings.attack; break;
            case (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT: str = AllStrings.hp; break;
            case (int)GlobalDef.NewHeroProperty.PRO_ATTACK: str = AllStrings.attack; break;
            case (int)GlobalDef.NewHeroProperty.PRO_ARMOR: str = AllStrings.armor; break;
            case (int)GlobalDef.NewHeroProperty.PRO_CRITICALLV: str = AllStrings.critical; break;
            case (int)GlobalDef.NewHeroProperty.PRO_TENACITYLV: str = AllStrings.tenacity; break;
            case (int)GlobalDef.NewHeroProperty.PRO_DODGELV: str = AllStrings.dodge; break;
            case (int)GlobalDef.NewHeroProperty.PRO_HITLV: str = AllStrings.hit; break;
        }
        //Debug.Log("type is " + pType + "     str is " + str);
        return str;
    }

}
