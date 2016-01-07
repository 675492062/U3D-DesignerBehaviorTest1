using UnityEngine;
using System.Collections;

public class UIAwardBox : MonoBehaviour {
	public UISprite boxBg;
	
	public UILabel labelStarNum;
	
	public void FreshUI(UIRewardController.BoxData data){
		labelStarNum.text = data.starNum.ToString();
		switch(data.state){
			case UIRewardController.BoxState.closed:
				boxBg.spriteName = ChapterConstants.RewardConstants.SPRITE_BOX_CLOSED;
				break;
			case UIRewardController.BoxState.hasKey:
				boxBg.spriteName = ChapterConstants.RewardConstants.SPRITE_BOX_HASKEY;
				break;
			case UIRewardController.BoxState.open:
				boxBg.spriteName = ChapterConstants.RewardConstants.SPRITE_BOX_OPEN;
				break;
		}
	}
}
