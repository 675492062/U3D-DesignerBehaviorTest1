using UnityEngine;
using System.Collections;

//竞技场排行榜每个item
public class AreanRankItem : MonoBehaviour {

	public Transform tBtnGreySprite;
	
	public GameObject btnDetail;
	
	public GameObject btnDekaron;
			
	public UILabel labelFightStrength;
	
	public UISprite spriteRankIndex;
	
	public UILabel labelRankIndex;
	
	public UILabel labelPlayerName;
	
	public GameObject[] heroItems;
	
	AreanRankData rankData;
	
	void Awake(){
		UIEventListener.Get(btnDekaron).onClick += UIClickDekaronBtn;
		UIEventListener.Get(btnDetail).onClick += UIClickDetailBtn;
	}
	
	public void BindingData(AreanRankData data){
		this.rankData = data;
	}
	
	public void FreshUI(){
		if(this.rankData == null){
			Debug.LogError("[AreanRankItem] is null !");
			return;
		}
		labelFightStrength.text = rankData.fightStrength.ToString();
		labelPlayerName.text = rankData.name;
		FreshRankIndex();
		FreshHeroUI();
		FreshFightBtn();
	}
	
	public void FreshFightBtn(){
		tBtnGreySprite.gameObject.SetActive(IsNotAbleFight);
	}
	
	//不能挑战的条件
	bool IsNotAbleFight{
		get{
			var areanMng = MonoInstancePool.getInstance<AreanManager>();
			var selfData = areanMng.GetSelfRankData();
			bool speicalFight = selfData.index > 20 && this.rankData.rankIndex <= 5;						//20名之后，前5名是不能挑战的
			return selfData.countCdTime > 0 || selfData.fightCount <= 0 || selfData.index < this.rankData.rankIndex || speicalFight;
		}
	}
	
	void FreshRankIndex(){
		spriteRankIndex.transform.parent.gameObject.SetActive(this.rankData.rankIndex <= 3);
		if(this.rankData.rankIndex <= 3){
			labelRankIndex.gameObject.SetActive(false);
			spriteRankIndex.spriteName = GetRankIndexSpriteName();
			return;
		}
		labelRankIndex.gameObject.SetActive(true);
		labelRankIndex.text = this.rankData.rankIndex.ToString();
	}
	
	void FreshHeroUI(){
		for(int i = 0 ; i < heroItems.Length ; i++){
			AreanHeroData data = rankData.heroDatas[i];
			if(data != null){
				AreanHeroItem itemsc = (AreanHeroItem)heroItems[i].GetComponent(typeof(AreanHeroItem));
				itemsc.FreshUI(data);
			}
		}
	}
	//start arean fight
	void UIClickDekaronBtn(GameObject sender){
		if(this.rankData == null){
			Debug.LogError("AreanRankItem : the rankData is null !");
			return;
		}
		
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		if(IsNotAbleFight){
			return;
		}
		MonoInstancePool.getInstance<SendFightMsgHander>().SendAreanFightStartReq(this.rankData.uid , this.rankData.rankIndex);
	}
	
	void UIClickDetailBtn(GameObject sender){
		if(this.rankData == null){
			Debug.LogError("AreanRankItem : the rankData is null !");
			return;
		}
		MonoInstancePool.getInstance<AreanManager>().detailInfo.notifyAction = delegate() {
				//open the arean detail info ui
				AreanUiManager.Instance.ShowAreanDetailUI();
		};
		MonoInstancePool.getInstance<SendAreanHandler>().SendAreanOtherUserInfoReq(this.rankData.uid);	
	}

	string GetRankIndexSpriteName(){
		if(rankData.rankIndex == 1){
			return SpriteName_Rank_1;
		}else if(rankData.rankIndex == 2){
			return SpriteName_Rank_2;
		}else if(rankData.rankIndex == 3){
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