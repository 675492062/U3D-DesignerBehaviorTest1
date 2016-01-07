using UnityEngine;
using System.Collections;

/**
 **	玩家战队 英雄信息
 **
 **/
public class AreanHeroItem : MonoBehaviour {

	public UISprite heroIcon;
	
	public UILabel labelLv;
	
	AreanHeroData heroData;
	
	public void FreshUI(AreanHeroData data){
		this.heroData = data;
		heroIcon.spriteName = StaticHero.Instance().getStr(data.id , "icon_middle");
		//labelLv.text = data.lv.ToString();
	}
	
	void OnDestory(){
		heroData = null;
	}
}