using UnityEngine;
using System.Collections;

public class PropertyInfoWindow : MonoBehaviour {

	public UILabel[] Property = new UILabel[15];
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnEnable()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		refresh (data);
	}
	public void refresh(HeroData data)
	{
		if(data == null)
			return;
		Property [0].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		float min = data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		float max = data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		Property [1].text = "" + (int)min + "-" + max;
		Property [2].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		Property [3].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
		Property [4].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
		Property [5].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);
		Property [6].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_DODGELV);
		Property [7].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_HITLV);
		Property [8].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_ATKSPD);
		Property [9].text = "" + (int)data.getHitRate();
		Property [10].text = "" + (int)data.getCriticalRate();
		Property [11].text = "" + (int)data.getDodgeRate();
		Property [12].text = "" + (int)data.getCriticalDamage();
		Property [13].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		Property [14].text = "" + (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST);
	}
}
