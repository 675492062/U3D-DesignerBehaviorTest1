using UnityEngine;
using System.Collections;

public class HeroSysFilter : MonoBehaviour {

	public int filterType = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnClick()
	{
		HeroListWindowManager manager = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
		if(manager == null)
		{
			return;
		}
		manager.filter(filterType);
	}
}
