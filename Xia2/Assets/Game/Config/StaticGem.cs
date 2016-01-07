using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticGem : csvDataParent{

	private volatile static StaticGem _instance = null;
    private static readonly object lockHelper = new object();
    private StaticGem(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticGem Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticGem();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}