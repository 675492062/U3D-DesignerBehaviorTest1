using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticEquip_intensify : csvDataParent{

	private volatile static StaticEquip_intensify _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_intensify(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticEquip_intensify Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticEquip_intensify();
					_instance.readData();
				}
            }
        }
        return _instance;
    }

}