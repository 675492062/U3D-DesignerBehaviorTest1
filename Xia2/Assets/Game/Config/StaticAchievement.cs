using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticAchievement : csvDataParent{

	private volatile static StaticAchievement _instance = null;
    private static readonly object lockHelper = new object();
	private StaticAchievement(){}
	public static StaticAchievement Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticAchievement();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}