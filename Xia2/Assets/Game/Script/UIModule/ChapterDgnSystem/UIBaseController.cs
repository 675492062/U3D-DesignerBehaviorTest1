using UnityEngine;
using System.Collections;

public class UIBaseController : MonoBehaviour {

	public GameObject btnNext;
	
	public GameObject btnLast;
	
	public GameObject btnBack;
	
	public GameObject btnRankList;									//打开章节排行榜列表
	
	public GameObject btnTreasure;									//打开星数宝箱界面
	
	public GameObject btnNormal;									//章节难度切换为简单
	
	public GameObject btnNightMare;									//章节难度切换为噩梦
		
	void Awake(){
		UIEventListener.Get(btnBack).onClick += UIClickBackBtn;
		UIEventListener.Get(btnRankList).onClick += UIClickRankList;
		UIEventListener.Get(btnTreasure).onClick += UIClickTreasure;
		UIEventListener.Get(btnNormal).onClick += UIClickNormalBtn;
		UIEventListener.Get(btnNightMare).onClick += UIClickMareBtn;
		UIEventListener.Get(btnLast).onClick += UIClickLastBtn;
		UIEventListener.Get(btnNext).onClick += UIClickNextBtn;
	}
	
	public void FreshUI(){
		var chapterData = MonoInstancePool.getInstance<ChapterManager>().currentChapter;
		FreshLevelBtn(chapterData);
		btnLast.SetActive(chapterData.lastId != 0);
		if(chapterData.baseData.nextId == 0){
			btnNext.SetActive(false);
			return;
		}
		var chapterNext = MonoInstancePool.getInstance<ChapterManager>().GetChapterById(chapterData.baseData.nextId);
		btnNext.SetActive(chapterNext.UnLocked((int)ChapterLevel.Normal));
	}
	
	void FreshLevelBtn(ChapterStruct chapterData){
		//may change to array
		var normalSetting = (ChatperLevelBtnScript)btnNormal.GetComponent(typeof(ChatperLevelBtnScript));
		normalSetting.FreshUI(chapterData);
		
		var mareSetting = (ChatperLevelBtnScript)btnNightMare.GetComponent(typeof(ChatperLevelBtnScript));
		mareSetting.FreshUI(chapterData);
	}

	#region uievent
	void UIClickBackBtn(GameObject gameobject){
		UIChapterDgnManager.instance.gameObject.SetActive(false);
	}
	
	void UIClickRankList(GameObject gameObject){
		UIChapterDgnManager.instance.ShowRankList();
	}
	
	void UIClickTreasure(GameObject gameObject){
		UIChapterDgnManager.instance.ShowRewardTip();
	}
	
	void UIClickNormalBtn(GameObject gameobject){
		ChapterManager chapterMgr = MonoInstancePool.getInstance<ChapterManager>();
		var currentChapter = chapterMgr.currentChapter;
		if(currentChapter.Level == ChapterLevel.Normal)return;
		currentChapter.Level = ChapterLevel.Normal;
		FreshLevelBtn(currentChapter);
	}
	
	void UIClickMareBtn(GameObject gameobject){
		ChapterManager chapterMgr = MonoInstancePool.getInstance<ChapterManager>();
		var currentChapter = chapterMgr.currentChapter;
		if(currentChapter.Level == ChapterLevel.NightMare)return;
		if(!currentChapter.passedDic[(int)ChapterLevel.Normal])return;
		currentChapter.Level = ChapterLevel.NightMare;
		FreshLevelBtn(currentChapter);
	}
	
	void UIClickLastBtn(GameObject gameobject){
		UIChapterDgnManager.instance.chapterPanel.ToLast();
	}
	
	void UIClickNextBtn(GameObject gameobject){
		UIChapterDgnManager.instance.chapterPanel.ToNext();
	}
	
	#endregion
	
	void OnEnable()
	{
		UIPanel panel = NGUITools.FindInParents<UIPanel> (gameObject);
		UICurrencyManager.Show (transform,panel.depth);
	}
}