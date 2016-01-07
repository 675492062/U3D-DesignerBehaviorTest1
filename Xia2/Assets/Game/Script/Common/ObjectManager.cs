/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-09-28   WP      Initial version.
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 用于访问游戏场景中唯一的对象
/// </summary>
public class ObjectManager : MonoBehaviour
{
    private static ObjectManager mInstance;
    public static ObjectManager instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = MonoInstancePool.getInstance<ObjectManager>();
            }
            return mInstance;
        }
    }

    private MyPlayer mCharCtrl;
	public MyPlayer myPlayer
    {
        get
        {
			if (mCharCtrl == null) mCharCtrl = MyPlayer.instance;
            return mCharCtrl;
        }

    }

    private Player mOtherPlayer;
    public Player otherPlayer
    {
        get
        {
            if (mOtherPlayer == null)
            {
                mOtherPlayer = Player.instance;
            }
            return mOtherPlayer;
        }
    }

}
