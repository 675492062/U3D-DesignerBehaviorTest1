using UnityEngine;
using System.Collections;

public class AreanDetailHeroSc : MonoBehaviour {

	public UILabel labelName;
	
	public UILabel labelLv;
	
	public Transform[] stars;
	
	public Transform[] equipments;
	
	HeroData heroData;
	
	public void BindingData(HeroData data){
		this.heroData = data;
	}
	
	public void FreshUI(){
		if(this.heroData == null){
			Debug.LogError("[AreanDetailHeroSc] : the data is null ,you may forgot call the function BindingData");
			return;
		}
		labelName.text = heroData.name;
		labelLv.text = "Lv." + heroData.level.ToString();
		for(int i = 0 ; i < stars.Length ; i++){
			stars[i].gameObject.SetActive(heroData.starLevel > i);
		}		
		
		for(int i = 0 ; i <equipments.Length; i ++){
			Transform t = equipments[i];
			
			EquipmentItem equip = heroData.equipmentList.getItemByIdx(i);
			if(equip == null){
				((UISprite)t.FindChild("bg").GetComponent(typeof(UISprite))).spriteName = Sprite_Equip_grey_bg;
				t.FindChild("Sprite").gameObject.SetActive(false);
			}else{
				((UISprite)t.FindChild("bg").GetComponent(typeof(UISprite))).spriteName = Sprite_Equip_light_bg;
				t.FindChild("Sprite").gameObject.SetActive(true);
				((UISprite)t.FindChild("Sprite").GetComponent(typeof(UISprite))).spriteName = StaticEquipment.Instance().getStr(equip.templateID , "icon");
			}
		}
	}
	
	void OnDestory(){
		this.heroData = null;
	}
	
	public const string Sprite_Equip_light_bg = "hb_03";
	
	public const string Sprite_Equip_grey_bg = "hb_02";
}
