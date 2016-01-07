using UnityEngine;
using System.Collections;

/// <summary>
/// PVP 成功失败
/// 
/// Maintaince Logs: 
/// 2014-11-28  WP      Initial version
/// </summary>
public class UIPVPWin : MonoBehaviour
{
    public UIPVPPlayerSlot playerInfo;
    public UIPVPPlayerSlot rivalPlayerInfo;

    public void Show(PVPBattleData showData)
    {
        UserData ud = MonoInstancePool.getInstance<UserData>();

        playerInfo.SetName(ud.userName);
        playerInfo.SetLevel("Lv." + ud.level);

        playerInfo.SetCurRanking(showData.playerCurRank.ToString());
        playerInfo.SetUpLab("+" + showData.playerUp);

        //TODO icon

        rivalPlayerInfo.SetCurRanking(showData.rivalCurRank.ToString());
        rivalPlayerInfo.SetUpLab("-" + showData.rivalDown);
        rivalPlayerInfo.SetName(showData.rivalName);

        //TODO rival icon and level
    }
}
