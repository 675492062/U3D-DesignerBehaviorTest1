using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BagManager : MonoBehaviour
{
	public BagManager()
	{
		addTempData();
	}
	public BaseItem createItemByData(Property.Item data)
	{
		int templateid = (int)data.templateid;
		int type = ConfigManager.getInstance().getTypeByTemplateID(templateid);
		BaseItem info = null;
		switch(type)
		{
		case (int)GlobalDef.ItemType.ITEM_NORMAL:
			info = new BaseItem(); 
			break;
		case (int)GlobalDef.ItemType.ITEM_EQUIPMENT:
			info = new EquipmentItem();
			break;
		case (int)GlobalDef.ItemType.ITEM_MEDICINE:
			info = new PotionItem();
			break;
		case (int)GlobalDef.ItemType.ITEM_DIAMOND:
			info = new DiamondItem();
			break;
        case (int)GlobalDef.ItemType.ITEM_MATERIAL:
            info = new MaterialItem();
            break;
		}
		if(null == info)
		{
			info = new BaseItem(); 
		}
		info.parseData (data);
		return info;
	}
	public void addTempData()
	{
		for(int i = 0; i < 1/*GlobalDef.EquipmentTpye.E_MAX*/; i++)
		{
			EquipmentItem item = new EquipmentItem();
			item.guid = (long)i;
			item.templateID = 400001;
			equipmentBag.addItem(item);
			equipmentBag.IsDirty = true;
		}   
													
//		for(int i = 0; i < 5; i++)                   
//		{                                            
//			PotionItem item = new PotionItem();
//			item.guid = (long)i;
//			item.templateID = 530001+i;
//			potionBag.addItem(item);                                        
//		}
//		for(int i = 0; i < 5; i++)                   
//		{                                            
//			DiamondItem item = new DiamondItem();
//			item.guid = (long)i;
//			item.templateID = 600001+i;
//			getDiamondBag().addItem(item);                                   
//		}
//		for(int i = 0; i < 5; i++)
//		{
//			MaterialItem item = new MaterialItem();
//			item.guid = (long)i;
//			item.templateID = 510001+i;
//			getMaterialBag().addItem(item);                                   
//		}
	}

	public BagStruct getNormalBag(){ return normalBag; }
	public BagStruct getEquipmentBag(){ return equipmentBag; }
	public BagStruct getPotionBag(){ return potionBag; }
	public BagStruct getDiamondBag(){ return diamondBag; }
	public BagStruct getMaterialBag(){ return materialBag; }

	BagStruct normalBag = new BagStruct();
	BagStruct equipmentBag = new BagStruct();
	BagStruct potionBag = new BagStruct();
	BagStruct diamondBag = new BagStruct();
	BagStruct materialBag = new BagStruct();

	public BagStruct getBagByType(int type)
	{
		switch(type)
		{
		case (int)GlobalDef.BagType.B_NORMAL:
			return normalBag;
			break;
		case (int)GlobalDef.BagType.B_EQUIPMENT:
			return equipmentBag;
			break;
		case (int)GlobalDef.BagType.B_MATERIAL:
			return materialBag;
			break;
		case (int)GlobalDef.BagType.B_POTION:
			return potionBag;
			break;
		case (int)GlobalDef.BagType.B_DIAMOND:
			return diamondBag;
			break;
		}
		return null;
	}
	public void setAllDirty()
	{
		normalBag.IsDirty    = true; 
		equipmentBag.IsDirty = true;
		potionBag.IsDirty    = true;
		diamondBag.IsDirty   = true;
		materialBag.IsDirty  = true;
	}
}
