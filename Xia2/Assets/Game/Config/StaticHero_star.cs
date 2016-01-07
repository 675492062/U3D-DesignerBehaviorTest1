using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticHero_star : csvDataParent{

	private volatile static StaticHero_star _instance = null;
    private static readonly object lockHelper = new object();
    private StaticHero_star(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticHero_star Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticHero_star();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}