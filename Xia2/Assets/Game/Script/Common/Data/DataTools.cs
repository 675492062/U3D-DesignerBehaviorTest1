/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-16   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 数据处理类，提供一些公用方法
/// </summary>
public static class DataTools
{
    /// <summary>
    /// 判断货币是否够用
    /// </summary>
    static public bool HasMoney(GlobalDef.MoneyType tp, int value)
    {
        bool has = false;
        has = value <= MonoInstancePool.getInstance<UserData>().getMoney((int)tp);
        return has;
    }

    /// <summary>
    /// 消耗
    /// </summary>
    static public void SubMoney(GlobalDef.MoneyType tp, int value)
    {
        MonoInstancePool.getInstance<UserData>().subMoney((int)tp, value);
    }

    /// <summary>
    /// 收入
    /// </summary>
    static public void AddMoney(GlobalDef.MoneyType tp, int value)
    {
        MonoInstancePool.getInstance<UserData>().addMoney((int)tp, value);
    }
}
