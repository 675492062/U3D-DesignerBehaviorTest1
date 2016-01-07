/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-09-25   Lee      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;


public class Bufftem : BaseItem
{
  //  public int buffid { get { return StaticSkill.Instance().getStr(templateID, "icon"); } }                            //< 技能图标
 

	public Bufftem() { }

	private static Bufftem _instance = null;
	public static Bufftem Instance( int id )
	{
		if (_instance == null) {
			_instance = new Bufftem();
		}
		return _instance;
	}
}
