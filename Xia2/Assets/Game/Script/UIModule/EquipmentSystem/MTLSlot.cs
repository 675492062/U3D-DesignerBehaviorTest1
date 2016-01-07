/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 材料的显示孔
/// </summary>
public class MTLSlot : MonoBehaviour
{
    protected MaterialItem item;

    public UISprite icon;

    public UILabel labCount;

    public virtual void Refresh(MaterialItem it)
    {
        item = it;
        if (it != null)
        {
            icon.enabled = true;
            icon.spriteName = item.icon;
            if (item.number != 0)
            {
                labCount.enabled = true;
                labCount.text = item.number.ToString();
            }
            else
            {
                labCount.enabled = false;
            }

        }
        else
        {
            icon.enabled = false;
            labCount.enabled = false;
        }
    }

    /// <summary>
    /// 0代表没有物品
    /// </summary>
    /// <returns></returns>
    public int GetItemID()
    {
        int id = 0;
        if (item != null)
        {
            id = item.templateID;
        }
        return id;
    }
}
