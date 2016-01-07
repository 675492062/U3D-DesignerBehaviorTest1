using UnityEngine;
using System.Collections;

//竞技场排行榜最底下的 当前用户自己的信息item
public class AreanSelfItem : MonoBehaviour {
		
	public GameObject btnShowRecord;
	
	public UILabel labelFightStrength;
	
	public UISprite spriteRankIndex;
	
	public UILabel labelRankIndex;
		
	public GameObject[] heroItems;
	
	AreanUserInfo rankData;
	
	void Awake(){
		UIEventListener.Get(btnShowRecord).onClick += UIClickRecordBtn;
	}
	
	public void BindingData(AreanUserInfo data){
		this.rankData = data;
	}
	
	public void FreshUI(){
		if(this.rankData == null){
			Debug.LogError("[AreanRankItem] is null !");
			return;
		}
		labelFightStrength.text = rankData.fightCount.ToString();
		FreshRankIndex();
		FreshHeroUI();
	}
	
	void FreshRankIndex(){
		spriteRankIndex.transform.parent.gameObject.SetActive(this.rankData.index <= 3);
		if(this.rankData.index <= 3){
			labelRankIndex.gameObject.SetActive(false);
			spriteRankIndex.spriteName = GetRankIndexSpriteName();
			return;
		}
		labelRankIndex.gameObject.SetActive(true);
		labelRankIndex.text = this.rankData.index.ToString();
	}
	
	void FreshHeroUI(){
		for(int i = 0 ; i < heroItems.Length ; i++){
			var heroMng = MonoInstancePool.getInstance<HeroManager>();
			
			HeroData heroData = heroMng.getFightHeroByIdx(i);
			if(heroData != null){
				AreanHeroData data = new AreanHeroData();
				data.lv = heroData.level;
				data.id = heroData.templateID;
//				data.realm =
				data.starLv = heroData.starLevel;
				AreanHeroItem itemsc = (AreanHeroItem)heroItems[i].GetComponent(typeof(AreanHeroItem));
				itemsc.FreshUI(data);
			}
		}
	}
	
	void UIClickRecordBtn(GameObject sender){
		if(MonoInstancePool.getInstance<AreanManager>().GetAreanRecordList().Count == 0){
			Debug.LogWarning("[AreanSelfItem.UIClickRecordBtn] : the user doesnot have any fight record!");
			return;
		}
		AreanUiManager.Instance.ShowAreanRecord();
	}
	
	string GetRankIndexSpriteName(){
		if(rankData.index == 1){
			return SpriteName_Rank_1;
		}else if(rankData.index == 2){
			return SpriteName_Rank_2;
		}else if(rankData.index == 3){
			return SpriteName_Rank_3;
		}
		return null;
	}
	
	void OnDestory(){
		this.rankData = null;
	}
	
	public const string SpriteName_Rank_1 = "warfar_01";
	
	public const string SpriteName_Rank_2 = "warfar_02";
	
	public const string SpriteName_Rank_3 = "warfar_03";
}
