using UnityEngine;
using System.Collections;

public class EquipmentPutOn : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void OnClick()
	{
		BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
		if(manager == null)
		{
			return;
		}
		int curType = 1;//manager.curBagType;
		int curIdx = manager.curSelectIdx;
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(curType);
		if(bag == null)
		{
			return;
		}
		int heroIdx = MonoInstancePool.getInstance<HeroManager>().curSelectHero;
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		EquipmentItem item = bag.getItemByIdx(curIdx) as EquipmentItem;
		var UI_manager = (UIManager)FindObjectOfType(typeof(UIManager));
		if(null == UI_manager)
		{
			return;
		}
		if(item.needrole != data.heroType)
		{
			ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(error != null)
			{
				error.showErrorWindow("type error! heroType: " + data.heroType + " itemNeedType: " + item.needrole);
			}
			UI_manager.hide("EquipmentInfoUI");
			return;
		}
		
		long guid = item.guid;
		HeroManager ma = MonoInstancePool.getInstance<HeroManager>();
		long hero_guid = ma.getHeroByIdx(heroIdx).guid;
		MonoInstancePool.getInstance<SendItemSystemMsgHander>().SendPutOnEquipment(guid, hero_guid);
		
		UI_manager.hide("EquipmentInfoUI");
	}
}
