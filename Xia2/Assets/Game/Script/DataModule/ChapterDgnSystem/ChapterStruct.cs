using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum ChapterLevel
{
		Normal  = 1,					//普通章节
		NightMare = 2					//噩梦章节
}

//章节数据结构
public class ChapterStruct
{
	public class Award
	{
		public int totalChapterStars;
		public int totalCurrentStars;
		bool box1;								//领取奖励 get or not

		public bool Box1 {
	
			set {
					box1 = value;
					if (awardAction != null)awardAction ();
			}
			get {
					return box1;
			}
		}						

		bool box2;

		public bool Box2 {
			get{ return box2;}
			set {
					box2 = value;
					if (awardAction != null)awardAction ();
			}
		}
		bool box3;
		public bool Box3 {
			get{ return box3;}
			set{ 	
					box3 = value;
					if (awardAction != null)awardAction ();
				}
		}
		bool box4;
		public bool Box4 {
			get{ return box4;}
			set{ 
					box4 = value;
					if (awardAction != null)awardAction ();
				}
		}

		public Action awardAction;
	}

	public int id;
	public int lastId;										//上一个章节id
	public ChapterItem baseData;					
	ChapterLevel currentLevel;								//当前章节难度等级
	public Action levelChangeAction;

	public ChapterLevel Level {
		get {
				return currentLevel;
		}
		set {
				currentLevel = value;
				if (levelChangeAction != null)
						levelChangeAction ();
		}
	}

	Dictionary<int , Dictionary<int ,DungeonStruct>> possessDungeonDic;									//当前章节所拥有的副本		key1 : chapterLevel , key2 : dungeon id		

	public Dictionary<int , bool> passedDic;															//是否通关章节，按难度区分（Normal , NightMare）

	public Award award{ get; set; }																		//章节星数奖励


	//lv难度章节是否开启
	public bool UnLocked(int lv)														
	{
		if(lv == (int)ChapterLevel.Normal){
			if(lastId == 0){
				return true;
			}
			bool lastNormalunLocked = MonoInstancePool.getInstance<ChapterManager>().GetChapterById(lastId).passedDic[(int)ChapterLevel.Normal];
			int userLv = MonoInstancePool.getInstance<UserData>().level;

			if(lastNormalunLocked && userLv >= baseData.openLv){
				return true;
			}
			return false;
		}
		//开启一个难度级别的章节，取决于上一个级别的章节是否通关
		return passedDic [lv - 1];
	}

	public ChapterStruct (int id)
	{
		this.id = id;
		this.currentLevel = ChapterLevel.Normal;
		passedDic = new Dictionary<int, bool> ();
		passedDic [(int)ChapterLevel.Normal - 1] = true;								//默认普通难度章节的上一级副本是应该通关的
		passedDic [(int)ChapterLevel.Normal] = false;
		passedDic [(int)ChapterLevel.NightMare] = false;
		baseData = new ChapterItem (id);
		possessDungeonDic = new Dictionary<int, Dictionary<int, DungeonStruct>> ();
		LoadFromLocalData ();
		award = new Award ();
		award.totalChapterStars = baseData.starCount;
	}

	//先从本地加载当前副本拥有的副本，然后根据服务器数据更新章节，副本的解锁状态
	void LoadFromLocalData ()
	{
		possessDungeonDic.Clear ();
		possessDungeonDic.Add ((int)ChapterLevel.Normal, new Dictionary<int, DungeonStruct> ());
		possessDungeonDic.Add ((int)ChapterLevel.NightMare, new Dictionary<int, DungeonStruct> ());

		Dictionary<int , int> dungeonDic = baseData.GetDungeonIdDic ();
		foreach (KeyValuePair<int  , int> keyValue in dungeonDic) {
				DungeonStruct dungeonNormal = new DungeonStruct (keyValue.Value, ChapterLevel.Normal);
				DungeonStruct dungeonNightMare = new DungeonStruct (keyValue.Value, ChapterLevel.NightMare);
				possessDungeonDic [(int)ChapterLevel.Normal].Add (keyValue.Value, dungeonNormal);
				possessDungeonDic [(int)ChapterLevel.NightMare].Add (keyValue.Value, dungeonNightMare);
		}
	}

	//获取当前章节 chapterLevel难度的副本字典
	public Dictionary<int , DungeonStruct> GetDungeonDicByLevel (ChapterLevel chapterLevel)
	{
		return possessDungeonDic [(int)chapterLevel];
	}

	//获取当前章节难度为level，id为dungeonId的副本
	public DungeonStruct GetDungeonByLevelAndId (ChapterLevel level, int dungeonId)
	{
		return GetDungeonDicByLevel (level) [dungeonId];
	}

	//通关了当前难度的为level,id为dungeonId的副本，取得的星数为starNum
	public void PassDungeon (ChapterLevel level, int dungeonId, int starNum)
	{
		possessDungeonDic [(int)level] [dungeonId].PassWithStarNum (starNum);
	}

	//更新章节的副本解锁信息
	public void UpdateUnLockedDungeonInfo ()
	{
		if(!UnLocked((int)ChapterLevel.Normal))return;
		UpdateUnLockedInfo (possessDungeonDic [(int)ChapterLevel.Normal], ChapterLevel.Normal);
		UpdateUnLockedInfo (possessDungeonDic [(int)ChapterLevel.NightMare], ChapterLevel.NightMare);
	}

	//当一个副本通关了，检测可以开启的副本
	void UpdateUnLockedInfo (Dictionary<int ,DungeonStruct> dic, ChapterLevel level)
	{
		if (!passedDic [(int)level - 1]) {
				return;
		}
		foreach (KeyValuePair<int ,DungeonStruct> keyValue in dic){
			DungeonStruct dungeon = dic [keyValue.Key];
			//protected code
			if(dungeon.baseData.linkedId != 0 && !dic.ContainsKey(dungeon.baseData.linkedId)){
				Debug.LogError("[UpdateUnLockedInfo] the chapter or dungen table is wrong! Please fix it!");
				continue;
			}

			if (!dungeon.UnLocked) {
					if (dungeon.baseData.linkedId == 0 || dungeon.IsLinkedPassed (dic [dungeon.baseData.linkedId])) {
							dungeon.UnLocked = true;
					}
			}
		}
	}
}