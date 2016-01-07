using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

/// <summary>
/// 关卡评分表 ，用于战斗成就
/// </summary>
public class StaticDungeon_star : csvDataParent
{
    private volatile static StaticDungeon_star _instance = null;
    private static readonly object lockHelper = new object();
    private StaticDungeon_star() { }
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
    public static StaticDungeon_star Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                    _instance = new StaticDungeon_star();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}
