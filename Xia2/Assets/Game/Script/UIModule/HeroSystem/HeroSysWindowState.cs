using UnityEngine;
using System.Collections;

public class HeroSysWindowState : MonoBehaviour {

	public int open_state = 0;
	public UIButton parentItem;
	void OnClick()
	{
		if(open_state == 3) //打开阵容界面
		{
			HeroSysUIManager manager = (HeroSysUIManager)FindObjectOfType(typeof(HeroSysUIManager));
			if(manager != null)
			{
				manager.showWindow(open_state);
			}
		}
		else  //打开经验和地图界面
		{
			//set selectedIdx
			HeroItemProperty pro = parentItem.GetComponentInChildren<HeroItemProperty> ();
			if(pro == null)
			{
				return;
			}
			HeroListWindowManager list = (HeroListWindowManager)FindObjectOfType (typeof(HeroListWindowManager));
			if(list != null)
			{
				list.curSlectedIdx = pro.idx;
			}
			HeroSysUIManager manager = (HeroSysUIManager)FindObjectOfType(typeof(HeroSysUIManager));
			if(manager != null)
			{
				manager.showWindow(open_state);
			}
		}
	}
}
