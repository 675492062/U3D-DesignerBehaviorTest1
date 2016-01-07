using UnityEngine;
using System.Collections;

public class UIChapterDgnManager : MonoBehaviour {
	
	public UIChapterPanel chapterPanel;
	
	public UIDungeonTipController dungeonTipController;
	
	public UIRankController rankController;
	
	public UIBaseController baseController;
	
	public UIRewardController rewardController;
		
	private static UIChapterDgnManager _instance;
	
	public static UIChapterDgnManager instance
	{
		get{
			return _instance;
		}
	}

	public bool isAct{
		get{
			return this.gameObject.activeSelf;
		}
	}
	
	void Awake(){
		_instance = this;
	}
	
	void RegistAction(){
		MonoInstancePool.getInstance<ChapterManager>().chapterChangeAction += ChangeCurrentChapter;
	}
	
	void UnRegistAction(){
		MonoInstancePool.getInstance<ChapterManager>().chapterChangeAction -= ChangeCurrentChapter;
	}
	
	void ChangeCurrentChapter(){
		baseController.FreshUI();
		StartCoroutine(chapterPanel.InitChapterMap());
	}
	
	public void OpenOChapterMapUI()
	{	
		RegistAction();
		ShowBaseUI();
		OpenOneChapterMapUI();
	}
	
	void OpenOneChapterMapUI(){
		chapterPanel.gameObject.SetActive(true);
		StartCoroutine(chapterPanel.InitChapterMap());
	}
	
	public void OpenDungeonTipUI(DungeonStruct data)
	{
		dungeonTipController.ShowWithData(data);
	}
	
	public void ShowBaseUI(){
		baseController.gameObject.SetActive(true);
	}
	
	public void ShowRankList(){
		rankController.gameObject.SetActive(true);
		rankController.FreshUI();
	}
	
	public void ShowRewardTip(){
		rewardController.gameObject.SetActive(true);
		rewardController.BindingData(MonoInstancePool.getInstance<ChapterManager>().currentChapter);
		rewardController.FreshUI();
	}

	void OnDisable(){
		UnRegistAction();
	}
	
	void OnDestory(){
		_instance = null;
	}
}