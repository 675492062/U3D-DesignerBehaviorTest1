using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class ChapterDungeonMsg : MonoBehaviour {
	
	public int parse(SocketModel module)
	{
		switch (module.messageID) {
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_LIST:
				OnChapteredList(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_INFO:
				UpdateChapterInfo(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_BOX:
				OnChapterBoxInfo(module);
				break;
			default:
				return -1;
		}
		return 0;
	}
	
	#region get chapter list from server
	
	public void OnChapteredList(SocketModel module){
		var msg = MsgSerializer.Deserialize<MsgChapteredListRep>(module);
		List<Chaptered> normalChapters = msg.normal;
		List<Chaptered> nightmareChpataers = msg.nightmare;
		List<ChapteredAward>  awards = msg.award;
		
		// 章节列表...
		UpdateChapterDungeonsInfo(normalChapters , ChapterLevel.Normal);
		UpdateChapterDungeonsInfo(nightmareChpataers , ChapterLevel.NightMare);
		UpdateChapterAwardsInfo(awards);
		MonoInstancePool.getInstance<ChapterManager>().UpdateUnLockInfo();
		MonoInstancePool.getInstance<ChapterManager>().InitCurrentChapter();
	}
	
	void UpdateChapterDungeonsInfo(List<Chaptered> list , ChapterLevel level){
		ChapterManager chapterManager = MonoInstancePool.getInstance<ChapterManager>();
		foreach(var chapterd in list){
			int chapterId = chapterd.id;
			ChapterStruct chapterStruct = chapterManager.GetChapterById(chapterId);
			chapterStruct.passedDic[(int)level] = chapterd.pass;
			foreach(Dungeon dugeon in chapterd.list){
				chapterStruct.PassDungeon(level ,dugeon.id ,dugeon.star);
			}
		}
	}
	
	void UpdateChapterAwardsInfo(List<ChapteredAward> awards){
		ChapterManager chapterManager = MonoInstancePool.getInstance<ChapterManager>();
		foreach(var award in awards){
			int chapterId = award.id;
			
			var chapter = chapterManager.GetChapterById(chapterId);
			chapter.award.totalCurrentStars = award.star;
			chapter.award.Box1 = award.box1;
			chapter.award.Box2 = award.box2;
			chapter.award.Box3 = award.box3;
			chapter.award.Box4 = award.box4;
		}
	}
	#endregion
	void UpdateChapterInfo(SocketModel module){
		ChapterManager chapterManager = MonoInstancePool.getInstance<ChapterManager>();
		var msg = MsgSerializer.Deserialize<MsgChapteredRep>(module);
		int chapterId = msg.chaptered;
		int dungeonId = msg.dungeon;
		int dungeonStarNum = msg.star;
		int chapterStarNum = msg.total;
		int dungeonType = msg.type;
		bool pass = msg.pass;
		
		ChapterLevel level = (ChapterLevel)dungeonType;
		ChapterStruct chapterStruct = chapterManager.GetChapterById(chapterId);
		chapterStruct.award.totalCurrentStars = chapterStarNum;
		chapterStruct.passedDic[(int)level] = pass;
		chapterStruct.PassDungeon(level , dungeonId , dungeonStarNum);
		MonoInstancePool.getInstance<ChapterManager>().UpdateUnLockInfo();
	}
	
	void OnChapterBoxInfo(SocketModel module){
		ChapterManager chapterManager = MonoInstancePool.getInstance<ChapterManager>();
		
//		var msg = MsgSerializer.Deserialize<MsgChapteredBoxRep>(module);
//		List<Property.Equip> equipments = msg.equip;
//		List<Property.Item> items = msg.item;
//		ChapterStruct chapter = chapterManager.GetChapterById(350001);
//		chapter.award.Box1 = true;
	}
}