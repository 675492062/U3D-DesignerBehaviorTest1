using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticError : csvDataParent{

	private volatile static StaticError _instance = null;
    private static readonly object lockHelper = new object();
    private StaticError(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticError Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticError();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }

}