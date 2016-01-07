/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class StaticEquip_intensify_trigger : csvDataParent
{
    private volatile static StaticEquip_intensify_trigger _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_intensify_trigger() { }
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
    public static StaticEquip_intensify_trigger Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                    _instance = new StaticEquip_intensify_trigger();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
    
}
