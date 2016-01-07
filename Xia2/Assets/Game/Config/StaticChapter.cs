using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticChapter : csvDataParent{

	private volatile static StaticChapter _instance = null;
    private static readonly object lockHelper = new object();
	private StaticChapter(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticChapter Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticChapter();
					_instance.readData();
				}
            }
        }
        return _instance;
    }
}