using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticChapter_star : csvDataParent{

	private volatile static StaticChapter_star _instance = null;
    private static readonly object lockHelper = new object();
	private StaticChapter_star(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticChapter_star Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticChapter_star();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}