using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticHero : csvDataParent{

	private volatile static StaticHero _instance = null;
    private static readonly object lockHelper = new object();
    private StaticHero(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticHero Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticHero();
                     _instance.readData();
				}
            }
        }
        return _instance;
    }
}