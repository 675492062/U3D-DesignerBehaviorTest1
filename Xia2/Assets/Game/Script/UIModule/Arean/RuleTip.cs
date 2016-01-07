using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleTip : MonoBehaviour {
	public const string userRankIns = "你的武斗榜排名是{0}名，你的巅峰武斗榜排名是{1}名，你的武斗榜排名更高，保持当前的排名（第{2}名至第{3}名），可领奖励为：";

	public UILabel labelSelfRankInfo;
	
	public UIGrid selfRankAwardGrid;
	
	public UILabel labelSelfHigh;
	
	public UILabel labelRuleTxt;
	
	public UILabel labelRuleDailyTxt;
	
	public UIGrid firstRankAwardGrid;
		
	public GameObject bgCollider;
	
	void Awake(){
		UIEventListener.Get(bgCollider).onClick += UIClickCloseBtn;
	}
	
	void UIClickCloseBtn(GameObject sender){
		gameObject.SetActive(false);
	}
	
	public void FreshUI(){
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		
		int selfAwardId = AreanRankAward.GetAwardId(areanMng.GetSelfRankData().index);
		var awards = AreanRankAward.GetAwardListById(selfAwardId);
		FreshGrid(selfRankAwardGrid , awards);
		
		int firstAwardId = AreanRankAward.GetAwardId(1);
		var firstAwards = AreanRankAward.GetAwardListById(firstAwardId);
		FreshGrid(firstRankAwardGrid , firstAwards);
		
		int min = StaticCompetition_settlement.Instance().getInt(selfAwardId , "rank_min");
		int max = StaticCompetition_settlement.Instance().getInt(selfAwardId , "rank_max");
		labelSelfRankInfo.text = string.Format(userRankIns , areanMng.GetSelfRankData().index.ToString() , areanMng.GetSelfRankData().hIndex.ToString(), 
		min.ToString() , max.ToString());
		labelSelfHigh.text = areanMng.GetSelfRankData().hIndex.ToString();
	}
	
	void FreshGrid(UIGrid grid , List<AreanRankAward.Award> awards){
		for(int i = 0 ; i < grid.transform.childCount ; i ++){
			var child = grid.transform.GetChild(i);
			if(i >= awards.Count){
				child.gameObject.SetActive(false);
				continue;
			}
			child.gameObject.SetActive(true);
			var sprite = (UISprite)child.FindChild("Sprite").GetComponent(typeof(UISprite));
			var label = (UILabel)child.FindChild("Label").GetComponent(typeof(UILabel));
			
			sprite.spriteName = awards[i].icon;
			label.text = awards[i].num.ToString();
		}
	}
}