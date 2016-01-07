using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticLevel : csvDataParent{

	private volatile static StaticLevel _instance = null;
    private static readonly object lockHelper = new object();
    private StaticLevel(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticLevel Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticLevel();
//#if UNITY_EDITOR
                     _instance.readData();
//#endif
                }
            }
        }
        return _instance;
    }
}