using UnityEngine;
using System.Collections;

public class EquipmentPutOff : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		int type = MonoInstancePool.getInstance<HeroManager>().curShowEquipType;
		EquipmentItem item = data.equipmentList.getItemByType(type);
		
		var UI_manager = (UIManager)FindObjectOfType(typeof(UIManager));
		if(null == UI_manager)
		{
			return;
		}
		
		MonoInstancePool.getInstance<SendItemSystemMsgHander>().SendPutOffEquipment(item.guid, (ulong)data.guid);
		UI_manager.hide("EquipmentInfoUI");
	}

}
