/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-15   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class EqptPanel : MonoBehaviour
{
    /// <summary>
    /// 公用面板最后点击的一个槽
    /// </summary>
    protected EqptSlot lastSlot { get { return EqptCtrl.instance.GetCurrentSlot(); } }

    protected EquipmentItem currentEquip { get { return lastSlot.GetItem(); } }

    //public abstract void OnEquipClick(EqptSlot s, ulong hero_guid = 0);

    public abstract void Refresh();

    //public bool IsLocalSlot(EqptSlot s) { if (!localSlot) return false; return s == localSlot; }

    //public void ReSetLocalSlot() { localSlot = null; }

    //protected void InitLocalSlot()
    //{
    //    if (localSlot == null)
    //    {
    //        localSlot = EqptCtrl.instance.GetDefaultSlot();
    //        Refresh();
    //    }
    //}

    void OnEnable() { Refresh(); }

}
