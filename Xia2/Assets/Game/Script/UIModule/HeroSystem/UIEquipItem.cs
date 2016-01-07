using UnityEngine;
using System.Collections;

public class UIEquipItem : MonoBehaviour {

	public UISprite Icon;
	public UISprite Quality;
	public UISprite UPArrow;

	int m_EquipType;
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
		if(item == null)
			return;
		m_EquipType = item.equitype;
		Icon.spriteName = item.icon;
		Quality.spriteName = item.getQualityBoundImgName();
		UPArrow.gameObject.SetActive (false);
	}
	public void setEmpty()
	{
		UPArrow.gameObject.SetActive (false);
		Icon.spriteName = "";
	}
	public void showLeveUpArrow()
	{

	}
	public void showChangeArrow()
	{

	}
	public void OnClick()
	{
		HeroSysModules modules = (HeroSysModules)FindObjectOfType (typeof(HeroSysModules));
		if(modules)
		{
			modules.hideLeftMiddleWindow();
			modules.showEquipInfoWindowRight();
			modules.curFilterType = m_EquipType;

			HeroData  data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
			if(null == data)
				return;
			EquipmentItem item = data.equipmentList.getItemByType(m_EquipType);
			if(null != item)
			{
				EquipmentInfoWindow window = modules.EquipmentInfoWindowRight.GetComponent<EquipmentInfoWindow>();
				if(window != null)
				{
					window.refresh(item);
				}
			}
		}
	}
}
