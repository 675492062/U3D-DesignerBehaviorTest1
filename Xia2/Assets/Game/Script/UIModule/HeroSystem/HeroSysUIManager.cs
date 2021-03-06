using UnityEngine;
using System.Collections;

public class HeroSysUIManager : MonoBehaviour {

	public HeroListWindowManager HeroListWindow;
	public HeroSysAddExpWindow AddExpWindow;
	public HeroSysMapWindow MapWindow;
	public HeroSysFightList FightListWindow;
	
	enum state_window
	{
		EXP_WINDOW = 1,      //吃经验窗口 
		MAP_WINDOW = 2,      //碎片掉落地图窗口 
		FIGHTLIST_WINDOW = 3,//战队窗口
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	void OnEnable()
	{
		AddExpWindow.gameObject.SetActive (false);
		MapWindow.gameObject.SetActive (false);
		FightListWindow.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void showWindow(int state)
	{
		switch(state)
		{
		case (int)state_window.EXP_WINDOW:
			showExpWindow();
			hideDebirsWindow();
			break;
		case (int)state_window.MAP_WINDOW:
			showDebirsWindow();
			hideExpWindow();
			break;
		case (int)state_window.FIGHTLIST_WINDOW:
			showFightListWindow();
			hideExpWindow();
			hideDebirsWindow();
			MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirty = true;
			break;
		}
	}
	//显示碎片窗口
	public void showDebirsWindow()
	{
		if(MapWindow != null)
		{
			MapWindow.gameObject.SetActive(true);
			HeroListWindowManager manager = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
			if(manager != null)
			{
				manager.highLightShow();
			}
		}
	}
	//隐藏碎片窗口
	public void hideDebirsWindow()
	{
		if(MapWindow != null)
		{
			MapWindow.gameObject.SetActive(false);
			FightListWindow.refreshList();
		}
	}
	//显示吃经验窗口
	public void showExpWindow()
	{
		if(AddExpWindow != null)
		{
			AddExpWindow.gameObject.SetActive(true);
			AddExpWindow.refreshExpItems();

			HeroListWindowManager manager = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
			if(manager != null)
			{
				manager.highLightShow();
			}
		}
	}
	//隐藏吃经验窗口
	public void hideExpWindow()
	{
		if(AddExpWindow != null)
		{
			AddExpWindow.gameObject.SetActive(false);
			FightListWindow.refreshList();
		}
	}
	//显示战队界面
	public void showFightListWindow(int enterType = 0) //0:普通进入 1:选择出战位置 
	{
		if(FightListWindow != null)
		{
			FightListWindow.gameObject.SetActive(true);
			HeroSysFightList list = FightListWindow.GetComponentInChildren<HeroSysFightList>();
			list.enterType = enterType;
		}
	}
	//隐藏战队界面
	public void hideFightListWindow()
	{
		if(FightListWindow != null)
		{
			FightListWindow.gameObject.SetActive(false);
			FightListWindow.refreshList();
		}
	}
}
