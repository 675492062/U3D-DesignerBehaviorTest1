using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
	1.gameObject.setActive(true);
	2.BindingData(data);
	3.FreshUI();
**/
public class DungeonScript : MonoBehaviour {	
	
	public UISprite bg;
	
	public UISprite icon;
	
	public Transform[] starArray;
	
	private DungeonStruct dungeonData;

	public DungeonStruct DungeonData{
		get{
			return dungeonData;
		}
	}
	#region bindingData
	
	public void BindingData(DungeonStruct newData){
		if(this.dungeonData == null){
			this.dungeonData = newData;
			RegistAction();
			return;
		}
		UnRegistAction();
		this.dungeonData = newData;
		RegistAction();
	}
	
	void RegistAction(){
		if(this.dungeonData == null)return;
		this.dungeonData.unLockedAction += UnLockAction;
		this.dungeonData.passedAction += PassedAction;
		this.dungeonData.starNumChangeAction += StarNumChangeAction;
	}
	
	void UnRegistAction(){
		if(this.dungeonData == null)return;
		this.dungeonData.unLockedAction -= UnLockAction;
		this.dungeonData.passedAction -= PassedAction;
		this.dungeonData.starNumChangeAction -= StarNumChangeAction;
	}

	#endregion 
	
	#region data actions
	
	void UnLockAction(){
		FreshBg();
	}
	
	void PassedAction(){
		FreshBg();
	}
	
	void StarNumChangeAction(){
		for(int i = 0 ; i < starArray.Length ; i++){
			starArray[i].gameObject.SetActive(dungeonData.PossessStarNum > i);
		}
	}
	
	#endregion
	
	public void FreshUI(){
		if(dungeonData == null){
			Debug.LogError("[DungeonScript].dungeonData is null");
			return;
		}
		FreshBg();
		StarNumChangeAction();
	}
	
	void FreshBg(){
		bg.spriteName = GetBgSpriteName();
		icon.spriteName = GetIconSpriteName();
	}
	
	string GetBgSpriteName(){
		switch(dungeonData.baseData.type){
			case DungeonItem.DungeonType.Normal:
				return dungeonData.Passed || dungeonData.UnLocked ? ChapterConstants.Dungeont.Normal_UnLocked_Bg_SpriteName : ChapterConstants.Dungeont.Lock_Bg_SpriteName;
			case DungeonItem.DungeonType.Boss:
				return (dungeonData.Passed || dungeonData.UnLocked) ? ChapterConstants.Dungeont.Boss_UnLocked_Bg_SpriteName : ChapterConstants.Dungeont.Lock_Bg_SpriteName;
			default:
				return (dungeonData.Passed || dungeonData.UnLocked)? ChapterConstants.Dungeont.Special_UnLock_Bg_SpriteName : ChapterConstants.Dungeont.Lock_Bg_SpriteName;
		}
		Debug.LogError("[DungeonScript].GetBgSpriteName : cannot get the bg spriteName by the dungeont type!");
		return "";
	}
	
	string GetIconSpriteName(){
		switch(dungeonData.baseData.type){
			case DungeonItem.DungeonType.Normal:
				return (dungeonData.Passed || dungeonData.UnLocked) ? ChapterConstants.Dungeont.Normal_UnLocked_Icon_SpriteName : ChapterConstants.Dungeont.Normal_Locked_Icon_priteName;
			case DungeonItem.DungeonType.Boss:
				return (dungeonData.Passed || dungeonData.UnLocked) ? ChapterConstants.Dungeont.Boss_UnLocked_Icon_SpriteName : ChapterConstants.Dungeont.Boss_Locked_Icon_SpriteName;
			default:
				return (dungeonData.Passed || dungeonData.UnLocked) ? ChapterConstants.Dungeont.Special_UnLocked_Icon_SpriteName : ChapterConstants.Dungeont.Special_Lock_Icon_SpriteName;
		}
		return "";
	}
	
	void OnClick(){
		if(!dungeonData.UnLocked && !dungeonData.Passed ){
			return;
		}
		UIChapterDgnManager.instance.OpenDungeonTipUI(dungeonData);
		
		//test code
		//dungeonData.PassWithStarNum(2);
		//MonoInstancePool.getInstance<ChapterManager>().GetChapterById(dungeonData.baseData.belongId).UpdateUnLockedDungeonInfo();
		//MonoInstancePool.getInstance<SendFightMsgHander>().SendFightEndReq(true , new List<FightMessage.Killer>() , new List<FightMessage.Skada>() , 1 , new List<int>() );
	}
	
	void OnDisable(){
		UnRegistAction();
	}
}