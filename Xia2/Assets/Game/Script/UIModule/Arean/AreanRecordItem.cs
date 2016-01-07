using UnityEngine;
using System.Collections;

//竞技记录列表的item
public class AreanRecordItem : MonoBehaviour {
	
	public UILabel labelTimeDate;
	
	public UILabel labelTimeMin;
		
	public UILabel labelRankIndex;
	
	public UILabel labelPlayerName;
	
	public GameObject[] heroItems;
	
	public UISprite spriteUpOrDown;
	
	public UISprite spriteResult;
	
	AreanRecordData recordData;
	
	public void BindingData(AreanRecordData data){
		this.recordData = data;
	}
	
	public void FreshUI(){
		if(this.recordData == null){
			Debug.LogError("[AreanRecordItem] recordData is null !");
			return;
		}
		labelPlayerName.text = this.recordData.name;
		labelRankIndex.text = this.recordData.rankIndex.ToString();
		spriteUpOrDown.spriteName = GetUporDownSpriteName();
		spriteResult.spriteName = GetResultSpriteName();
		string[] time = this.recordData.time.Split('*');
		if(time.Length > 0)labelTimeDate.text = time[0].ToString();
		if(time.Length > 1)labelTimeMin.text = time[1].ToString();
		FreshHeroUI();
	}	
	
	void FreshHeroUI(){
		for(int i = 0 ; i < heroItems.Length ; i++){
			AreanHeroData data = recordData.heroDatas[i];
			if(data != null){
				AreanHeroItem itemsc = (AreanHeroItem)heroItems[i].GetComponent(typeof(AreanHeroItem));
				itemsc.FreshUI(data);
			}
		}
	}
	
	string GetUporDownSpriteName(){
		return recordData.result ? SpriteName_Up : SpriteName_Down;
	}
	
	string GetResultSpriteName(){
		return recordData.result ? SpriteResult_win : SpriteResult_fail;
	}
	
	void OnDestory(){
		this.recordData = null;
	}
	
	public const string SpriteName_Up = "warfar_13";
	
	public const string SpriteName_Down = "warfar_12";
	
	public const string SpriteResult_fail = "warfar_30";

	public const string SpriteResult_win = "warfar_31";
}