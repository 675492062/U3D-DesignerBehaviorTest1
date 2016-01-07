using UnityEngine;
using System.Collections;

public class AreanUiManager : MonoBehaviour {
	private static AreanUiManager _instance;
	
	public static AreanUiManager Instance{
		get{
			return _instance;
		}
	}

	public RuleTip ruleTip;
	
	public BuyRemainTimesTip buyTimesTip;
	
	public AreanRankUI areanRankUI;
	
	public AreanRecordUI areanRecordUI;
	
	public ShopController areanShop;
	
	public BuyDialog buyDialog;
	
	public AreanDetailUI areanDetailUI;
	
	void Awake(){
		_instance = this;
	}
	
	public void ShowRankUI(){
		int lvLimit = StaticGlobal_parameter.Instance().getInt(850048 , "parameter");
		if(lvLimit > MonoInstancePool.getInstance<UserData>().level){
			string errStr ="[the level of openning the arean is ] " + lvLimit ;
			Debug.LogError(errStr);
			ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(error)
			{
				error.showErrorWindow(errStr);
			}
			return;
		}
		areanRankUI.gameObject.SetActive(true);
		areanRankUI.BindingSelfData();
		areanRankUI.FreshUI();
	}
	
	public void ShowRuleTip(){
		ruleTip.gameObject.SetActive(true);
		ruleTip.FreshUI();
	}
	
	public void ShowBuyTimeTip(int price , int pricetype , int haveaffordTime , int allTimes){
		buyTimesTip.gameObject.SetActive(true);
		buyTimesTip.FreshUI(price , pricetype , haveaffordTime , allTimes);	
	}
	
	public void ShowAreanRecord(){
		areanRecordUI.gameObject.SetActive(true);
		areanRecordUI.FreshUI();
	}
	
	public void ShowShop(int shopType){
		areanShop.gameObject.SetActive(true);
		areanShop.BindingData();
		areanShop.FreshUI();
	}
	
	public void ShowAreanShop(){
		ShowShop((int)ItemMessage.ENUM_SHOP_TYPE.ST_ARENA);
	}
	
	public void ShowBuyDialog(ShopItem shopItem){
		buyDialog.gameObject.SetActive(true);
		buyDialog.BindingData(shopItem);
		buyDialog.FreshUI();
	}
	
	public void ShowAreanDetailUI(){
		areanDetailUI.gameObject.SetActive(true);
		areanDetailUI.FreshUI();
	}
	
	void OnEnable(){

	}
	
	void OnDestory(){
		_instance = null;
	}
}