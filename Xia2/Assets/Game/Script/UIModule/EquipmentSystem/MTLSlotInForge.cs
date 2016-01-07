/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-19   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 锻造面板里面的 material 
/// </summary>
public class MTLSlotInForge : MTLSlot
{
    public UILabel labName;

	public UISprite sprBackground;

    public override void Refresh(MaterialItem it)
    {
        item = it;
        if (it != null)
        {
            icon.enabled = true;
            icon.spriteName = item.icon;
            if (labName != null)
            {
                labName.text = it.name;
                labName.enabled = true;
            }
            if (item.number != 0)
            {
                labCount.enabled = true;
                // count display
                int hasCount = MonoInstancePool.getInstance<BagManager>().getBagByType((int)GlobalDef.BagType.B_MATERIAL).getItemNumbyTempID(item.templateID);
                if (item.number <= hasCount)
                {
                    labCount.color = Color.white;
                }
                else
                {
                    labCount.color = Color.red;
                }
                labCount.text = item.number + "/" + hasCount;
            }
            else
            {
                labCount.enabled = false;
            }
            //sprBackground.spriteName = AllStrings.sprMatSlot;
        }
        else
        {
            if (icon) icon.spriteName = "equipment_06";
            labCount.enabled = false;

            if (labName != null)
            {
                labName.enabled = false;
            }
            //sprBackground.spriteName = AllStrings.sprLockMatSlot;
        }
    }
}
