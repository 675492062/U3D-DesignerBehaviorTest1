using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticCombo : csvDataParent{

	private volatile static StaticCombo _instance = null;
    private static readonly object lockHelper = new object();
	private StaticCombo(){}

	public static StaticCombo Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticCombo();
					_instance.readData();
				}
            }
        }
        return _instance;
    }


}