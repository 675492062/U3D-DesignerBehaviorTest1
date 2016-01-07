using UnityEngine;
using System.Collections;

public class HeadItemInfo : MonoBehaviour {

	public UISprite[] Star;
	public UILabel    Level;
	public UISprite   HeadIcon;

	public long guid{get; set;}
	private int  index;
	public int headIndex
	{
		get
		{
			return index;
		}
		set
		{
			index = value;
		}
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void OnClick()
	{
		Debug.Log("click " + index);
		MonoInstancePool.getInstance<HeroManager>().curSelectHero = index;
		MonoInstancePool.getInstance<HeroManager>().getCurShowHero().equipmentList.isDirty = true;
		
		BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
		if(manager != null)
		{
			manager.refreshAllData();
		}

		HeadItemManager head = (HeadItemManager)FindObjectOfType(typeof(HeadItemManager));
		if(head != null)
		{
			head.refreshSelectBorder();
		}
	}
	public void setStar(int star)
	{
		for(int i = 0; i < 5; i++)
		{
			if(i < star)
			{
				Star[i].spriteName = "hb_22";
			}
			else 
			{
				Star[i].spriteName = "hb_23";
			}
		}
	}
	public void setLevel(int lv)
	{
		Level.text = "Lv" + lv;
	}
}
