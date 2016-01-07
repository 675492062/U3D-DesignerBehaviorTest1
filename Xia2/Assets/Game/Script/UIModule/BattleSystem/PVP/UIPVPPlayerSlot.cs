using UnityEngine;
using System.Collections;

/// <summary>
/// PVP 结算中 战队详情
/// 
/// Maintaince Logs: 
/// 2014-12-28  WP      Initial version
/// </summary>
public class UIPVPPlayerSlot : CommonSlot
{
    public UILabel labUpDown;
    /// <summary>
    /// 当前名次
    /// </summary>
    public UILabel labCurRanking;

    public void SetUpLab(string str)
    {
        if (labUpDown) labUpDown.text = str;
    }

    public void SetCurRanking(string str)
    {
        if (labCurRanking) labCurRanking.text = str;
    }

}
