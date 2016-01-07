using UnityEngine;
using System.Collections;

/// <summary>
/// 战斗面板 结算的UI
/// 
/// Maintaince Logs: 
/// 2014-11-28  WP      Initial version.
/// </summary>

public abstract class UIBattleFinishPanel : MonoBehaviour
{
    public abstract void ShowPanel(bool isWin);

}
