using UnityEngine;
using System.Collections;

public class PlayerInfoScript : MonoBehaviour {
	
	public GameObject btnToShopGold;
	public UILabel labelGold;
	
	public GameObject btnToShopSoul;//??
	public UILabel labelSoul;
	
	public GameObject btnToShopEnergy;
	
	public UILabel labelEnergy;
	
	public void FreshUI(){
		labelGold.text = MonoInstancePool.getInstance<UserData>().gold.ToString();
		labelEnergy.text = MonoInstancePool.getInstance<UserData>().stamina.ToString();
		labelSoul.text = MonoInstancePool.getInstance<UserData>().soulPoint.ToString();
	}
	
	void OnEnable(){
		FreshUI();
	}
}
