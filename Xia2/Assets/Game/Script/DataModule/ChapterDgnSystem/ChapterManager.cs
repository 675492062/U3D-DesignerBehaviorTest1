using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ChapterManager : MonoBehaviour {

	public enum ChapterLevel{
		Normal  = 1,												//普通章节
		NightMare = 2												//噩梦章节
	}
	
	ChapterStruct displayedChapter;
	
	public Action chapterChangeAction;
	
	public ChapterStruct currentChapter{
		set{
			displayedChapter = value;
			if(chapterChangeAction != null){
				chapterChangeAction();
			}
		}
		get{
			return displayedChapter;
		}
	}
	
	public DungeonStruct currentDungeon{set;get;}
			
	Dictionary<int , ChapterStruct> chapterDic = new Dictionary<int, ChapterStruct>();
		
	public const int FIRST_CHAPTER_ID = 350001;

	ChapterStruct LoadChapter(int chapterId){
		ChapterStruct chapterStruct = new ChapterStruct(chapterId);
		chapterDic.Add(chapterId , chapterStruct);
		return chapterStruct;
	}
	
	public ChapterStruct GetChapterById(int chapterid){
		if(!chapterDic.ContainsKey(chapterid)){
			return LoadChapter(chapterid);
		}
		return chapterDic[chapterid];
	}
	
	public void LoadAllChapters(){
		int lastChapterId = 0;
		int chapterid = FIRST_CHAPTER_ID;
		do{
			var chapter = LoadChapter(chapterid);
			chapter.lastId = lastChapterId;
			lastChapterId = chapterid;
			chapterid = chapter.baseData.nextId;
		}while(chapterid != 0);
	}
	
	//更新所有章节信息
	public void UpdateUnLockInfo(){
		foreach(KeyValuePair<int ,ChapterStruct> keyValue in chapterDic){
			var chapter = keyValue.Value;
			chapter.UpdateUnLockedDungeonInfo();
		}
	}
	
	//确定将要显示的章节
	public void InitCurrentChapter(){
		var chapter = chapterDic[FIRST_CHAPTER_ID];
		
		do{
			if(chapter.baseData.nextId == 0){
				break;
			}
			var nextChapter = chapterDic[chapter.baseData.nextId];
			if(!nextChapter.UnLocked((int)ChapterLevel.Normal)){
				break;
			}
			chapter = nextChapter;
			
		}while(true);
		currentChapter = chapter;
	}
}