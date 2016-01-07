using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeroSysEquipBagWindow : MonoBehaviour {

	public UIScrollView bagScrollView;
	public Transform    EquipItemPrefab;
	public UISprite     selectBorder;
	int Grid_Heigh = 100;
	// the item dictionary
	Dictionary<long , Transform> HeroItemDict = new Dictionary<long, Transform>();

	int m_curType = -1;
	// Use this for initialization
	void Start () 
	{
		selectBorder.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnEnable()
	{
//		MonoInstancePool.getInstance<BagManager> ().addTempData ();
		selectBorder.gameObject.SetActive (false);
	}
	public void refresh ()
	{
		refreshBagState (m_curType);
	}
	public void refreshBagState(int type)
	{
		Debug.LogError (" filtertype: " + type);
//		if(m_curType == type)
//			return;
		m_curType = type;

		HeroData herodata = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		if(herodata == null)
		{
			return;
		}
		int roleType = herodata.heroType;

		hideAll();
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType((int)GlobalDef.BagType.B_EQUIPMENT);
		if(null == bag)
		{
			return;
		}
		int initNum = bag.getNum();
		int idx = 0;
		for(int i = 0; i < initNum; i++)
		{
			EquipmentItem data = bag.getItemByIdx(i) as EquipmentItem;
			if(data == null)
			{
				continue;
			}
			if(data.equitype != type)
			{
				continue;
			}
			if(data.needrole != roleType)
			{
				continue;
			}
			if(idx < HeroItemDict.Count)
			{
				Debug.Log("i " + i + " count " + HeroItemDict.Count);
				GameObject itemGO = HeroItemDict.ElementAt(idx).Value.gameObject;
				itemGO.SetActive(true);
				//refresh show
				EquipBagItemProperty item_pro = itemGO.GetComponentInChildren<EquipBagItemProperty>();
				item_pro.refresh(data);
				item_pro.idx = idx;
				item_pro.itemGuid = data.guid;
				idx++;
				continue;
			}
			Transform instance = Instantiate(EquipItemPrefab) as Transform;
			instance.gameObject.SetActive(true);
			instance.transform.parent = bagScrollView.transform;
			instance.transform.localScale = Vector3.one;

			Vector3 pos = Vector3.zero;
			pos.x = 0;
			pos.y = -1*idx*Grid_Heigh + bagScrollView.panel.height/2 - Grid_Heigh/2;
			instance.transform.localPosition = pos;
			//add
			HeroItemDict.Add (data.guid, instance);
			//refresh show
			EquipBagItemProperty pro = instance.GetComponentInChildren<EquipBagItemProperty>();
			pro.refresh(data);
			pro.idx = idx;
			pro.itemGuid = data.guid;

			idx++;
		}

		updateSelectBorderPos (0);
	}
	public void updateSelectBorderPos(int idx)
	{
		selectBorder.gameObject.SetActive (true);
		selectBorder.transform.localPosition = HeroItemDict.ElementAt (idx).Value.transform.localPosition;
	}
	public void hideAll()
	{
		for(int i = 0; i < HeroItemDict.Count; i++)
		{
			Transform btn = (Transform)HeroItemDict.ElementAt(i).Value;
			if(null != btn)
			{
				btn.gameObject.SetActive(false);
			}
		}
	}
}
