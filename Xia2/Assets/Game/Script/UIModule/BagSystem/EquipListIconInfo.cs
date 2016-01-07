using UnityEngine;
using System.Collections;

public class EquipListIconInfo : MonoBehaviour {
	public UISprite Border;
	public UISprite BackGround;
	public UISprite Icon;
	public long guid{get; set;}
	public int type = 0;
	// Use this for initialization
	void Start () 
	{
		//Icon.width = BackGround.width;
		//Icon.height = BackGround.height;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void OnClick()
	{
		if(guid <= 0)
		{
			return;
		}
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		if(null == data)
		{
			return;
		}
		EquipmentItem item = data.equipmentList.getItemByType(type);
		if(null == item)
		{
			return;
		}
		BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
		if(null != manager)
		{
			manager.showEquipInfo(item);
		}

		MonoInstancePool.getInstance<HeroManager>().curShowEquipType = type;
	}
}
