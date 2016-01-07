using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticDungeon : csvDataParent{

	private volatile static StaticDungeon _instance = null;
    private static readonly object lockHelper = new object();
	private StaticDungeon(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticDungeon Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticDungeon();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}