using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 提供一些取ID或者Popup方面的描述
/// 
/// Maintaince Logs:
/// 2014-12-08  WP      Initial version. 
/// </summary>
public static class StaticEditorDatas
{

    static List<string> mEnemiesDesc;
    static int[] enemiesIds { get { return StaticMonster.Instance().allID; } }
    static string[] mPopEnemies;
    /// <summary>
    /// 敌人描述
    /// </summary>
    public static string[] popEnemies
    {
        get
        {
            if (mEnemiesDesc == null)
            {
                mEnemiesDesc = new List<string>();
                MonsterItem mi = new MonsterItem();
                string desc = "";
                for (int i = 0; i < enemiesIds.Length; i++)
                {
                    mi.templateID = enemiesIds[i];
                    desc = "ID:" + enemiesIds[i] + "  Name:" + mi.name + "  Lv:" + mi.level;
                    mEnemiesDesc.Add(desc);
                }
                mPopEnemies = mEnemiesDesc.ToArray();
            }
            return mPopEnemies;
        }
    }
}
