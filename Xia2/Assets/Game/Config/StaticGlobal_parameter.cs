using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticGlobal_parameter : csvDataParent{

	private volatile static StaticGlobal_parameter _instance = null;
    private static readonly object lockHelper = new object();
	private StaticGlobal_parameter(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticGlobal_parameter Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticGlobal_parameter();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}