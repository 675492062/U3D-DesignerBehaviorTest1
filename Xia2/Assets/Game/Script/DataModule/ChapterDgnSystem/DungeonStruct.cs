using UnityEngine;
using System;
using System.Collections;

public class DungeonStruct {

	public int id;
	
	public DungeonItem baseData;			//配置表中的数据
	
	int possessStarNum;						//通关获取的的星星数量
	
	public Action starNumChangeAction;
	
	public int PossessStarNum{
		get{
			return possessStarNum;
		}
		
		set{
			this.possessStarNum = value;
			if(starNumChangeAction != null)starNumChangeAction();
		}
	}
	
	bool unLocked;								//解锁
	
	public Action unLockedAction;
	
	public bool UnLocked{
		get{
			return unLocked;
		}
		set{
			unLocked = value;
			if(unLockedAction != null)unLockedAction();
		}
	}
	
	bool passed;								//通关
	
	public Action passedAction;					
	
	public bool Passed{
		get{
			return passed;
		}
		
		set{
			passed = value;
			if(passedAction != null)passedAction();
		}
	}
	
	ChapterLevel level;						//当前副本所取的章节难度级别
	
	public ChapterLevel Level{
		get{
			return level;
		}
	}
	
	public DungeonStruct(int id , ChapterLevel level){
		this.level = level;
		this.id = id;
		baseData = new DungeonItem(id);
		this.unLocked = ToUnLockInit();							//may be not good , defalut false may be better
		this.passed = false;
		this.possessStarNum = 0;
	}
	
	public void PassWithStarNum(int starNum){
		this.unLocked = true;
		PossessStarNum = starNum;
		Passed = true;
	}

	// to unlock , may be successfull or failed
	bool ToUnLockInit(){
		//may should make sure the belonged chapter is or isnot unlocked
		if(level == ChapterLevel.Normal){
			return baseData.linkedId == 0;
		}
		return false;
	}
	
	//关联副本，是否通关
	public bool IsLinkedPassed(DungeonStruct linked){
		return linked.Passed;
	}
}