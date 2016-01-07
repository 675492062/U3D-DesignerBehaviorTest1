using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDungeonTipController : MonoBehaviour {
	
	public GameObject btnClose;
	
	public GameObject btnAttack;
	
	public GameObject btnSweepTenTimes;
	
	public GameObject btnSweepOnce;
	
	private DungeonStruct dungeonData;
	
	public UISprite[] tStars;
	
	public UILabel labelName;
	
	public UILabel labelInstruction;
	
	public UILabel labelNeedEnergyNum;				//需要消耗的体力
		
	void Awake(){
		UIEventListener.Get(btnClose).onClick += UIClickCloseBtn;
		UIEventListener.Get(btnAttack).onClick += UIClickAttackBtn;
		UIEventListener.Get(btnSweepTenTimes).onClick += UIClickSweepTenTimes;
		UIEventListener.Get(btnSweepOnce).onClick += UIClickSweepOnce;
	}
	
	void UIClickCloseBtn(GameObject gameObject)
	{
		Debug.Log("[UIDungeonTip].UIClickCloseBtn...");
		Hide();
	}
	
	void UIClickAttackBtn(GameObject gameObject)
	{
		Debug.Log("[UIDungeonTip].UIClickAttackBtn ...");

		MonoInstancePool.getInstance<SendFightMsgHander>().SendEnterFightReq(dungeonData.baseData.belongId , dungeonData.id , (int)dungeonData.Level);
		LevelData.SetData(dungeonData.baseData.belongId , dungeonData.id , (int)dungeonData.Level);
	}
	
	void UIClickSweepTenTimes(GameObject gameObject)
	{
		Debug.Log("[UIDungeonTip].UIClickSweepTenTimes ...");
	}
	
	void UIClickSweepOnce(GameObject gameObject)
	{
		Debug.Log("[UIDungeonTi].UIClickSweepOnce ...");
	}
	
	void Hide(){
		this.gameObject.SetActive(false);
		SetDungeonData(null);
	}
	
	void Show(){
		this.gameObject.SetActive(true);
		FreshUI();
	}
	
	public void ShowWithData(DungeonStruct data)
	{
		SetDungeonData(data);
		this.Show();
	}
	
	void FreshUI(){
		if(this.dungeonData == null){
			Debug.LogError("[UIDungeonTip].dungeonData is nulll");
			return;
		}
		
		for(int i = 0 ; i < tStars.Length ; i ++){
			tStars[i].spriteName = dungeonData.PossessStarNum >= (i + 1) ? ChapterConstants.Dungeont.Star_Poly_Light_SpriteName : ChapterConstants.Dungeont.Star_Poly_Grey_SpriteName;
		}
		labelName.text = this.dungeonData.baseData.name;
		labelInstruction.text = this.dungeonData.baseData.txt;
		labelNeedEnergyNum.text = this.dungeonData.baseData.energy.ToString();
	}
	
	void SetDungeonData(DungeonStruct data){
		this.dungeonData = data;
	}
	
	void OnDestory(){
		this.dungeonData = null;
	}
}