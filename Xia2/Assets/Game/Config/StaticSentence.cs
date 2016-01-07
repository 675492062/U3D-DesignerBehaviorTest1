using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticSentence : csvDataParent{

	private volatile static StaticSentence _instance = null;
    private static readonly object lockHelper = new object();
    private StaticSentence(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticSentence Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticSentence();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
}