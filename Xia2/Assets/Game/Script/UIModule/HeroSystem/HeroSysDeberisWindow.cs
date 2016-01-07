using UnityEngine;
using System.Collections;

public class HeroSysDeberisWindow : MonoBehaviour {

	public HeroItemProperty pro;
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
		if(null == data)
			return;
		pro.refreshInfo (data);
	}
}
