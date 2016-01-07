using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticEquip_intensify_attribute : csvDataParent{

	private volatile static StaticEquip_intensify_attribute _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_intensify_attribute(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticEquip_intensify_attribute Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticEquip_intensify_attribute();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }


}