/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class StaticEquip_smelt : csvDataParent
{

    private volatile static StaticEquip_smelt _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_smelt() { }

    public static StaticEquip_smelt Instance()
    {
        if (_instance == null)
        {
            lock (lockHelper)
            {
                if (_instance == null)
                {
                    _instance = new StaticEquip_smelt();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
                }
            }
        }
        return _instance;
    }
}
