/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-16   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 装备熔炼cao
/// </summary>
public class EqptSmeltSlot : EqptSlot
{
    /// <summary>
    /// 对应的选择框
    /// </summary>
    public Transform select;

    private EqptSlot target;

    void OnClick()
    {
        if (item != null)
        {
            EqptPanelSmelt.instance.BtnEquipInPanel(target);
            Replace(null);
        }
    }

    /// <summary>
    /// 装备是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return item == null;
    }

    public void ShowByTarget(EqptSlot slot)
    {
        target = slot;
        if (slot != null)
        {
            //选择框
            //int index = curEquipItems.IndexOf(item);
            select.gameObject.SetActive(true);
            select.position = target.transform.position;
            Replace(slot.GetItem());
        }
        else Replace(null);
    }

    public override void Replace(EquipmentItem data)
    {
        if (data != null) //显示的时候由其它的函数调用
        {

        }
        else
        {
            select.gameObject.SetActive(false);
        }
        base.Replace(data);
    }
}
