using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticMaterial : csvDataParent{

	private volatile static StaticMaterial _instance = null;
    private static readonly object lockHelper = new object();
    private StaticMaterial(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticMaterial Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticMaterial();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}