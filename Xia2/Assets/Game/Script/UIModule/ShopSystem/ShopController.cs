using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopController : MonoBehaviour {
//	public ItemMessage.shop type;
	public ItemMessage.ENUM_SHOP_TYPE type;
	
	public GameObject btnFresh;
	
	public UISprite sFreshPriceIcon;
	
	public UILabel labelFreshPrice;
	
	public UILabel labelFreshIns;
	
	public UISprite spriteOwnPriceIcon;
	
	public UILabel labelOwnPrice;		
	
	public UIGrid uiGrid;
	
	public GameObject bgCollider;
	
	void Awake(){
		UIEventListener.Get(btnFresh).onClick += FreshShopList;
		UIEventListener.Get(bgCollider).onClick += Close;
	}
	
	public void BindingData(){
		RegistAction();
	}
	
	void RegistAction(){
		ShopManager shopManager = MonoInstancePool.getInstance<ShopManager>();
		shopManager.changeNotifyAction = FreshUI;
	}
	
	void UnRegistAction(){
		ShopManager shopManager = MonoInstancePool.getInstance<ShopManager>();
		shopManager.changeNotifyAction = null;
	}
	
	public void FreshUI(){
		StartCoroutine(FreshGrid());
		FreshBaseUI();
	}
	
	void FreshBaseUI(){
		Shop shop = MonoInstancePool.getInstance<ShopManager>().GetShopById((int)type);
		sFreshPriceIcon.spriteName = ShopConstants.PriceIcon((int)shop.priceType);
		labelFreshPrice.text = shop.freshPrice.ToString();
		
		spriteOwnPriceIcon.spriteName = ShopConstants.PriceIcon((int)shop.priceType);
		labelOwnPrice.text = MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().coin.ToString();
	}
	
	IEnumerator FreshGrid(){
		foreach(Transform child in uiGrid.transform){
			Destroy(child.gameObject);
		}
		yield return 0;
		ShopManager shopManager = MonoInstancePool.getInstance<ShopManager>();
		
		Dictionary<int ,ShopItem> shopDic = shopManager.GetShopItems((int)type);
		if(shopDic != null){
			List<int> idxList = new List<int>();
			foreach(int idx in shopDic.Keys){
				idxList.Add(idx);
			}
//			Debug.LogError("shopDic.count : " + shopDic.Count + " , idxList.length : " + idxList.Count);
			idxList.Sort(delegate(int x, int y) {
				return x > y ? 1 : -1;
			});
			foreach(int index in idxList){
//				Debug.LogError("shopItem.idx is " + index);
				ShopItem shopItem = shopDic[index];
				GameObject prefab = GetShopItemPrefab();
				GameObject item = NGUITools.AddChild(uiGrid.gameObject , prefab);
				item.SetActive(true);
				var shopItemSc = (ShopItemScript)item.GetComponent(typeof(ShopItemScript));
				shopItemSc.BindingData(shopItem);
				shopItemSc.FreshUI();
			}
		}
		uiGrid.Reposition();
	}
	
	GameObject GetShopItemPrefab(){
		//type
		return Resources.Load("Prefab/ShopSystem/towershopitem") as GameObject;
	}
	
	#region ui event
	void FreshShopList(GameObject gameObject){
		Shop shop = MonoInstancePool.getInstance<ShopManager>().GetShopById((int)type);
		if(MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().coin < shop.freshPrice){
			Debug.LogError("[the price is not enough]");
			return;
		}
		MonoInstancePool.getInstance<SendShopMsgHandler>().sendRefreshShopListReq((int)ItemMessage.ENUM_TYPE.ENUM_TYPE_MANUAL , (int)type);
	}
	
	void Close(GameObject sender){
		gameObject.SetActive(false);
	}
	#endregion
	
	void OnDisable(){
		foreach(Transform child in uiGrid.transform){
			Destroy(child.gameObject);
		}
		UnRegistAction();
	}
}
