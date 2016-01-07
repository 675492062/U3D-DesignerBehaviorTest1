using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum PriceType{
	None = 0,
	Gold = 1,						//银两
	Jewel = 2,						//元宝
	Arean = 3						//竞技币
}

public class Shop{
	public int id;
	
	public int freshCount;
	
	public int freshPrice{
		get{
			if(id == (int)ItemMessage.ENUM_SHOP_TYPE.ST_ARENA){
				return StaticTime_price.Instance().getInt(freshCount , "shop2");
			}
			Debug.LogError("[Shop] cannot find the shop freshPrice which id is " + id);
			return 1;
		}
	}
	
	public PriceType priceType{
		get{
			if(id == (int)ItemMessage.ENUM_SHOP_TYPE.ST_ARENA)
			{
				return PriceType.Arean;
			}
			else if(id == (int)ItemMessage.ENUM_SHOP_TYPE.ST_GENERAL)
			{
				return PriceType.Gold;
			}
			Debug.LogError("[Shop] cannot find the shop priceType which id is " + id);
			return PriceType.Arean;
		}
	}
}

public class ShopManager : MonoBehaviour {
	public Action changeNotifyAction;
	
	bool changedNofity;
	
	public bool ChangedNotify{
		set{
			changedNofity = value;
			if(changeNotifyAction != null)changeNotifyAction();
		}
	}

	Dictionary<int , Dictionary<int ,ShopItem>> shopInfosDic = new Dictionary<int, Dictionary<int, ShopItem>>();	//key1 : the shop id   ,key2 : the shopItem idx
		
	Dictionary<int ,Shop> shopDic = new Dictionary<int, Shop>();
	
	public void AddShopItem(int shopId , int idx , ShopItem  shopItem){
		if(shopInfosDic[shopId].ContainsKey(idx)){
			shopInfosDic[shopId][idx] = shopItem;
			return;
		}
		shopInfosDic[shopId].Add(idx , shopItem);
	}
	
	public void AddShop(int shopId , Shop shop){
		if(shopDic.ContainsKey(shopId)){
			shopDic[shopId] = shop;
			return;
		}
		shopDic.Add(shopId , shop);
	}
	
	public Shop GetShopById(int shopId){
		return shopDic[shopId];
	}

	public void ClearShopInfo(int shopId){
		if(shopInfosDic.ContainsKey(shopId)){
			shopInfosDic[shopId].Clear();
			return;
		}
		shopInfosDic[shopId] = new Dictionary<int, ShopItem>();
	}
	
	public int GetShopItemsCount(int shopId){
		return shopInfosDic[shopId].Count;
	}
	
	public Dictionary<int ,ShopItem> GetShopItems(int shopId){
		if(!shopInfosDic.ContainsKey(shopId)){
			Debug.LogError("[ShopManager.GetShopItems] : cannot find the shop which id is " + shopId + " , you may be forger to getshopInfos from server!");
			return null;
		}
		return shopInfosDic[shopId];
	}
	
	public ShopItem GetShopItemById(int shopId , int idx){
		return shopInfosDic[shopId][idx];
	}
}