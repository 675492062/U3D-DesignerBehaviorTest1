using UnityEngine;
using System;
using System.Collections;

public abstract class ShopItem : BaseItem 
{
	public bool empty{ get; set;}				// 是否售出
	
	public int idx{ get; set;}
	
	public int id{
		set{
			templateID = value;
		}
		get{
			return templateID;
		}
	}
		
	public int goodsType;							// 道具类型 1：装备类道具  2：材料类道具（种类多样） 3：药水类道具  4：宝石类道具   7.
	
	public int priceType;
	
	public int num;
	
	public int shopId;							//belong to which shop
	
	public Action changedNotifyAction;
	
	bool changedNofity;
	
	public bool ChangedNotify {
		set{
			changedNofity = value;
			if(changedNotifyAction != null)changedNotifyAction();
		}
	}
	
	public abstract string icon{get;}//{return StaticGem.Instance().getStr(templateID , "icon");}
	
	public abstract string icon_gray{get;}
	
	public abstract string name{get;}		  //{get{return StaticGem.Instance().getStr(templateID , "name");}}
	
	public abstract string maxcount{get;}	  //{get{return StaticGem.Instance().getStr(templateID , "maxcount");}}
			
	public abstract int sell2system{get;}//{get{return StaticGem.Instance().getStr(templateID , "sell2system");}}
	
	public abstract int sellprice{get;}
	
	public abstract string description{get;}//{get{return StaticGem.Instance().getStr(templateID , "description");}}
}

public class GemShopItem : ShopItem{

	public override string icon{get{return StaticGem.Instance().getStr(templateID , "icon");}}
	
	public override string icon_gray{get{return "";}}
	
	public override string name{get{return StaticGem.Instance().getStr(templateID , "name");}}
	
	public override string maxcount{get{return StaticGem.Instance().getStr(templateID , "maxcount");}}
	
	public override int sellprice{get{return StaticGem.Instance().getInt(templateID , "sellprice" + priceType);}}
	
	public override int sell2system{get{return StaticGem.Instance().getInt(templateID , "sell2system");}}
	
	public override string description{get{return StaticGem.Instance().getStr(templateID , "description");}}
}

public class MaterialShopItem : ShopItem{

	public override string icon{get{return StaticMaterial.Instance().getStr(templateID , "icon");}}
	
	public override string icon_gray{get{return "";}}
	
	public override string name{get{return StaticMaterial.Instance().getStr(templateID , "name");}}
	
	public override string maxcount{get{return StaticMaterial.Instance().getStr(templateID , "maxcount");}}
	
	public override int sellprice{get{return StaticMaterial.Instance().getInt(templateID , "sellprice" + priceType);}}
	
	public override int sell2system{get{return StaticMaterial.Instance().getInt(templateID , "sell2system");}}
	
	public override string description{get{return StaticMaterial.Instance().getStr(templateID , "description");}}
}

public class PotionShopItem : ShopItem{

	public override string icon{get{return StaticPotion.Instance().getStr(templateID , "icon");}}
	
	public override string icon_gray{get{return StaticPotion.Instance().getStr(templateID , "icon_gray");}}
	
	public override string name{get{return StaticPotion.Instance().getStr(templateID , "name");}}
	
	public override string maxcount{get{return StaticPotion.Instance().getStr(templateID , "maxcount");}}
	
	public override int sellprice{get{return StaticPotion.Instance().getInt(templateID , "sellprice" + priceType);}}
	
	public override int sell2system{get{return StaticPotion.Instance().getInt(templateID , "sell2system");}}
	
	public override string description{get{return StaticPotion.Instance().getStr(templateID , "description");}}
}

public class EquipShopItem : ShopItem{
	public override string icon{get{return StaticEquipment.Instance().getStr(templateID , "icon");}}
	
	public override string icon_gray{get{return "";}}
	
	public override string name{get{return StaticEquipment.Instance().getStr(templateID , "name");}}
	
	public override string maxcount{get{return StaticEquipment.Instance().getStr(templateID , "maxcount");}}
	
	public override int sellprice{get{return StaticEquipment.Instance().getInt(templateID , "sellprice" + priceType);}}
	
	public override int sell2system{get{return StaticEquipment.Instance().getInt(templateID , "sell2system");}}
	
	public override string description{get{return StaticEquipment.Instance().getStr(templateID , "description");}}
}

public class DebrisShopItem : ShopItem{
	public override string icon{get{return StaticHero.Instance().getStr(templateID , "icon");}}
	
	public override string icon_gray{get{return "";}}
	
	public override string name{get{return StaticHero.Instance().getStr(templateID , "name");}}
	
	public override string maxcount{get{return StaticHero.Instance().getStr(templateID , "maxcount");}}
	
	public override int sellprice{get{return StaticHero.Instance().getInt(templateID , "sellprice" + priceType);}}
	
	public override int sell2system{get{return StaticHero.Instance().getInt(templateID , "sell2system");}}
	
	public override string description{get{return StaticHero.Instance().getStr(templateID , "description");}}
}

public class ShopItemFactory{

	public static ShopItem CreateOneItem(int type){
		ShopItem item = null;
		switch(type){
			case 1:
				item = new EquipShopItem();
				item.goodsType = type;
				break;
			case 2:
				item =  new MaterialShopItem();
				item.goodsType = type;
				break;
			case 3:
				item = new PotionShopItem();
				item.goodsType = type;
				break;
			case 4:
				item = new GemShopItem();
				item.goodsType = type;
				break;
			case 7:
				item = new DebrisShopItem();
				item.goodsType = 7;
				break;
			default :
				Debug.LogError("[ShopItemFactory.] cannot build one shopitem by the type : " + type);
				item = new EquipShopItem();
				item.goodsType = 1;
				break;
		}
		return item;
	}
}