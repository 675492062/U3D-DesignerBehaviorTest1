using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticMonster : csvDataParent{

	private volatile static StaticMonster _instance = null;
    private static readonly object lockHelper = new object();
    private StaticMonster(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticMonster Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticMonster();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}