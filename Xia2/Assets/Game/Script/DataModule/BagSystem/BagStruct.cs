using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BagStruct
{
	public BagStruct()
	{
		IsDirty = true;
		maxNum = 20;
	}

	public Dictionary<long, BaseItem> GetDict(){ return BagDict;}

	public void destroy()
	{

	}

	public void clear()
	{
		BagDict.Clear();
	}
	public void addItem(BaseItem item)
	{
		long guid = item.guid;
		if (!BagDict.ContainsKey (guid)) 
		{
			BagDict.Add(guid, item);		
		}
		else
		{
			BagDict[guid].haveNum= item.haveNum;
		}
	}
	public BaseItem getItem(long guid)
	{
		if (BagDict.ContainsKey (guid)) 
		{
			return BagDict[guid];		
		}
		else 
		{
			Debug.LogError("warning Item not found! ");
			return null;
		}
	}
	public void removeItem(long guid)
	{
		if (BagDict.ContainsKey (guid)) 
		{
			BagDict.Remove(guid);
		}
	}
	public void setItemNum(long guid, int num)
	{
		if (BagDict.ContainsKey (guid)) 
		{
			BagDict[guid].haveNum = num;
		}
	}

	public BaseItem getItemByIdx(int idx)
	{
		if (idx >= BagDict.Count) 
		{
			Debug.LogError("out of range! idx: " + idx);
			return null;
		}
		return BagDict.ElementAt(idx).Value;
	}

    public BaseItem getItemByTempID(int id)
    {
        for (int i = 0; i < BagDict.Count; i++)
        {
            BaseItem item = BagDict.ElementAt(i).Value;
            if (item.templateID == id)
            {
                return item;
            }
        }
        return null;
    }
	public int getItemNumbyTempID(int templateID)
	{
		for(int i = 0; i < BagDict.Count; i++)
		{
//			Debug.Log("templateID " + BagDict.ElementAt(i).Value.templateID + " : "+ templateID);
			if(BagDict.ElementAt(i).Value.templateID == templateID)
			{
				return BagDict.ElementAt(i).Value.haveNum;
			}
		}
		return 0;
	}
	public int getNum()
	{
		return BagDict.Count;
	}
	public void setMaxNum(int num)
	{
		maxNum = num;
	}
	public int maxNum{ get;set; }
	/// <summary>
	/// 
	/// </summary>
	public bool IsDirty{ get; set;}
	/// <summary>
	/// 
	/// </summary>
	protected Dictionary<long, BaseItem> BagDict = new Dictionary<long, BaseItem>(); 
}
