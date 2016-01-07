using UnityEngine;
using System.Collections;

public class PropertyWindow : MonoBehaviour {
	public UILabel       HeroDescribe;
	public UILabel       LifeNum;
	public UIProgressBar LifeBar;
	public UILabel       AtkNum;
	public UIProgressBar AtkBar;	
	public UILabel       ArmorNum;
	public UIProgressBar ArmorBar;
	public UISkillIcon[] Skills = new UISkillIcon[4];
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
		refreshPropertys (data);
		refreshSkills (data);
	}
	public void refreshPropertys(HeroData data)
	{
		if (null == data)
			return;
		HeroDescribe.text = data.description;

		int starLevel = data.starLevel;
		int life = (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		int minAtk = (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		int maxAtk = (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		int armor  = (int)data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		LifeNum.text = "" + life;
		AtkNum.text = "" + minAtk + "-"+maxAtk;
		ArmorNum.text = "" + armor;

		float maxNum = 1000;
		float bar_1 = data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_1 + (starLevel - 1) * 3);
		float bar_2 = data.getResPro((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1 + (starLevel-1)*3);
		float bar_3 = data.getResPro ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_1 + (starLevel - 1) * 3);
		LifeBar.value = bar_1 * 100 / maxNum;
		AtkBar.value  = bar_2 * 100 / maxNum;
		ArmorBar.value= bar_3 * 100 / maxNum;

	}
	public void refreshSkills(HeroData data)
	{
		if(data == null)
			return;
		for(int i = 0; i < data.skillList.count(); i++)
		{
			SkillItem skillItem = data.skillList.getSkillByIdx (i);
			if(skillItem != null)
			{
				Skills[i].refresh(skillItem);
			}
		}
	}
	public void showSkillInfo_1()
	{
		showSkillInfoByIdx (0);
	}
	public void showSkillInfo_2()
	{
		showSkillInfoByIdx (1);
	}
	public void showSkillInfo_3()
	{
		showSkillInfoByIdx (2);
	}
	public void showSkillInfo_4()
	{
		showSkillInfoByIdx (3);
	}
	void showSkillInfoByIdx(int idx)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		if (data == null)
			return;
		SkillItem skillItem = data.skillList.getSkillByIdx (idx);
		if(skillItem != null)
		{
			HeroSysModules modules = (HeroSysModules)FindObjectOfType(typeof(HeroSysModules));
			if(modules != null)
			{
				modules.showSkillInfoWindow(data, skillItem, idx);
			}
		}
	}
}
