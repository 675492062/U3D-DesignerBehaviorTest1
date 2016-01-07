using UnityEngine;
using System.Collections;

public class SkillInfoWindow : MonoBehaviour {

	public UISprite Icon;
	public UILabel  Name;
	public UILabel  Level;
	public UILabel  CostMp;
	public UILabel  CDTime;
	public UILabel  Des1;
	public UILabel  Des2;
	public UILabel  LvupCost;


	public int skillIdx{ get; set;}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void refresh()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		SkillItem item = data.skillList.getSkillByIdx (skillIdx);
		if(item != null)
		{
			item.effectDescribe.refresh(data,item);
			refresh(data, item, skillIdx);
		}
	}
	public void refresh(HeroData data, SkillItem skill, int idx)
	{
		Icon.spriteName = skill.icon;
		Name.text   = skill.name;
		Level.text  = skill.level + "级";
		CostMp.text = ""+skill.consume;
		CDTime.text = ""+(int)skill.cd;
		Des1.text   = skill.describe;

		skill.effectDescribe.refresh (data, skill);
		Des2.text = skill.effectDescribe.des;

		int cost = 0;
		skillIdx = idx;
		switch(skillIdx)
		{
		case 0:
			cost = StaticSkilllevel.Instance().getInt (skill.level, "price0");
			break;
		case 1:
			cost = StaticSkilllevel.Instance().getInt (skill.level, "price1");	
			break;
		case 2:
			cost = StaticSkilllevel.Instance().getInt (skill.level, "price2");
			break;
		case 3:
			cost = StaticSkilllevel.Instance().getInt (skill.level, "price3");
			break;
		}
		LvupCost.text = "" + cost;
	}
	public void clickLvUp()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero();
		if(null == data)
		{
			Debug.LogError("now have not select any hero!");
			return;
		}
		MonoInstancePool.getInstance<SendHeroSysMsgHander>().sendHeroUpgradeSkill(data.guid, skillIdx);
	}
}
