using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticMission : csvDataParent{

	private volatile static StaticMission _instance = null;
    private static readonly object lockHelper = new object();
    private StaticMission(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticMission Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticMission();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}