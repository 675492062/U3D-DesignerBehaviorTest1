using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticRealmframe : csvDataParent{

	private volatile static StaticRealmframe _instance = null;
    private static readonly object lockHelper = new object();
    private StaticRealmframe(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticRealmframe Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticRealmframe();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}