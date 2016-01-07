using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class StaticSkilllevel : csvDataParent
{

	private volatile static StaticSkilllevel _instance = null;
    private static readonly object lockHelper = new object();
	private StaticSkilllevel() { }
//    private Dictionary<int, int> dict = new Dictionary<int, int>();
	public static StaticSkilllevel Instance()
    {
        if (_instance == null)
        {
            lock (lockHelper)
            {
                if (_instance == null)
                {
					_instance = new StaticSkilllevel();
//#if UNITY_EDITOR
                    _instance.readData();
//#endif
                }
            }
        }
        return _instance;
    }
}