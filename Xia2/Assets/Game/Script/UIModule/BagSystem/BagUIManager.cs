using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BagUIManager : MonoBehaviour 
{
	public UITexture BarEffectTex;
	public UILabel gold;
	public UILabel diamond;
	public UILabel soulStone;

	public Transform ParticleGuang;  //提升战斗力时的光
	public Transform ParticleZhan;   //“战”字上的特效
	public UISprite SpriteGuang;     //"光"粒子挂载的地方
	public UISprite SpriteZhan;      //"站"粒子挂载的地方
	public UILabel FightNum;         //战斗力数字显示
		
	public Transform m_aniManMBasic;   //男人动作库   
	public Transform m_aniWomenWBasic; //女人动作库 
	public Transform m_aniBigMLBasic;  //大型动作库

	public int  enterType{get; set;}
	public int  curSelectIdx{get; set;}
	public long curSelectGUID{get; set;}
	public int  curBagType{get; set;}
	
	int startNum = 0;
	int endNum = 0;
	public UISprite addFightPowerSP;
	public UISprite subFightPowerSP;

	public HeroSkillUIManager skillManager; 
	public RealmSysManager realmManager;
    public ProgressManager progressManager;


	List<Transform> effect = new List<Transform>();
	void Start () 
	{
		MonoInstancePool.getInstance<BagManager> ().setAllDirty ();
		updateBagMoney ();
		refreshHeroInfo ();
	}
	void OnEnable()
	{
		UIPanel panel = NGUITools.FindInParents<UIPanel> (gameObject);
		UICurrencyManager.Show (transform,panel.depth);
	}
	// Update is called once per frame
	void Update () 
	{

	}
	void LateUpdate()
	{  
	}
	public void AddEffect()
	{
		showFightNum(startNum, endNum);

		Transform guang = Instantiate(ParticleGuang, Vector3.zero, Quaternion.identity) as Transform;
		guang.transform.parent = SpriteGuang.transform;
		guang.transform.localPosition = new Vector3(0f, 0f, 0f);
		guang.transform.localScale = Vector3.one;

		Transform zhan = Instantiate(ParticleZhan, Vector3.zero, Quaternion.identity) as Transform;
		zhan.transform.parent = SpriteZhan.transform;
		zhan.transform.localPosition = new Vector3(395.3f, -20f, 51.9f);
		zhan.transform.localScale = new Vector3(319.9f, 319.9f, 319.9f);

		effect.Add(guang);
		effect.Add(zhan);
	}
	public void clearEffect()
	{
		for(int i = 0; i  < effect.Count;i++)
		{
			Destroy(effect[i].gameObject);
		}
		effect.Clear();
	}
	public void changeFightPower(int start, int end)
	{

		startNum = start;
		endNum = end;
		if(start < end)
		{
			AddEffect();
		}
		else
		{
			showFightNum(startNum, endNum);
		}
	}
	public void showFightNum(int start, int end)
	{
		clearEffect();
		if(start < end)
		{
			addFightPowerSP.gameObject.SetActive(true);
			AddNumEffect ef = addFightPowerSP.GetComponent<AddNumEffect>();
			if(ef != null)
			{
				ef.start(start, end);
			}
		}
		else if(start > end) 
		{
			subFightPowerSP.gameObject.SetActive(true);
			SubNumEffect ef = subFightPowerSP.GetComponent<SubNumEffect>();
			if(ef != null)
			{
				ef.start(start, end);
			}
		}
	}
	public void runFightNumEffect()
	{
		AddFightNum add = FightNum.GetComponentInChildren<AddFightNum>();
		if(add)
		{
			add.run(startNum, endNum);
		}
	}
	public void showItemInfo(long guid)
	{
//		if(item_info == null)
//		{
//			return;
//		}
//		if(!item_info.gameObject.activeSelf)
//		{
//			item_info.gameObject.SetActive(true);
//		}
//		BaseItem item = MonoInstancePool.getInstance<BagManager>().getBagByType(curBagType).getItem (guid);
//		
//		
//		BagItemInfo info = item_info.GetComponentInChildren<BagItemInfo> ();
//		info.setGuid (guid);
//		info.setTemplateID (item.templateID);
	}
	public void showEquipInfo(long guid)
	{
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType((int)GlobalDef.BagType.B_EQUIPMENT);
		if(null == bag)
		{
			return;
		}
		EquipmentItem item = bag.getItem(guid) as EquipmentItem;
		if(null == item)
		{
			return;
		}
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		EquipmentItem cur = data.equipmentList.getItemByType(item.equitype);

		var manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if (manager == null) 
		{
			return;		
		}
		Transform equipment_info = manager.getPanel("EquipmentInfoUI");
		if (null == equipment_info) 
		{
			return;		
		}
		equipment_info.gameObject.SetActive(true);
		EquipInfoUI info = equipment_info.GetComponentInChildren<EquipInfoUI>();
		info.addEquipment(cur, item);
	}
	public void showEquipInfo(EquipmentItem item)
	{
		if(null == item)
		{
			return;
		}
		var manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if (manager == null) 
		{
			return;		
		}
		Transform equipment_info = manager.getPanel("EquipmentInfoUI");
		if (null == equipment_info) 
		{
			return;		
		}
		equipment_info.gameObject.SetActive(true);
		EquipInfoUI info = equipment_info.GetComponentInChildren<EquipInfoUI>();
		info.addEquipment(null, item);
	}
	public void updateBagMoney()
	{
		if(null != gold)
		{
			gold.text = "" + MonoInstancePool.getInstance<UserData>().getMoney((int)GlobalDef.MoneyType.MONEY_GOLD);
		}
		if(null != diamond)
		{
			diamond.text = "" + MonoInstancePool.getInstance<UserData>().getMoney((int)GlobalDef.MoneyType.MONEY_DIAMOND);
		}
		if(null != soulStone)
		{
			soulStone.text = "" + MonoInstancePool.getInstance<UserData>().getMoney((int)GlobalDef.MoneyType.MONEY_SOULSTONE);
		}
	}
	public void refreshHeroInfo()
	{
		HeroInfoManager manager = GetComponentInChildren<HeroInfoManager>();
		if(manager != null)
		{
			manager.refreshList();
		}
	}
	public void refreshItems()
	{
		HeadItemManager head = GetComponentInChildren<HeadItemManager>();
		if(head)
		{
			head.refreshBag();
		}
		ItemsManager items = GetComponentInChildren<ItemsManager>();
		if(items)
		{
			items.RefreshBag();
		}
	}
	public void refreshAllData()
	{
		updateBagMoney();
		refreshHeroInfo();
		clearEffect();
		refreshItems();

		if(skillManager.gameObject.activeSelf)
		{
			skillManager.refresh();
		}
		if(realmManager.gameObject.activeSelf)
		{
			MonoInstancePool.getInstance<HeroManager>().getCurShowHero().realmList.isDirty = true;
//			realmManager.refresh();
		}
        if (progressManager.gameObject.activeSelf)
        {
            progressManager.Refresh(MonoInstancePool.getInstance<HeroManager>().getCurShowHero());
        }
	}
}
