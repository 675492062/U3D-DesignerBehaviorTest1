/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-17   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 负责场景里面的货币数值的变动
/// </summary>
public class LabEventManager : MonoBehaviour
{
    public delegate void UpdateEvent(string str);

    private static LabEventManager mInstance;
    public static LabEventManager instance
    {
        get
        {
            if (!mInstance)
            {
                mInstance = GameObject.FindObjectOfType(typeof(LabEventManager)) as LabEventManager;

                if (!mInstance)
                    mInstance = MonoInstancePool.getInstance<LabEventManager>();
            }
            return mInstance;
        }
    }

    private UserData userData { get { return MonoInstancePool.getInstance<UserData>(); } }

    private string strGold
    {
        get
        {
            return userData.gold.ToString();
        }
    }

    private string strDiamond
    {
        get
        {
            return userData.diamond.ToString();
        }
    }

    private string strStamina
    {
        get
        {
            return userData.stamina.ToString();
        }
    }

    private string strSoulStone
    {
        get
        {
            string str = "";
            str = userData.soulPoint.ToString();
            return str;
        }
    }

    public UpdateEvent goldEvent;

    public UpdateEvent diamondEvent;

    public UpdateEvent soulStoneEvent;

    public UpdateEvent staminaEvent;

    void Awake() { if (!mInstance) mInstance = this; }

    void Update()
    {
        if (goldEvent != null) goldEvent(strGold);
        if (diamondEvent != null) diamondEvent(strDiamond);
        if (soulStoneEvent != null) soulStoneEvent(strSoulStone);
        if (staminaEvent != null) staminaEvent(strStamina);
    }
}
