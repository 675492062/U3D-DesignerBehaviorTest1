using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticPotion : csvDataParent{

	private volatile static StaticPotion _instance = null;
    private static readonly object lockHelper = new object();
    private StaticPotion(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticPotion Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticPotion();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}