using UnityEngine;
using System.Collections;

public class RankItemScript : MonoBehaviour {

	public UISprite sprite_bg;
	
	public UISprite sprite_photo;
	
	public UILabel labelName;
	
	public UILabel labelRankIndex;
	
	public UISprite sprite_rankIndex;						//the first , second , third
	
	public UILabel labelVipLevel;
	
	public UILabel labelStarNum;
	
	public Transform tVipRoot;
	
	RankerStruct data;
	
	public void BindingData(RankerStruct ranker){
		this.data = ranker;
	}
	
	public void FreshUI(){
		if(this.data == null){
			Debug.LogError("[ItemScript]: the data is null");
			return;
		}
		sprite_bg.spriteName = GetBgSpriteName();
		labelRankIndex.gameObject.SetActive(data.rankIndex > 3);
		sprite_rankIndex.gameObject.SetActive(data.rankIndex <= 3);
		
		switch(data.rankIndex){
			case 1:
				sprite_rankIndex.spriteName = ChapterConstants.RankConstants.SPRITE_RANK_INDEX_1;
				break;
			case 2:
				sprite_rankIndex.spriteName = ChapterConstants.RankConstants.SPRITE_RANK_INDEX_2;
				break;
			case 3:
				sprite_rankIndex.spriteName = ChapterConstants.RankConstants.SPRITE_RANK_INDEX_3;
				break;
		}
		
		labelName.text = this.data.name;
		labelRankIndex.text = this.data.rankIndex.ToString();
		labelVipLevel.text = this.data.vipLevel.ToString();
		labelStarNum.text = this.data.totalStarNum.ToString();
		
		tVipRoot.gameObject.SetActive(this.data.vipLevel != -1);
	}
	
	string GetBgSpriteName(){
		if(data.rankIndex == 1)return ChapterConstants.RankConstants.SPRITE_BG_YELLOW;
		if(data.rankIndex == 2)return ChapterConstants.RankConstants.SPRITE_BG_BLUE;
		if(data.rankIndex == 3)return ChapterConstants.RankConstants.SPRITE_BG_RED;
		return ChapterConstants.RankConstants.SPRITE_BG_BLUE;
	}
}