using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticHero_state : csvDataParent{

	private volatile static StaticHero_state _instance = null;
    private static readonly object lockHelper = new object();
    private StaticHero_state(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticHero_state Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticHero_state();
					#if UNITY_EDITOR
					_instance.readData();
					#endif
				}
            }
        }
        return _instance;
    }
}