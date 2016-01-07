/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-16   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 强化强化的EXP数值
/// </summary>
public class EquipIEItem : BaseItem
{
    public EquipIEItem() {  }

    public void parseData(int level) { templateID = level; }

    private StaticEquip_intensify_exp datas { get { return StaticEquip_intensify_exp.Instance(); } }

    /// <summary>
    /// 升级所需EXP
    /// </summary>
    public int exp { get { return datas.getInt(templateID, "exp"); } }
    /// <summary>
    /// 所有EXP之和
    /// </summary>
    public int sum { get { return datas.getInt(templateID, "sum"); } }
}
