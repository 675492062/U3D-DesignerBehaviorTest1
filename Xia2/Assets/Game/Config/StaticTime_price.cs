using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticTime_price : csvDataParent{

	private volatile static StaticTime_price _instance = null;
    private static readonly object lockHelper = new object();
    private StaticTime_price(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticTime_price Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticTime_price();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}