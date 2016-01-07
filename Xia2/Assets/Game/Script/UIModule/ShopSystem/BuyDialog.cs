using UnityEngine;
using System.Collections;

public class BuyDialog : MonoBehaviour {
	public UILabel labelItemName;
	
	public UILabel labelOwnNum;
	
	public UILabel labelItemNum;
	
	public UILabel labelPrice;
	
	public UILabel labelDescription;
	
	public GameObject btnConfirm;
	
	public GameObject fullbgCollider;
	
	public UISprite spritePriceIcon;
	
	public UISprite spriteItemIcon;

	ShopItem shopItem;
	
	void Awake(){
		UIEventListener.Get(btnConfirm).onClick += UIClickBuyBtn;
		UIEventListener.Get(fullbgCollider).onClick += UIClickClose;
	}
	
	public void BindingData(ShopItem data){
		if(data == null){
			this.shopItem = data;
			RegistAction();
			return;
		}
		UnregistAction();
		this.shopItem = data;
		RegistAction();
	}
	public void RegistAction(){
		if(this.shopItem == null)return;
		this.shopItem.changedNotifyAction += EmptyAction;
	}
	
	public void UnregistAction(){
		if(this.shopItem == null)return;
		this.shopItem.changedNotifyAction -= EmptyAction;
	}
	
	void UIClickBuyBtn(GameObject gameobject){
		MonoInstancePool.getInstance<SendShopMsgHandler>().sendBuyItemReq(shopItem.shopId , shopItem.idx);
	}
	
	void EmptyAction(){
		if(shopItem.empty){
			gameObject.SetActive(false);
		}
	}
	
	void UIClickClose(GameObject sender){
		gameObject.SetActive(false);
	}
	
	public void FreshUI(){
//		Debug.LogError("shopItem.info : " + shopItem.name + " , " + shopItem.num + " , " + shopItem.sellprice1 + " , " + shopItem.description);
		labelItemName.text =  shopItem.name;
		labelOwnNum.text = "拥有 " + UITools.ColorTxt(10 + "" , 205 , 251 , 53 , 255);
		labelItemNum.text = "购买 " + UITools.ColorTxt(shopItem.num + "" , 205 , 251 , 53 , 255);
		labelPrice.text = shopItem.sellprice.ToString();
		labelDescription.text = shopItem.description;
		spritePriceIcon.spriteName = ShopConstants.PriceIcon(shopItem.priceType);
		spriteItemIcon.spriteName = shopItem.icon;
	}
	
	void OnDisable(){
		UnregistAction();
	}
	
	void OnDestory(){
	}
}