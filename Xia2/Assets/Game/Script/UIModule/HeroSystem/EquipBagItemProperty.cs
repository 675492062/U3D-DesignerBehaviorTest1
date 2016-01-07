using UnityEngine;
using System.Collections;

public class EquipBagItemProperty : MonoBehaviour 
{
	public UILabel Name;
	public UILabel ItemType;
	public UILabel RoleType;
	public UILabel Level;
	public UISprite Icon;
	public UISprite Quality;

	public int idx{ get; set;}  //在界面容器里面的索引
	public long itemGuid{ get; set;}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void refresh(EquipmentItem item)
	{
		Name.text = item.name;
		Icon.spriteName = item.icon;
		ItemType.text = item.getItemType ();
		RoleType.text = item.getRoleLimit ();
		Level.text = "" + item.equiplev + "级";
		Quality.spriteName = item.getQualityBoundImgName();
	}
	void OnClick()
	{
		HeroSysModules modules = (HeroSysModules)FindObjectOfType (typeof(HeroSysModules));
		if(modules)
		{
			modules.hideRightMiddleWindow();
			modules.hideLeftMiddleWindow();
			modules.showEquipInfoWindowLeft();


			HeroData  data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
			if(null == data)
				return;
			EquipmentItem item = (EquipmentItem)MonoInstancePool.getInstance<BagManager>().getEquipmentBag().getItem(itemGuid);
			if(null != item)
			{
				EquipmentInfoWindow window = modules.EquipmentInfoWindowLeft.GetComponent<EquipmentInfoWindow>();
				if(window != null)
				{
					window.refresh(item);
				}
			}
			//refresh select border
			HeroSysEquipBagWindow bag = (HeroSysEquipBagWindow)FindObjectOfType(typeof(HeroSysEquipBagWindow));
			if( bag != null )
			{
				bag.updateSelectBorderPos(idx);
			}
		}
	}
}
