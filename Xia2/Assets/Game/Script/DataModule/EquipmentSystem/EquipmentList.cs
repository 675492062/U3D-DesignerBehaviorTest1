using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class EquipmentList  
{
	static int test = 400001;
	Dictionary<long, EquipmentItem> list = new Dictionary<long, EquipmentItem>();
	public bool isDirty{get; set;}
	public EquipmentList()
	{
		isDirty = true;
//        addTempItem();
	}
	public void addTempItem()
	{
		EquipmentItem item = new EquipmentItem();
		item.guid = (long)1;
		item.templateID = 650001;		
//		if (test == 400001)
//			test = 400006;
//		else if (test == 400006)
//			test = 400004;


		addItem(item.guid, item);
		isDirty = true;
	}
	public void clear()
	{
		for(int i = 0; i < list.Count; i++)
		{
			EquipmentItem item = list.ElementAt(i).Value;
			item = null;
		}
		list.Clear ();
	}
	public void addItem(long guid, EquipmentItem item)
	{
		if(list.ContainsKey(guid))
		{
			Debug.LogError("already has this key! guid: " + guid);
			return;
		}
		if(hasThisType(item.equitype))
		{
			removeItemByType(item.equitype);
		}
		list.Add(guid, item);
	}
	public void removeItem(long guid)
	{
		if(!list.ContainsKey(guid))
		{
			Debug.LogError("have not this key! guid: " + guid);
			return;
		}
		list.Remove(guid);
	}
	public EquipmentItem getItemByType(int type)
	{
		for(int i = 0; i < list.Count; i++)
		{
			EquipmentItem item = list.ElementAt(i).Value;
			if(item != null && item.equitype == type)
			{
				return item;
			}
		}
		return null;
	}
	public EquipmentItem removeItemByType(int type)
	{
		for(int i = 0; i < list.Count; i++)
		{
			EquipmentItem item = list.ElementAt(i).Value;
			if(item != null && item.equitype == type)
			{
				list.Remove(item.guid);
			}
		}
		return null;
	}
	public EquipmentItem getItemByIdx(int idx)
	{
		if(idx < 0 || idx >= list.Count)
		{
			Debug.LogError("out of range!");
			return null;
		}
		EquipmentItem item = list.ElementAt(idx).Value;
		return item;
	}
	public EquipmentItem getItemByGuid(long guid)
	{
		for(int i = 0; i < list.Count; i++)
		{
			EquipmentItem item = list.ElementAt(i).Value;
			if(item.guid == guid)
			{
				return item;
			}
		}

		return null;
	}
	public bool hasThisType(int type)
	{
		for(int i = 0; i < list.Count; i++)
		{
			EquipmentItem item = list.ElementAt(i).Value;
			if(item != null && item.equitype == type)
			{
				return true;
			}
		}
		return false;
	}

    public int getCountEquipment()
    {
        return list.Count;
    }


}
