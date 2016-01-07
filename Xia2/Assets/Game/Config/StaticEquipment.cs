using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticEquipment : csvDataParent{

	private volatile static StaticEquipment _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquipment(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticEquipment Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticEquipment();
//#if UNITY_EDITOR
					_instance.readData();
//#endif
				}
            }
        }
        return _instance;
    }
}