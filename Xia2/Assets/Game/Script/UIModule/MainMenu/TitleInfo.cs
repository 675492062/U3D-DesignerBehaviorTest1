using UnityEngine;
using System.Collections;

public class TitleInfo : MonoBehaviour {
	public UILabel level;
	public UILabel name;
	public UISprite back;

	public UISprite []stars = new UISprite[5];
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void setStar(int star)
	{
		for(int i = 0; i < stars.Length; i++)
		{
			if(i < star)
			{
				stars[i].gameObject.SetActive(true);
				stars[i].spriteName = "hb_20";
				Vector3 pos = Vector3.zero;
				pos.x += i * stars[i].width + 6;
				stars[i].transform.localPosition = pos;
			}
			else 
			{
				stars[i].gameObject.SetActive(false);
			}
		}
		int width = (star-1) * stars [0].width + (star - 1) * 6;
		Vector3 parentPos = stars [0].transform.parent.localPosition;
		parentPos.x = 0;
		parentPos.x -= width / 2;
		stars [0].transform.parent.localPosition = parentPos;

	}
	public void hide()
	{
		level.gameObject.SetActive (false);
		name.gameObject.SetActive (false);
		back.gameObject.SetActive (false);
		for(int i = 0; i < stars.Length; i++)
		{
			stars[i].gameObject.SetActive(false);
		}
	}
	public void show()
	{
		level.gameObject.SetActive (true);
		name.gameObject.SetActive (true);
		back.gameObject.SetActive (true);
		for(int i = 0; i < stars.Length; i++)
		{
			stars[i].gameObject.SetActive(true);
		}
	}
	public void clickCenterHero()
	{
		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
		bool has = list.hasKey (0);
		if(has)
		{
			long guid = list.getGuidByKey(0);
			int idx = MonoInstancePool.getInstance<HeroManager>().getIdxByGUID(guid);
			MonoInstancePool.getInstance<HeroManager>().curSelectHero = idx;
			MonoInstancePool.getInstance<HeroManager>().curSelectHeroGUID = guid;

			var manager = (UIManager)FindObjectOfType(typeof(UIManager));
			manager.show("HeroSubSystemUI");

			BagUIManager bag = manager.GetComponentInChildren<BagUIManager>();
			bag.curSelectIdx = idx;
			bag.curSelectGUID = guid;
			bag.refreshAllData();
		}
	}
	public void clickLeftHero()
	{
		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
		bool has = list.hasKey (1);
		if(has)
		{
			long guid = list.getGuidByKey(1);
			int idx = MonoInstancePool.getInstance<HeroManager>().getIdxByGUID(guid);
			MonoInstancePool.getInstance<HeroManager>().curSelectHero = idx;
			MonoInstancePool.getInstance<HeroManager>().curSelectHeroGUID = guid;

			var manager = (UIManager)FindObjectOfType(typeof(UIManager));
			manager.show("HeroSubSystemUI");

			BagUIManager bag = manager.GetComponentInChildren<BagUIManager>();
			bag.curSelectIdx = idx;
			bag.curSelectGUID = guid;
			bag.refreshAllData();
		}
	}
	public void clickRightHero()
	{
		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
		bool has = list.hasKey (2);
		if(has)
		{
			long guid = list.getGuidByKey(2);
			int idx = MonoInstancePool.getInstance<HeroManager>().getIdxByGUID(guid);
			MonoInstancePool.getInstance<HeroManager>().curSelectHero = idx;
			MonoInstancePool.getInstance<HeroManager>().curSelectHeroGUID = guid;

			var manager = (UIManager)FindObjectOfType(typeof(UIManager));
			manager.show("HeroSubSystemUI");

			BagUIManager bag = manager.GetComponentInChildren<BagUIManager>();
			bag.curSelectIdx = idx;
			bag.curSelectGUID = guid;
			bag.refreshAllData();
		}
	}
}
