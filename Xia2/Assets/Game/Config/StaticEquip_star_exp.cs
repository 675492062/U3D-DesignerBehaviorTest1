using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticEquip_star_exp : csvDataParent{

	private volatile static StaticEquip_star_exp _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_star_exp(){}
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
	public static StaticEquip_star_exp Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticEquip_star_exp();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }


}