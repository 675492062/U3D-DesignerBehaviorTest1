using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticVip : csvDataParent{

	private volatile static StaticVip _instance = null;
    private static readonly object lockHelper = new object();
    private StaticVip(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticVip Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticVip();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}