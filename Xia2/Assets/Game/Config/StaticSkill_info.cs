using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticSkill_info : csvDataParent
{
	
	private volatile static StaticSkill_info _instance = null;
	private static readonly object lockHelper = new object();
	private StaticSkill_info() { }
	//    private Dictionary<int, int> dict = new Dictionary<int, int>();
	public static StaticSkill_info Instance()
	{
		if (_instance == null)
		{
			lock (lockHelper)
			{
				if (_instance == null)
				{
					_instance = new StaticSkill_info();
					//#if UNITY_EDITOR
					_instance.readData();
					//#endif
				}
			}
		}
		return _instance;
	}
}