using UnityEngine;
using System;
using System.Collections;
/**
 * SetAction(true)
 * BindingData
 * FreshUI
 */

public class ShopItemScript : MonoBehaviour {
	public UILabel labelName;
		
	public UILabel labelPrice;
	
	public UISprite spriteItemIcon;
	
	public UISprite priceIcon;

	public ShopItem shopItem;
	
	public Transform tSellout;
	
	public void BindingData(ShopItem shopItem){
		if(this.shopItem == null){
			this.shopItem = shopItem;
			RegistAction();
			return;
		}
		UnregistAction();
		this.shopItem = shopItem;
		RegistAction();
	}
	
	public void RegistAction(){
		if(this.shopItem == null)return;
		this.shopItem.changedNotifyAction += FreshUI;
	}
	
	public void UnregistAction(){
		if(this.shopItem == null)return;
		this.shopItem.changedNotifyAction -= FreshUI;
	}
	
	#region regista action
	public void FreshUI(){
		spriteItemIcon.spriteName = shopItem.icon;
		labelName.text = shopItem.name + " x" + shopItem.num;
		labelPrice.text = shopItem.sellprice.ToString(); 
		priceIcon.spriteName = ShopConstants.PriceIcon(shopItem.priceType);
		tSellout.gameObject.SetActive(shopItem.empty);
		
	}
	#endregion
	
	void OnClick(){
		if(shopItem.empty)return;
		AreanUiManager.Instance.ShowBuyDialog(shopItem);
	}
	
	void OnDisable(){
		UnregistAction();
	}
}