using UnityEngine;
using System.Collections;

public class UIMedicineItem : MonoBehaviour {

	public UILabel  AddNum;
	public UILabel  Name;
//	public UILabel  Count;
	public UISprite Icon;

	public int templateID;
	public int count{ get; set;}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
//	void OnEnable()
//	{
//		refreshData ();
//	}
	public void refreshData()
	{
		count = MonoInstancePool.getInstance<BagManager> ().getPotionBag ().getItemNumbyTempID (templateID);
		Name.text = StaticPotion.Instance ().getStr(templateID, "name") + "    ("+count+")";
		Icon.spriteName = StaticPotion.Instance ().getStr(templateID, "icon");
		AddNum.text = "" + StaticPotion.Instance ().getInt (templateID, "attribute1");
//		if(count <= 0)
//		{
//			Count.gameObject.SetActive(false);
//			Icon.spriteName = StaticPotion.Instance ().getStr(templateID, "icon_gray");
//		}
//		else 
//		{
//			Count.text = "" + count;
//			Count.gameObject.SetActive(true);
//			Icon.spriteName = StaticPotion.Instance ().getStr(templateID, "icon");
//		}
	}
	public int getAddNum()
	{
		return StaticPotion.Instance ().getInt (templateID, "attribute1");
	}
	public void subItemNum()
	{
		count--;
		Name.text = StaticPotion.Instance ().getStr(templateID, "name") + "    ("+count+")";
//		if(Count.gameObject.activeSelf)
//		{
//			count--;
//			Count.text = "" + count;
//		}
	}
	public bool isEmpty()
	{
		return true ? count > 0 : false;
	}
	void OnClick()
	{

	}
}
