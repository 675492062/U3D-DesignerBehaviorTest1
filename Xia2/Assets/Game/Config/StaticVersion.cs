using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class StaticVersion : csvDataParent{

	private volatile static StaticVersion _instance = null;
    private static readonly object lockHelper = new object();
	private StaticVersion(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticVersion Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticVersion();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}