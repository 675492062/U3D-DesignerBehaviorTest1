using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticCompetition_settlement : csvDataParent{

	private volatile static StaticCompetition_settlement _instance = null;
    private static readonly object lockHelper = new object();
	private StaticCompetition_settlement(){}

	public static StaticCompetition_settlement Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
					_instance = new StaticCompetition_settlement();
					_instance.readData();
				}
            }
        }
        return _instance;
    }


}