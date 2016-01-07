using UnityEngine;
using System.Collections;

public class UIEquipmentList : MonoBehaviour {

	public UIEquipItem[] EquipList = new UIEquipItem[6]; 
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnEnable()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		refresh (data);
	}
	public void refresh(HeroData data)
	{
		if(data == null)
			return;
		for(int i = 1; i < (int)GlobalDef.EquipmentTpye.E_MAX; i++)
		{
			EquipmentItem item = data.equipmentList.getItemByType(i); 
			if(item != null)
			{
				EquipList[i-1].refresh(item);
			}
			else
			{
				EquipList[i-1].setEmpty();
			}
		}
	}
}
