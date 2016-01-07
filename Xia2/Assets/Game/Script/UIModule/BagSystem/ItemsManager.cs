using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemsManager : MonoBehaviour {
	
	public UIWidget item;
	public UIScrollView scrollView;
	public UISprite select;
	public UISprite bottom;
	public UILabel  bagSize;
	public int bagType;
	int H_Num = 5;
	int X_Offset = 0;
	int Y_offset = 5;
	int Grid_Width = 82;
	int Grid_Height = 84;
	int Grid_Interval = 2;
	int Grid_Interval_H = 6;
	
	public int enterType{get; set;}
	public int curSelectIdx{ get; set;}
	public int curFilterType{get; set;}
	public int curOpenBag{get; set;}
	// the item dictionary
	Dictionary<long , UIWidget> ItemDict = new Dictionary<long, UIWidget>();
	// Use this for initialization
	void Start () 
	{
		curOpenBag = 1;
		curSelectIdx = -1;
		select.gameObject.SetActive (false);

		addItemBackground();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(MonoInstancePool.getInstance<BagManager>().getBagByType(curOpenBag).IsDirty)
		{
			MonoInstancePool.getInstance<BagManager>().getBagByType(curOpenBag).IsDirty = false;
			RefreshBag();
		}
	}
	void LateUpdate()
	{
		if(curSelectIdx != -1)
		{
			UIWidget item = ItemDict.ElementAt(curSelectIdx).Value;
			select.transform.position = item.transform.position;
		}
	}
	void addItemByIdx(int idx, BaseItem data)	
	{
		if(idx < 0 || idx >= ItemDict.Count)
		{
			Debug.LogError("idx out rang! idx: "+ idx);
			return;
		}
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(bagType);
		if(null == bag)
		{
			return;
		}
		EquipmentItem item = data as EquipmentItem;
			
		ItemProperty pro = ItemDict[idx].GetComponentInChildren<ItemProperty>();
		pro.index = idx;
		updateProperty(pro, item);
	}

	public void RefreshBag()
	{
		HideAllItem ();
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(bagType);
		if(null == bag)
		{
			return;
		}
		int num = bag.getNum();
		for(int i = 0; i < num && i < bag.maxNum && i <ItemDict.Count; i++)
		{
			EquipmentItem item = bag.getItemByIdx(i) as EquipmentItem;
			
			ItemProperty pro = ItemDict[i].GetComponentInChildren<ItemProperty>();
			pro.index = i;
			updateProperty(pro, item);
		}
		if(bagSize != null)
		{
			bagSize.text = "" + num + "/" + bag.maxNum;
		}
	}
	public void UpdatePos (int idx, UIWidget instance)
	{
		int h = idx / H_Num;
		int l = idx % H_Num;
		Vector3 pos = new Vector3 ();
		pos.x = (l+1) * Grid_Width + Grid_Interval*l + X_Offset;
		pos.y = h     * -1*Grid_Height + -1*Grid_Interval_H*h - Y_offset;
		
		pos.x -= scrollView.panel.width / 2 + instance.width/2 ;
		pos.y += scrollView.panel.height / 2 - instance.height/2;
		instance.transform.localPosition = pos;
	}
	public void DelItemByIdx (int idx)
	{
		if(idx >= ItemDict.Count)
		{
			Debug.Log("DelItemByIdx idx out of range! idx: " + idx);
			return;
		}
		long guid = ItemDict.ElementAt (idx).Key;
		ItemDict.Remove (guid);
		for(int i = idx; i < ItemDict.Count; i++)
		{
			UpdatePos(i, ItemDict.ElementAt (i).Value);
		}
	}
	public void DelCurSelectItem()
	{
		DelItemByIdx (curSelectIdx);
	}
	public void setSelectPos(Vector3 pos)
	{
		if(select != null)
		{
			select.gameObject.SetActive (true);
			select.transform.position = pos;
		}
	}
	public int getIdxByGuid(long guid)
	{
		if(!ItemDict.ContainsKey(guid))
		{
			Debug.Log("getIdxByGuid has not key: " + guid);
			return -1;
		}
		UIWidget widget = ItemDict[guid];
		ItemProperty pro = widget.GetComponentInChildren<ItemProperty> ();
		return pro.index;
	}
	void HideAllItem()
	{
		for(int i = 0; i < ItemDict.Count; i++)
		{
			ItemProperty pro = ItemDict.ElementAt (i).Value.GetComponentInChildren<ItemProperty>();
			pro.Icon.gameObject.SetActive(false);
			pro.num_label.gameObject.SetActive(false);
			pro.MaskBack.gameObject.SetActive(false);
		}
	}
	public void FilterByType(int type)
	{
		curFilterType = type;
		HideAllItem ();
		addItemByTpye(type);
	}
	void addItemByTpye(int type)
	{
		Debug.Log("num " + MonoInstancePool.getInstance<BagManager>().getBagByType(curOpenBag).getNum());
		int count = 0;
		for(int i = 0; i < MonoInstancePool.getInstance<BagManager>().getBagByType(curOpenBag).getNum(); i++)
		{
			BaseItem item = MonoInstancePool.getInstance<BagManager>().getBagByType(curOpenBag).getItemByIdx(i);
			Debug.Log("type " + item.type + " filterType: " + type);
			if(item.type == type || type == (int)GlobalDef.ItemType.ITEM_NORMAL)
			{
				addItemByIdx (count, item);
				count++;
			}
		}
	}
	public void addItemBackground()
	{
		BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(bagType);
		if(null == bag)
		{
			return;
		}
		int initNum = bag.maxNum;
		int h = 0;
		int l = 0;
		for(int i = 0; i < initNum; i++)
		{
			int idx = i;
			h = idx / H_Num;
			l = idx % H_Num;
			Vector3 pos = new Vector3 ();
			pos.x = (l+1) * Grid_Width + Grid_Interval*l + X_Offset;
			pos.y = h     * -1*Grid_Height + -1*Grid_Interval_H*h - Y_offset;
			
			UIWidget instance = Instantiate(item) as UIWidget;
			instance.gameObject.SetActive(true);
			instance.transform.parent = scrollView.transform;
			instance.transform.localScale = Vector3.one;
			
			pos.x -= scrollView.panel.width / 2 + instance.width/2 ;
			pos.y += scrollView.panel.height / 2 - instance.height/2;
			instance.transform.localPosition = pos;

			ItemDict.Add (i, instance);

			ItemProperty pro = instance.GetComponentInChildren<ItemProperty> ();
			pro.Icon.spriteName = "";
		}
		h += 1;
		Vector3 bottomPos = bottom.transform.localPosition;
		bottomPos.y = h * -1*Grid_Height + -1*Grid_Interval_H*h - Y_offset;
//		bottomPos.x -= scrollView.panel.width / 2 + bottom.width/2 ;
		bottomPos.y += scrollView.panel.height / 2 - bottom.height/2;

		bottom.transform.localPosition = bottomPos;

		scrollView.Scroll (0);
	}
	void updateProperty(ItemProperty pro, EquipmentItem item)
	{
		pro.guid = item.guid;
		pro.setNum(item.haveNum);
		pro.templateID = item.templateID;
		pro.setIcon(item.icon);
		pro.type = item.type;
	}
}
