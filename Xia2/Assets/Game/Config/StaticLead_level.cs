using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticLead_level : csvDataParent{

	private volatile static StaticLead_level _instance = null;
    private static readonly object lockHelper = new object();
    private StaticLead_level(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticLead_level Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticLead_level();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}