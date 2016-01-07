/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-04   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 英雄星级表
/// </summary>
public class HeroStar : MonoBehaviour
{
    public void Refresh(int starLevel)
    {
        if (this.starLevel != starLevel)
        {
            this.starLevel = starLevel;
        }
    }

    private StaticHero_star datas { get { return StaticHero_star.Instance(); } }

    private int starLevel = 1;

    public int itemNum { get { return datas.getInt(starLevel, "itemnum"); } }

    public bool CanStarUp()
    {
        return starLevel < 5 && MonoInstancePool.getInstance<UserData>().soulPoint >= itemNum;
    }

}
