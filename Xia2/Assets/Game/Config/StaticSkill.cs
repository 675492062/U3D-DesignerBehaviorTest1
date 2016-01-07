using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticSkill : csvDataParent
{

    private volatile static StaticSkill _instance = null;
    private static readonly object lockHelper = new object();
    private StaticSkill() { }
//    private Dictionary<int, int> dict = new Dictionary<int, int>();
    public static StaticSkill Instance()
    {
        if (_instance == null)
        {
            lock (lockHelper)
            {
                if (_instance == null)
                {
                    _instance = new StaticSkill();
//#if UNITY_EDITOR
                    _instance.readData();
//#endif
                }
            }
        }
        return _instance;
    }
}