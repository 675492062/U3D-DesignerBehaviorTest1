/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 品质加成属性相关的数据
/// </summary>
public class EquipITItem : BaseItem
{

    public EquipITItem(int equipType, int quality) { templateID = equipType; }

    private StaticEquip_intensify_trigger datas { get { return StaticEquip_intensify_trigger.Instance(); } }

    /// <summary>
    /// 附加属性增强触发等级
    /// </summary>
    public int level { get { return datas.getInt(templateID, "level"); } }

    /// <summary>
    /// 触发步长
    /// </summary>
    public int step { get { return datas.getInt(templateID, "step"); } }

    /// <summary>
    /// 品质附加属性1
    /// </summary>
    public int int1 { get { return datas.getInt(templateID, "int1"); } }

    /// <summary>
    /// 品质附加属性2
    /// </summary>
    public int int2 { get { return datas.getInt(templateID, "int2"); } }

    /// <summary>
    /// 品质附加属性3
    /// </summary>
    public int int3 { get { return datas.getInt(templateID, "int3"); } }

    /// <summary>
    /// 品质附加属性4
    /// </summary>
    public int int4 { get { return datas.getInt(templateID, "int4"); } }

    /// <summary>
    /// 取触发阶段
    /// </summary>
    /// <param name="lv"></param>
    /// <returns></returns>
    public int GetStage(int lv)
    {
        return (lv - level) / step + 1;
    }
}
