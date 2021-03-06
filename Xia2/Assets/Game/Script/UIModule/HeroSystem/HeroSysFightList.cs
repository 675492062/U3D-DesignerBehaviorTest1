using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeroSysFightList : MonoBehaviour {
	public UILabel FightNum;

	public int enterType = 0;
	public const int MAX_FIGHT_NUM = 9; 
	public FightListItem[] UIItemlist = new FightListItem[MAX_FIGHT_NUM];//固定9个位置

	public enum E_Type
	{
		E_NORMAL,
		E_SET,
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirty)
		{
			MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirty = false;
			refreshList();
		}
	}
	public void refreshList()
	{
		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
		Dictionary<int, long> data = list.getFightHeroDict ();
		int startTemplatID = 850000;
		for(int i = 0; i  < MAX_FIGHT_NUM; i++)
		{
			int openLevel = StaticGlobal_parameter.Instance().getInt(i+2 + startTemplatID, "parameter");
			int curLevel = MonoInstancePool.getInstance<UserData>().level;
			if(curLevel < openLevel)
			{
				UIItemlist[i].showLocked(openLevel);
				continue;
			}
			if(data.ContainsKey(i))
			{
				HeroData hero = MonoInstancePool.getInstance<HeroManager> ().getHero(data[i]);
				if(null != hero)
				{
					UIItemlist[i].refresh(hero);
				}
			}
			else
			{
				UIItemlist[i].showEmpty();
			}
		}
	}
}
