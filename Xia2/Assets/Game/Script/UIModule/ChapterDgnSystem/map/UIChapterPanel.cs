using UnityEngine;
using System.Collections;

public class UIChapterPanel : MonoBehaviour {

	public UIScrollView scrollView;
	
	public UIGrid grid;
	
	public GameUICenterOnChild centerOnChild;
	
	GameObject displayedChapter;
	
	void Awake(){
		centerOnChild.onFinished += InitShowedChapater;
	}
	
	public IEnumerator InitChapterMap(){
		int chapterId = ChapterManager.FIRST_CHAPTER_ID;
		do{
			var chapterSturct = MonoInstancePool.getInstance<ChapterManager>().GetChapterById(chapterId);
			if(!IsChapterExist(chapterId)){
				GameObject prefab = Resources.Load("Prefab/ChapterDgnSystem/chapter/" + chapterId) as GameObject;
				var chapter = NGUITools.AddChild(grid.gameObject , prefab);
				chapter.name = chapterId.ToString();
				
				var chapterController = (UIChapterController)chapter.GetComponent(typeof(UIChapterController));
				chapterController.BindingData(chapterSturct);
				chapterController.FreshUI();
			}
			chapterId = chapterSturct.passedDic[(int)ChapterLevel.Normal] ? chapterSturct.baseData.nextId : 0;
			yield return new WaitForEndOfFrame();
		}while(chapterId != 0);
		grid.Reposition();

		var currentChapter = MonoInstancePool.getInstance<ChapterManager>().currentChapter;
		if(currentChapter == null){
			Debug.LogError("StaticChapter.json in server or client is error!");
		}else 
			ShowChapterImmediate(currentChapter.id);
	}
	
	bool IsChapterExist(int chapterId){
		foreach(Transform child in grid.transform){
			if(child.name == chapterId.ToString()){
				return true;
			}
		}
		return false;
	}
	
	void ShowChapter(int chapterId){
		Transform chapter = grid.transform.Find(chapterId.ToString());
		ShowChapter(chapter);
	}
	
	void ShowChapterImmediate(int chapterId){
		Transform chapter = grid.transform.Find(chapterId.ToString());
		ShowChapterImmediate(chapter);
	}
	
	void ShowChapter(Transform chapter){
		centerOnChild.CenterOn(chapter);
	}
	
	void ShowChapterImmediate(Transform chapter){
		centerOnChild.CenterOnImmediate(chapter);
	}
	
	void InitShowedChapater(){
		if(displayedChapter == null || (displayedChapter.name != centerOnChild.centeredObject.name)){
			displayedChapter = centerOnChild.centeredObject;
			var chapterController = (UIChapterController)displayedChapter.GetComponent(typeof(UIChapterController));
			MonoInstancePool.getInstance<ChapterManager>().currentChapter = chapterController.chapterData;
		}
	}
	
	public void ToLast(){
		ShowChapter(MonoInstancePool.getInstance<ChapterManager>().currentChapter.lastId);
	}
	
	public void ToNext(){
		ShowChapter(MonoInstancePool.getInstance<ChapterManager>().currentChapter.baseData.nextId);
	}
}