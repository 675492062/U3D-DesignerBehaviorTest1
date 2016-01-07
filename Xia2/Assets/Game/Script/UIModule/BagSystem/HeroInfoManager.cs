using UnityEngine;
using System.Collections;

public class HeroInfoManager : MonoBehaviour {

	public UILabel FightingNum;//
	public UILabel HeroName;
	public UILabel Level;
	public UILabel Exp;
	public UISprite []Star;
	public UIButton[] EquipList;
	public GameObject TextureBox;
	public UISprite atkType;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
//		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
//		if(null == data)
//		{
//			return;
//		}
//		if(data.equipmentList.isDirty)
//		{
//			data.equipmentList.isDirty = false;
//			refreshList();
//		}
	}
	public void setStar(int star)
	{
		for(int i = 0; i < Star.Length; i++)
		{
			if(i < star)
			{
				Star[i].gameObject.SetActive(true);
				Star[i].spriteName = "hb_20";
				Vector3 pos = Star[i].transform.localPosition;
				pos.x = 0;
				pos.x = i*Star[i].width + Star[i].width/2 + i*6;
				Star[i].transform.localPosition = pos;
			}
			else 
			{
//				Star[i].spriteName = "hb_21";
				Star[i].gameObject.SetActive(false);
			}
		}
		int AllWidth = (star-1) * Star [0].width + (star-1) * 6;
		Vector3 parentPos = Star [0].transform.parent.transform.localPosition;
		parentPos.x = 0;
		parentPos.x -= AllWidth / 2;
		Star [0].transform.parent.transform.localPosition = parentPos;
	}
	public void setLevel(int level)
	{
		if(null != Level)
		{
			Level.text = "Lv." + level;
		}
	}
	public void setName(string name)
	{
		if(null != HeroName)
		{
			HeroName.text = name;
		}
	}
	public void setFightPower(int power)
	{
		if(null != FightingNum)
		{
			FightingNum.text = "" + power;
		}
	}
	public void refreshList()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		if(null == data)
		{
			return;
		}
		//更改基本数据
		setName(data.name);
		setLevel(data.level);
		setStar(data.starLevel);
		setFightPower((int)data.getMaxAttack());
		setAtkIcon (data.heroType, true);
		//更改人物模型
		MonoInstancePool.getInstance<HeroManager>().getCurShowHero().equipmentList.isDirty = true;
		ModelRenderTexture tex = GetComponentInChildren<ModelRenderTexture>();
		if(tex != null)
		{
			int templateID = data.templateID;
			tex.refresh(templateID);
			//换装
			EquipmentChange changeEquip = tex.parent.GetComponentInChildren<EquipmentChange> ();
			if(changeEquip != null)
			{
				changeEquip.updateHeroSystemModel();
			}
		}
//		//更改装备
		EquipmentList list = data.equipmentList;
		clear();
		for(int i = 0; i < 1;/*EquipList.Length;*/ i++)
		{
			EquipListIconInfo info = EquipList[i].GetComponentInChildren<EquipListIconInfo>();//
			if(null == info)
			{
				continue;
			}
			int type = info.type;
			EquipmentItem item = list.getItemByType(type);
			if(null != item)
			{
				info.guid = item.guid;
				if(null != info.Icon)
				{
					info.Icon.spriteName = item.icon;
					info.BackGround.gameObject.SetActive(false);
					info.Border.spriteName = "hb_03";
				}
			}
			else 
			{
				info.Icon.spriteName = "";
				info.BackGround.gameObject.SetActive(true);
				info.Border.spriteName = "hb_02";
			}
		}

	}
	public void clear()
	{
		for(int i = 0; i < EquipList.Length; i++)
		{
			EquipListIconInfo info = EquipList[i].GetComponentInChildren<EquipListIconInfo>();//
			if(null == info)
			{
				continue;
			}
			info.guid = 0;
			if(info.Icon != null)
			{
				info.Icon.spriteName = "1";
			}
		}
		EquipmentChange function = TextureBox.GetComponentInChildren<EquipmentChange>();
		if(function != null)
		{
			function.clear();
		}

	}
	public void setAtkIcon (int type, bool active)
	{
		string spriteName = "";
		switch(type)
		{
		case (int)GlobalDef.EquipNeedRoleType.E_KNIFE:           //刀类
			spriteName = active ? "ui_voc_daoke" : "ui_voc_gray_daoke";
			break;
		case (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE:        //双刀类
			spriteName = active ? "ui_voc_cike" : "ui_voc_gray_cike";
			break;
		case (int)GlobalDef.EquipNeedRoleType.E_LONGKNIFE:  	 //长柄利器类
			spriteName = active ? "ui_voc_mengshi" : "ui_voc_gray_mengshi";
			break;
		case (int)GlobalDef.EquipNeedRoleType.E_LONGWEAPON:      //长柄类
			spriteName = active ? "ui_voc_lishi" : "ui_voc_gray_lishi";
			break;
		case (int)GlobalDef.EquipNeedRoleType.E_LONGDISTANCE:    //远程类
			spriteName = active ? "ui_voc_sheshou" : "ui_voc_gray_sheshou";
			break;
		case (int)GlobalDef.EquipNeedRoleType.E_MAGE:            //法师类
			spriteName = active ? "ui_voc_moushi" : "ui_voc_gray_moushi";
			break;
		}
		atkType.spriteName = spriteName;
	}
}
