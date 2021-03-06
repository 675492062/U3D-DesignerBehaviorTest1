using UnityEngine;
using System.Collections;

public class HeroSysAddExpWindow : MonoBehaviour {

	public UISprite backGround;

	public UIMedicineItem  []expItem = new UIMedicineItem[5];

	int width;

	// Use this for initialization
	void Start () 
	{
		width = backGround.width;
	}
	public void init()
	{

	}
	// Update is called once per frame
	void Update () 
	{

	}
	public void hideExpWindow()
	{
		HeroListWindowManager manager = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
		if(manager != null)
		{
			manager.hideBlackBack();
		}
		this.gameObject.SetActive (false);
	}

	public void refreshExpItems()
	{
		for(int i = 0; i < expItem.Length; i++)
		{
			expItem[i].refreshData();
		}
	}

}
