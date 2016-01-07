using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticBuff : csvDataParent{

	private volatile static StaticBuff _instance = null;
    private static readonly object lockHelper = new object();
	private StaticBuff(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticBuff Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticBuff();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}