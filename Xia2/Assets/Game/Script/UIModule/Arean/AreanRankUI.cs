using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//竞技场每个排行榜
public class AreanRankUI : MonoBehaviour {

	public GameObject btnRule;
	
	public GameObject btnExchange;
	
	public GameObject btnBuyChallengeTimes;
	
	public UILabel labelCheckOutTime;
	
	public UILabel labelRemainTimes;
	
	public UILabel labelNextFightTime;
	
	public GameObject bgCollider;
	
	public UILabel labelPrice;
	
	public UIGrid uiGrid;
	
	public AreanSelfItem selfRankInfo;
	
	void Awake(){
		UIEventListener.Get(btnRule).onClick += UIClickRuleBtn;
		UIEventListener.Get(btnExchange).onClick += UIClickExchangeBtn;
		UIEventListener.Get(btnBuyChallengeTimes).onClick += UIClickBuyChTimes;
		UIEventListener.Get(bgCollider).onClick += Close;
	}
	
	void Update(){
		labelNextFightTime.text = "下次挑战: " + UITools.ColorTxt(ParseTimeFormat(MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().countCdTime) , 109 , 253 , 49 , 255);
	}
	
	public void BindingSelfData(){
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		var selfRankData = areanMng.GetSelfRankData();
		
		areanMng.rankModifyAction = delegate() {
			StartCoroutine(FreshGird());
		};
		selfRankInfo.BindingData(selfRankData);
		selfRankData.modifyAction = FreshReferenceCount;
	}
	
	public void FreshReferenceCount(){
		foreach(Transform child in uiGrid.transform){
			var rankItemSc = (AreanRankItem)child.GetComponent(typeof(AreanRankItem));
			rankItemSc.FreshFightBtn();
		}
		FreshBaseUI();
	}

	public void FreshUI(){
		StartCoroutine(FreshGird());
		selfRankInfo.FreshUI();
		FreshBaseUI();
	}
	
	void FreshBaseUI(){
		AreanManager areanMng = MonoInstancePool.getInstance<AreanManager>();
		
		labelNextFightTime.text = "下次挑战: " + UITools.ColorTxt(ParseTimeFormat(areanMng.GetSelfRankData().countCdTime) , 109 , 253 , 49 , 255);
		labelCheckOutTime.text = "每天22点结算";
		labelRemainTimes.text = "剩余挑战次数: " + UITools.ColorTxt(areanMng.GetSelfRankData().fightCount.ToString() , 109 , 253 , 49 , 255);
		labelPrice.text = areanMng.GetSelfRankData().coin.ToString();
	}
	
	string ParseTimeFormat(float second){
		int formatSecond = (int)second % 60;
		int formatMin = (int)second / 60;
		return string.Format("{0:D2}",formatMin) + ":" + string.Format("{0:D2}",formatSecond);
	}
	
	IEnumerator FreshGird(){
		foreach(Transform child in uiGrid.transform){
			Destroy(child.gameObject);
		}
		yield return new WaitForEndOfFrame();
		
		AreanManager areanManager = MonoInstancePool.getInstance<AreanManager>();
		
		List<AreanRankData> list = areanManager.GetAreanRankList();
		
		for(int i = 0 ; i < list.Count ; i++){
			GameObject prefab = Resources.Load("Prefab/Arean/areanrankitem") as GameObject;
			
			GameObject rankItem = NGUITools.AddChild(uiGrid.gameObject , prefab);
			var rankItemSc = (AreanRankItem)rankItem.GetComponent(typeof(AreanRankItem));
			rankItem.gameObject.SetActive(true);
			rankItemSc.BindingData(list[i]);
			rankItemSc.FreshUI();
			uiGrid.Reposition();
//			Debug.LogError("rankindex is " + list[i].rankIndex);
			yield return new WaitForEndOfFrame();
		}
	}
	
	void Close(GameObject sender){
		this.gameObject.SetActive(false);
	}
	
	void UIClickRuleBtn(GameObject sender){
		AreanUiManager.Instance.ShowRuleTip();
	}
	
	void UIClickExchangeBtn(GameObject sender){
		AreanUiManager.Instance.ShowAreanShop();
	}
	
	//购买竞技挑战次数
	void UIClickBuyChTimes(GameObject sender){
		int price = StaticTime_price.Instance().getInt(MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().buyCount , "competition");
		int maxCount = StaticVip.Instance().getInt(MonoInstancePool.getInstance<UserData>().vipLevel , "buy_competition_num");
		if(maxCount == 0 || MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().buyCount >= maxCount){
			Debug.LogError("[Only vip can bought or the count has been max]");
			return;
		}
		AreanUiManager.Instance.ShowBuyTimeTip(price , (int)PriceType.Jewel , MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().buyCount , maxCount);
	}
	
	void OnDisable(){
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		areanMng.rankModifyAction = null;
		var selfRankData = areanMng.GetSelfRankData();
		selfRankData.modifyAction = null;
	}
}