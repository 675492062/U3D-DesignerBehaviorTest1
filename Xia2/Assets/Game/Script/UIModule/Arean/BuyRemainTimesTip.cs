using UnityEngine;
using System.Collections;

public class BuyRemainTimesTip : MonoBehaviour {
	const string txt = "今天已购买{0}/{1}次";

	public UILabel labelPrice;
	
	public UISprite spritePriceIcon;
	
	public UILabel labelHaveBought;
	
	public GameObject btnCancel;
	
	public GameObject btnOk;
	
	public GameObject btnBgCollider;
	
	void Awake(){
		UIEventListener.Get(btnCancel).onClick += UIClickCancelBtn;
		UIEventListener.Get(btnOk).onClick += UIClickOkBtn;
		UIEventListener.Get(btnBgCollider).onClick += UIClickCancelBtn;
	}
	
	public void FreshUI(int price , int pricetype , int haveaffordTime , int allTimes){
		labelPrice.text = price.ToString();
		labelHaveBought.text = string.Format(txt , haveaffordTime , allTimes);
	}
	
	void UIClickCancelBtn(GameObject sender){
		Close(sender);
	}
	
	void UIClickOkBtn(GameObject sender){
		MonoInstancePool.getInstance<SendAreanHandler>().SendAreanBuyCountReq();
	}
	
	void Close(GameObject sender){
		this.gameObject.SetActive(false);
	}
}
