/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-22   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class StaticEquip_forge_formula : csvDataParent
{
    private volatile static StaticEquip_forge_formula _instance = null;
    private static readonly object lockHelper = new object();
    private StaticEquip_forge_formula() { }
//	private  Dictionary<int, int> dict = new  Dictionary<int, int>();
    public static StaticEquip_forge_formula Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                    _instance = new StaticEquip_forge_formula();
                    _instance.readData();
				}
            }
        }
        return _instance;
    }
    
}
