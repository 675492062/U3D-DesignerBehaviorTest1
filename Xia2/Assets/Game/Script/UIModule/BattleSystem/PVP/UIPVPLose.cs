using UnityEngine;
using System.Collections;

/// <summary>
/// PVP 失败
/// 
/// Maintaince Logs: 
/// 2014-12-28  WP      Initial version
/// </summary>
public class UIPVPLose : MonoBehaviour
{

    public UIPVPPlayerSlot playerInfo;

    public void Show()
    {
        UserData ud = MonoInstancePool.getInstance<UserData>();
        playerInfo.SetName(ud.userName);
        playerInfo.SetLevel("Lv." + ud.level);

        //TODO icon
    }
}
