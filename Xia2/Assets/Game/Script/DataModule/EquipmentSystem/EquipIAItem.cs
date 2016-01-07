/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-15   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 装备强化属性表，用于配置每个装备部件每个强化等级对应的属性增量和属性显示名称
/// </summary>
public class EquipIAItem : BaseItem
{
    public EquipIAItem() { }

    public void parseData(int level) { templateID = level; }

    private StaticEquip_intensify_attribute datas { get { return StaticEquip_intensify_attribute.Instance(); } }

    /// <summary>
    /// 武器属性1增量
    /// </summary>
    public int equip1_attribute1 { get { return datas.getInt(templateID, "equip1_attribute1"); } }
    /// <summary>
    /// 武器属性2增量
    /// </summary>
    public int equip1_attribute2 { get { return datas.getInt(templateID, "equip1_attribute2"); } }
    /// <summary>
    /// 胸甲属性1增量
    /// </summary>
    public int equip2_attribute1 { get { return datas.getInt(templateID, "equip2_attribute1"); } }
    /// <summary>
    /// 胸甲属性2增量
    /// </summary>
    public int equip2_attribute2 { get { return datas.getInt(templateID, "equip2_attribute2"); } }
    /// <summary>
    /// 护腿属性1增量
    /// </summary>
    public int equip3_attribute1 { get { return datas.getInt(templateID, "equip3_attribute1"); } }
    /// <summary>
    /// 护腿属性2增量
    /// </summary>
    public int equip3_attribute2 { get { return datas.getInt(templateID, "equip3_attribute2"); } }
    /// <summary>
    /// 手套属性1增量
    /// </summary>
    public int equip4_attribute1 { get { return datas.getInt(templateID, "equip4_attribute1"); } }
    /// <summary>
    /// 手套属性2增量
    /// </summary>
    public int equip4_attribute2 { get { return datas.getInt(templateID, "equip4_attribute2"); } }
    /// <summary>
    /// 靴子属性1增量
    /// </summary>
    public int equip5_attribute1 { get { return datas.getInt(templateID, "equip5_attribute1"); } }
    /// <summary>
    /// 靴子属性2增量
    /// </summary>
    public int equip5_attribute2 { get { return datas.getInt(templateID, "equip5_attribute2"); } }
    /// <summary>
    /// 饰品属性1增量
    /// </summary>
    public int equip6_attribute1 { get { return datas.getInt(templateID, "equip6_attribute1"); } }
    /// <summary>
    /// 饰品属性1增量
    /// </summary>
    public int equip6_attribute2 { get { return datas.getInt(templateID, "equip6_attribute2"); } }

    ///// <summary>
    ///// 附加生命值增量
    ///// </summary>
    //public int quality_hp { get { return datas.getInt(templateID, "quality_hp"); } }
    ///// <summary>
    ///// 附加攻击力增量
    ///// </summary>
    //public int quality_attack { get { return datas.getInt(templateID, "quality_attack"); } }
    ///// <summary>
    ///// 附加护甲增量
    ///// </summary>
    //public int quality_armor { get { return datas.getInt(templateID, "quality_armor"); } }
    ///// <summary>
    ///// 附加暴击等级增量
    ///// </summary>
    //public int quality_critical { get { return datas.getInt(templateID, "quality_critical"); } }
    ///// <summary>
    ///// 附加韧性等级增量
    ///// </summary>
    //public int quality_tenacity { get { return datas.getInt(templateID, "quality_tenacity"); } }
    ///// <summary>
    ///// 附加闪避等级增量
    ///// </summary>
    //public int quality_dodge { get { return datas.getInt(templateID, "quality_dodge"); } }
    ///// <summary>
    ///// 附加命中等级增量
    ///// </summary>
    //public int quality_hit { get { return datas.getInt(templateID, "quality_hit"); } }



}
