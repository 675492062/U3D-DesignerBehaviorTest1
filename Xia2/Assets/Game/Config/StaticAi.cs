using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticAi : csvDataParent{

	private volatile static StaticAi _instance = null;
    private static readonly object lockHelper = new object();
	private StaticAi(){}

	public static StaticAi Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticAi();
					_instance.readData();
				}
            }
        }
        return _instance;
    }


}