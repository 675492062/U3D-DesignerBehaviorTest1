using UnityEngine;
using System.Collections;

public class UISkillItem : MonoBehaviour {

	public UISprite Icon;
	public UILabel  SkillName;
	public UISprite SkillNameBack;
	public UILabel  SkillLevel;
	public UISprite GoldIcon;
	public UILabel  LevelUPcost;
	public UIButton LevelUPBtn;
	public UILabel  UnLockDes;
	
	int templateID;
	int curidx;
	public void refresh(SkillItem item,int idx)
	{
		curidx = idx - 1;
		templateID = item.templateID;
		Icon.spriteName = item.icon;
		SkillName.text = item.name;
		SkillLevel.text = ""+item.level;
		LevelUPcost.text = ""+StaticSkilllevel.Instance ().getInt (item.level,"price"+curidx);
	}
	void Update()
	{

	}
	public void OnRelease()
	{
		HeroUISkillList list = (HeroUISkillList)FindObjectOfType (typeof(HeroUISkillList));
		list.stopDrag();
	}
	public void OnPress()
	{
		HeroUISkillList list = (HeroUISkillList)FindObjectOfType (typeof(HeroUISkillList));
		list.curDragIdx = curidx;
		list.beganPos = Input.mousePosition;
	}
	public void LevelUP_0()
	{
		int res = checkCondition (0);
		if(res < 0)
		{
			return;
		}
		long guid = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero().guid;

		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendHeroUpgradeSkill (guid, 0);
	}
	public void LevelUP_1()
	{
		int res = checkCondition (1);
		if(res < 0)
		{
			return;
		}
		long guid = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero().guid;
		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendHeroUpgradeSkill (guid, 1);
	}
	public void LevelUP_2()
	{
		int res = checkCondition (2);
		if(res < 0)
		{
			return;
		}
		long guid = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero().guid;
		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendHeroUpgradeSkill (guid, 2);
	}
	public void LevelUP_3()
	{
		int res = checkCondition(3);
		if(res < 0)
		{
			return;
		}
		long guid = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero().guid;
		MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendHeroUpgradeSkill (guid, 3);
	}
	public int checkCondition(int skillIdx)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero();
		SkillItem curSkill = data.skillList.getSkillByIdx (skillIdx);
		if(curSkill == null)
		{
			return -1;
		}
		int skill_level = curSkill.level;
		int heroLevel = data.level;
		int cost = StaticSkilllevel.Instance ().getInt (skill_level, "price" + skillIdx);
		int moneytype = StaticSkilllevel.Instance ().getInt (skill_level, "money_type" + skillIdx);
		int needHeroLevel = StaticSkilllevel.Instance ().getInt (skill_level, "hero_level" + skillIdx);

		int haveMoney = MonoInstancePool.getInstance<UserData> ().getMoney(moneytype);
		if(needHeroLevel > heroLevel)
		{
			ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(error != null)
			{
				error.showByErrorID(-20003);
			}
			return -2;
		}
		if(cost > haveMoney)
		{
			ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(error != null)
			{
				error.showErrorWindow("所需的金钱不够");
//				error.showByErrorID(-20003);
			}
			return -3;
		}
		return 1;
	}
//	public void OnDrag()
//	{
//		Vector3 curPos = Input.mousePosition;
//		float offset_x = curPos.x - beganPos.x;
//		float offset_y = curPos.y - beganPos.y;
//
//		Vector3 local = Icon.transform.localPosition;
//		local.x += offset_x;
//		local.y += offset_y;
//		Icon.transform.localPosition = local;
//		beganPos = curPos;
//	}
}
