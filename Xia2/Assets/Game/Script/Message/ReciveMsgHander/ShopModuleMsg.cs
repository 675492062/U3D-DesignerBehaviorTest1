using UnityEngine;
using System.Collections;

public class ShopModuleMsg : MonoBehaviour {
	public int parse(SocketModel module)
	{
		switch (module.messageID)
		{
			//shop
			case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_GET_SHOP_ITEM_LIST: // 获取商品列表
				onGetShopList(module);
				break;
			case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_REFRESH_SHOP_ITEM_LIST: // 刷新商品列表
				onRefreshShopList(module);
				break;
			case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_BUY_SHOP_ITEM: // 购买商品
				onBuyItem(module);
				break;
			case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_SELL_ITEM: // 出售商品
				onSellItem(module);
				break;
			default:
				return -1;
		}
		return 0;
	}
	
	public void onGetShopList(SocketModel module)
	{
		//获取商品列表
		ItemMessage.MsgGetShopItemListRep msg = MsgSerializer.Deserialize<ItemMessage.MsgGetShopItemListRep>(module);
		int shopId = msg.idx;
		ShopManager shopManager = MonoInstancePool.getInstance<ShopManager>();
		shopManager.ClearShopInfo(shopId);
        for (int i = 0; i < msg.itemList.Count; i++)
        {
			Property.ShopItem item = msg.itemList[i];
			ShopItem baseItem = ParseItem(item);
			baseItem.shopId = msg.idx;
//			Debug.LogError("shopInfo , id : " + shopId + " , idx : " + baseItem.idx + " , num : " + baseItem.num + " , type :" + baseItem.type + " , empty : " + baseItem.empty);
        	shopManager.AddShopItem(shopId , baseItem.idx , baseItem);
        }
    	Shop shop = new Shop();
    	shop.id = shopId;
    	shop.freshCount = msg.refreshCount;
    	shopManager.AddShop(shopId , shop);
        shopManager.ChangedNotify = true;
	}
	
	ShopItem ParseItem(Property.ShopItem item){
		ShopItem baseItem = ShopItemFactory.CreateOneItem(item.type);
		baseItem.id = (int)item.templateid;
		baseItem.num = (int)item.number;
		baseItem.empty = item.empty;
		baseItem.idx = (int)item.idx;
		baseItem.priceType = (int)item.moneytype;
		return baseItem;
	}
	
	public void onRefreshShopList(SocketModel module)
	{
		//刷新商品列表
        ItemMessage.MsgRefreshShopItemListRep msg = MsgSerializer.Deserialize<ItemMessage.MsgRefreshShopItemListRep>(module);
		ShopManager shopManager = MonoInstancePool.getInstance<ShopManager>();
		int shopId = msg.idx;
		shopManager.ClearShopInfo(shopId);
        for (int i = 0; i < msg.itemList.Count; i++)
        { 
            Property.ShopItem item = msg.itemList[i];
            ShopItem baseItem = ParseItem(item);
            baseItem.shopId = shopId;
			MonoInstancePool.getInstance<ShopManager>().AddShopItem(shopId ,baseItem.idx , baseItem);
        }

        if (msg.refresh_type == (int)ItemMessage.ENUM_TYPE.ENUM_TYPE_MANUAL)
        {
            int money_type = msg.moneyType;
            int money = msg.money;

            MonoInstancePool.getInstance<UserData>().subMoney(money_type, money);
        }
        shopManager.GetShopById(shopId).freshCount = msg.refreshCount;
		shopManager.ChangedNotify = true;
	}
	
	public void onBuyItem(SocketModel module)
	{
        ItemMessage.MsgBuyItemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgBuyItemRep>(module);
		uint shopId = msg.idx;
		
		ShopItem item = MonoInstancePool.getInstance<ShopManager>().GetShopItemById((int)shopId ,(int)msg.gridId);
        item.empty = true;
		item.ChangedNotify = true;
		Debug.LogError("[ShopModuleMsg] : onBuyItem " + item.idx);
		
//        int money_type = (int)msg.needMoneyType;
//        int money = (int)msg.needMoney;
//        MonoInstancePool.getInstance<UserData>().subMoney(money_type, money);
//
//        BaseItem baseItem = MonoInstancePool.getInstance<BagManager>().createItemByData(msg.item);
//        MonoInstancePool.getInstance<BagManager>().getNormalBag().addItem(baseItem);
//        MonoInstancePool.getInstance<BagManager>().getNormalBag().IsDirty = true;
	}
	
	public void onSellItem(SocketModel module)
	{
		ItemMessage.MsgSellItemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgSellItemRep>(module);
		
		long guid = (long)msg.itemGuid;
		int num = msg.number;
		if (num <= 0)
		{
			MonoInstancePool.getInstance<BagManager>().getNormalBag().removeItem(guid);
		}
		else
		{
			MonoInstancePool.getInstance<BagManager>().getNormalBag().setItemNum(guid, num);
		}
		MonoInstancePool.getInstance<BagManager>().getNormalBag().IsDirty = true;
		
		int money = (int)msg.getMoney;
		MonoInstancePool.getInstance<UserData>().addMoney((int)GlobalDef.MoneyType.MONEY_GOLD, money);
	}
}
