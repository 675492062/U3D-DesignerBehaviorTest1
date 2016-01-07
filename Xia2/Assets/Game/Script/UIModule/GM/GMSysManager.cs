using UnityEngine;
using System.Collections;

public class GMSysManager : MonoBehaviour {
	public UIButton AddGold;
	public UIButton AddLevel;
	public UIButton AddHero;
	public UIInput  HeroTemplateID;
	public UIButton AddSoulPoint;

	public UIButton HeroLvUP;
	public UIPopupList heroList;

	public UIButton buyStamina;
	public UILabel labelStaminaInfo;

	public UIInput FightPos;
	void Awake(){
		UIEventListener.Get(buyStamina.gameObject).onClick += BuyStamina;
	}
	// Use this for initialization
	void Start () 
	{
		refreshHeroList ();
	}
	
	void BuyStamina(GameObject sender){
		MonoInstancePool.getInstance<SendUserDataMsgHander>().SendBuyStaminaReq();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UserData userData = MonoInstancePool.getInstance<UserData>();
		string stamaInfo = "StamaInfo : num = " + userData.stamina + " duration : " + (int)userData.staminaInfo.durationTime + " \nboughtCount : " + userData.staminaInfo.boughtCount + 
			" boughtCountLimit: " + userData.staminaInfo.boughtCountLimit + " \nmaxLimit " + userData.staminaInfo.maxLimit + " buyPrice : " + userData.staminaInfo.price;
		labelStaminaInfo.text = stamaInfo;
	}
	public void refreshHeroList()
	{
		HeroManager manager = MonoInstancePool.getInstance<HeroManager> ();
		if(manager == null)
		{
			return;
		}
		heroList.items.Clear ();
//		herosList4.items.Clear ();
		int count = manager.getCount ();
		for(int i = 0; i < count; i++)
		{
			HeroData data = manager.getHeroByIdx(i);
			if(null == data)
			{
				continue;
			}
			heroList.items.Add(data.name);
		}
	}
	public void refresh()
	{
		refreshHeroList ();
	}
	public void addGold()
	{
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(1000,"AddGold");
	}
	public void addGem()
	{
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(1000,"AddDiamond");
	}
	public void addLevel()
	{
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(10,"AddLevel");
	}
	public void addHero()
	{
		int templateID = System.Int32.Parse(HeroTemplateID.value);
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(templateID,"AddHero");
	}
	public void addSoulPoint()
	{
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(100,"AddSoul");
	}
	
	public void heroLvUP()
	{
		string cur = heroList.value;
		int idx = 0;
		string name = heroList.value;
		heroList.items.FindIndex ( delegate(string t)  
		   {  
			for(int i = 0 ;i < heroList.items.Count; i++)
			{
				if(string.Compare(heroList.items[i], name) == 0)
				{
					idx = i;
					return true;
				}
			}
			return false;
		});
		HeroManager manager = MonoInstancePool.getInstance<HeroManager> ();
		if(manager == null)
		{
			return;
		}
		HeroData data = manager.getHeroByIdx (idx);
		if(null == data)
		{
			return;
		}
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(10,"HeroLvUp", data.guid);
	}
	public void lightRealm()
	{
		string cur = heroList.value;
		int idx = 0;
		string name = heroList.value;
		heroList.items.FindIndex ( delegate(string t)  
		                           {  
			for(int i = 0 ;i < heroList.items.Count; i++)
			{
				if(string.Compare(heroList.items[i], name) == 0)
				{
					idx = i;
					return true;
				}
			}
			return false;
		});
		HeroManager manager = MonoInstancePool.getInstance<HeroManager> ();
		if(manager == null)
		{
			return;
		}
		HeroData data = manager.getHeroByIdx (idx);
		if(null == data)
		{
			return;
		}
		MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendUpgradeRealm(data.guid, data.realmList.curRealmLevel);
	}
	public void heroStarUP()
	{
		string cur = heroList.value;
		int idx = 0;
		string name = heroList.value;
		heroList.items.FindIndex ( delegate(string t)  
		                           {  
			for(int i = 0 ;i < heroList.items.Count; i++)
			{
				if(string.Compare(heroList.items[i], name) == 0)
				{
					idx = i;
					return true;
				}
			}
			return false;
		});
		HeroManager manager = MonoInstancePool.getInstance<HeroManager> ();
		HeroData data = manager.getHeroByIdx (idx);
		if(null == data)
		{
			return;
		}
		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().SendUpgradeStarlv(data.guid);
	}
	public void addHeroDebris() //
	{
//		UIInput input = AddHeroDebirs.GetComponentInChildren<UIInput>();
//		if(string.Compare("", input.value) == 0)
//		{
//			return;
//		}
//		int templateID = System.Int32.Parse (input.value);
//		MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(30,"AddHeroDebris", templateID);
	}
	public void setFightPos()
	{
		string cur = heroList.value;
		int idx = 0;
		string name = heroList.value;
		heroList.items.FindIndex ( delegate(string t)  
		                          {  
			for(int i = 0 ;i < heroList.items.Count; i++)
			{
				if(string.Compare(heroList.items[i], name) == 0)
				{
					idx = i;
					return true;
				}
			}
			return false;
		});
		HeroManager manager = MonoInstancePool.getInstance<HeroManager> ();
		HeroData data = manager.getHeroByIdx (idx);
		if(null == data)
		{
			return;
		}
		int pos = System.Int32.Parse(FightPos.value);
		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendSetFightHeroReq (data.guid, pos);
	}
}
