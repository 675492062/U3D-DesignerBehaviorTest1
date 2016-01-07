using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticBloodsoul : csvDataParent{

	private volatile static StaticBloodsoul _instance = null;
    private static readonly object lockHelper = new object();
	private StaticBloodsoul(){}
	public static StaticBloodsoul Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticBloodsoul();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}