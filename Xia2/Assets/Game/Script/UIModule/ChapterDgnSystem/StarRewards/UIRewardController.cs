using UnityEngine;
using System.Collections;

public class UIRewardController : MonoBehaviour {

	public struct BoxData{
		public int index;
		public int awardId;
		public BoxState state;
		public int starNum;
	}
	
	public enum BoxState{
		closed,
		hasKey,
		open,
	}

	public GameObject btnClose;
	
	public GameObject btnGetGift;
	
	public UILabel labelStarPercentage;
	
	public UILabel labelTitle;
	
	public Transform[] boxes;
	
	public UIProgressBar progressBar;
	
	public Transform giftLocked;
	
	public UITable tableAward;
	
//	public ChapterStruct.Award award{private set; get;}
	ChapterStruct chapter;
	
	BoxData currentBox;
	
	[HideInInspector]
	BoxData[] boxDates;
	
	void Awake(){
		UIEventListener.Get(btnClose).onClick += UIClickCloseBtn;
		UIEventListener.Get(btnGetGift).onClick += UIClickGetGiftBtn;
		boxDates = new BoxData[MAX_BOX_NUM];
	}
	
	#region bindingData

	void RegistAction(){
		if(this.chapter == null)return;
		this.chapter.award.awardAction += AwardAction;
	}
	
	void UnRegistAction(){
		if(this.chapter == null)return;
		this.chapter.award.awardAction -= AwardAction;
	}
	
	#endregion 
	
	void AwardAction(){
		ResetData();
		FreshUI();
	}
	
	public void BindingData(ChapterStruct chapter){
		if(this.chapter == null){
			this.chapter = chapter;
			ResetData();
			RegistAction();
			return;
		}
		UnRegistAction();
		this.chapter = chapter;
		ResetData();
		RegistAction();
	}
	
	public const int MAX_BOX_NUM = 4;
	
	void ResetData(){
		ChapterStruct.Award award = chapter.award;
		int perStar = award.totalChapterStars/MAX_BOX_NUM;
		
		for(int i = 0 ; i < MAX_BOX_NUM ; i ++){
			//			boxDates[i] = new BoxData();
			boxDates[i].index = i + 1;
			boxDates[i].starNum = perStar * (i + 1);
			if(i == 3)boxDates[i].starNum = award.totalChapterStars;
			
			boxDates[i].state = award.totalCurrentStars >= boxDates[i].starNum ? BoxState.hasKey : BoxState.closed;
			if(i == 0 && award.Box1){
				boxDates[i].state = BoxState.open;
			}else if(i == 1 && award.Box2){
				boxDates[i].state = BoxState.open;
			}else if(i == 2 && award.Box3){
				boxDates[i].state = BoxState.open;
			}else if(i == 3 && award.Box4){
				boxDates[i].state = BoxState.open;
			}
		}
		boxDates[0].awardId = this.chapter.baseData.box1Id;
		boxDates[1].awardId = this.chapter.baseData.box2Id;
		boxDates[2].awardId = this.chapter.baseData.box3Id;
		boxDates[3].awardId = this.chapter.baseData.box4Id;
	}
	
	void UIClickCloseBtn(GameObject gameobject){
		this.gameObject.SetActive(false);
	}
	
	void UIClickGetGiftBtn(GameObject gameobject){
		MonoInstancePool.getInstance<SendChapterDgnHandler>().SendChapterBoxReq(chapter.id , currentBox.index);
	}
	
	public void FreshUI(){
		if(chapter == null){
			Debug.LogError("[UIRewardController] the data is null");
			return;
		}
		ChapterStruct.Award award = chapter.award;
		labelStarPercentage.text = award.totalCurrentStars + "/" + award.totalChapterStars;
		progressBar.value = (float)award.totalCurrentStars/(float)award.totalChapterStars;
		
		int perStar = award.totalChapterStars/4;
		
		for(int i = 0 ; i < 4 ; i ++){
			var boxScript = (UIAwardBox)boxes[i].GetComponent(typeof(UIAwardBox));
			boxScript.FreshUI(boxDates[i]);
		}
		if(!award.Box1){
			currentBox = boxDates[0];
		}else if(award.Box1 && !award.Box2){
			currentBox = boxDates[1];
		}else if(award.Box2 && !award.Box3){
			currentBox = boxDates[2];
		}else if(award.Box3 && !award.Box4){
			currentBox = boxDates[3];
		}else
			currentBox = boxDates[3];
		FreshAwardPanel();
	}
	
	void FreshAwardPanel(){
		DestoryTable();
		switch(currentBox.state){
			case BoxState.closed:
				labelTitle.text = "即将获得奖励";
				giftLocked.gameObject.SetActive(true);
				break;
			case BoxState.hasKey:
				labelTitle.text = "获得奖励";
				giftLocked.gameObject.SetActive(false);
				break;
			case BoxState.open:
				labelTitle.text = "已获得奖励";
				giftLocked.gameObject.SetActive(true);
				break;
		}
		
		ChapterAwardItem item = MonoInstancePool.getInstance<ChapterAwardManager>().GetAwardItem(currentBox.awardId);
		for(int i = 0 ; i < item.items.Count ; i++){
			var award = item.items[i];
			
			int id = award.id;
			
			GameObject prefab = Resources.Load("Prefab/ChapterDgnSystem/starbox/" + id) as GameObject;
			Transform parent = tableAward.transform.GetChild(0);
			NGUITools.AddChild(parent.gameObject , prefab);
		}
	}
	
	void OnDisable(){
		UnRegistAction();
		DestoryTable();
	}
	
	void DestoryTable(){
		foreach(Transform child in tableAward.transform){
			if(child.childCount > 0)NGUITools.Destroy(child.GetChild(0).gameObject);
		}
	}
}