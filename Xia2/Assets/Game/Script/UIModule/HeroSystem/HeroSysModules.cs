using UnityEngine;
using System.Collections;

public class HeroSysModules : MonoBehaviour 
{
	public HeroItemProperty headInfo;

	//left
	public Transform PropertyWindow;
	public Transform EquipmentBagWindow;
	//left middle
	public Transform PropertyInfoWindow;
	public Transform SkillInfo_Window;
	public Transform RealmWindow;
	public Transform RealmGetWindow;
	public Transform KillSkillInfoWindow;
	public Transform MedicineWindow;
	public Transform FateWindow;
	public Transform EquipmentInfoWindowLeft;
	//right middle
	public Transform EquipmentInfoWindowRight;
	//right
	public Transform EquipmentListWindow;


	/// 当前背包的过滤类型
	public int curFilterType{ get; set;}  
	void OnEnable()
	{
		if(headInfo != null)
		{
			HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
			headInfo.heroGuid = data.guid;
			headInfo.updateLvBar(data);
			headInfo.stopTempExpAni();  //headInfo.refreshInfo(data);这里面会调用一次刷新
			headInfo.hideFightIcon();
			headInfo.updateLvBar(data);
		}

		PropertyWindow.gameObject.SetActive(false);
		PropertyInfoWindow.gameObject.SetActive(false);
		SkillInfo_Window.gameObject.SetActive(false);
		RealmWindow.gameObject.SetActive(false);
		RealmGetWindow.gameObject.SetActive(false);
		KillSkillInfoWindow.gameObject.SetActive(false);
		MedicineWindow.gameObject.SetActive(false);
		EquipmentBagWindow.gameObject.SetActive(false);
		FateWindow.gameObject.SetActive(false);
		EquipmentInfoWindowLeft.gameObject.SetActive(false);
		EquipmentInfoWindowRight.gameObject.SetActive(false);
		EquipmentListWindow.gameObject.SetActive(false);

		PropertyWindow.gameObject.SetActive(true);
		EquipmentListWindow.gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void hideLeftMiddleWindow()
	{
		if(PropertyInfoWindow.gameObject.activeSelf) 	PropertyInfoWindow.gameObject.SetActive (false);
		if(SkillInfo_Window.gameObject.activeSelf) 		SkillInfo_Window.gameObject.SetActive (false);
		if(RealmWindow.gameObject.activeSelf) 			RealmWindow.gameObject.SetActive (false);
		if(RealmGetWindow.gameObject.activeSelf) 		RealmGetWindow.gameObject.SetActive (false);
		if(KillSkillInfoWindow.gameObject.activeSelf) 	KillSkillInfoWindow.gameObject.SetActive (false);
		if(MedicineWindow.gameObject.activeSelf) 		MedicineWindow.gameObject.SetActive (false);
		if(FateWindow.gameObject.activeSelf) 			FateWindow.gameObject.SetActive (false);
		if(EquipmentInfoWindowLeft.gameObject.activeSelf) EquipmentInfoWindowLeft.gameObject.SetActive (false);
	}
	public void hideLeftWindow()
	{
		if(PropertyWindow.gameObject.activeSelf) PropertyWindow.gameObject.SetActive(false);
		if(EquipmentBagWindow.gameObject.activeSelf) EquipmentBagWindow.gameObject.SetActive(false);
	}
	public void hideRightMiddleWindow()
	{
		if(EquipmentInfoWindowRight.gameObject.activeSelf) EquipmentInfoWindowRight.gameObject.SetActive (false);
	}


	public void showFateWindow()
	{
		hideLeftMiddleWindow ();
		if(!FateWindow.gameObject.activeSelf)FateWindow.gameObject.SetActive (true);
	}
	public void showRealmWindow()
	{
		hideLeftMiddleWindow ();
		if(!RealmWindow.gameObject.activeSelf) RealmWindow.gameObject.SetActive (true);
	}
	public void showRealmPropertyWindow()
	{
		hideLeftMiddleWindow ();
		if(!RealmGetWindow.gameObject.activeSelf) RealmGetWindow.gameObject.SetActive (true);
	}
	public void showSkinWinddow()
	{
		UIManager manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if(manager != null)
		{
			manager.hide("HeroSysModules");
			manager.show("HeroSysSkinWindow");
		}
	}
	public void showEquipBagWindow()
	{
		hideLeftWindow ();
		hideLeftMiddleWindow ();
		if(!EquipmentBagWindow.gameObject.activeSelf) EquipmentBagWindow.gameObject.SetActive(true);

		HeroSysEquipBagWindow bag = EquipmentBagWindow.GetComponent<HeroSysEquipBagWindow> ();
		if (bag != null) 
		{
			bag.refreshBagState(curFilterType);		
		}
	}
	public void showEquipInfoWindowRight()
	{
		if(!EquipmentInfoWindowRight.gameObject.activeSelf) EquipmentInfoWindowRight.gameObject.SetActive(true);
	}
	public void showEquipInfoWindowLeft()
	{
		if(!EquipmentInfoWindowLeft.gameObject.activeSelf) EquipmentInfoWindowLeft.gameObject.SetActive(true);
	}
	public void showPropertyWindow()
	{
		hideLeftWindow ();
		hideLeftMiddleWindow ();
		hideRightMiddleWindow ();
		if(!PropertyWindow.gameObject.activeSelf) PropertyWindow.gameObject.SetActive (true);
	}
	public void showPropertyInfoWindow()
	{
		hideLeftMiddleWindow ();
		hideRightMiddleWindow ();
		if(!PropertyInfoWindow.gameObject.activeSelf) PropertyInfoWindow.gameObject.SetActive (true);
	}
	public void showKillSkillWindow()
	{
		hideLeftMiddleWindow ();
		hideRightMiddleWindow ();
		if(!KillSkillInfoWindow.gameObject.activeSelf) KillSkillInfoWindow.gameObject.SetActive (true);
	}
	public void showSkillInfoWindow(HeroData data, SkillItem skill, int idx)
	{
		hideLeftMiddleWindow ();
		hideRightMiddleWindow ();
		SkillInfo_Window.gameObject.SetActive (true);

		SkillInfoWindow infoWindow = SkillInfo_Window.GetComponentInChildren<SkillInfoWindow> ();
		if (infoWindow != null)
			infoWindow.refresh (data,skill, idx);
	}
	public void showMedicineWindow()
	{
		hideLeftMiddleWindow ();
		hideRightMiddleWindow ();
		MedicineWindow.gameObject.SetActive (true);
	}
}
