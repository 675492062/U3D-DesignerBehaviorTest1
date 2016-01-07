using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticDialog : csvDataParent{

	private volatile static StaticDialog _instance = null;
    private static readonly object lockHelper = new object();
    private StaticDialog(){}

	public static StaticDialog Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticDialog();
					_instance.readData();
				}
            }
        }
        return _instance;
    }


}