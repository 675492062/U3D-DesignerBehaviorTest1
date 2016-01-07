using UnityEngine;
using System.Collections;

public class TrunHero : MonoBehaviour {
	public GameObject HeroModel;
	public int turnSpeed;
	bool start = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(start)
		{
			Vector3 angel = HeroModel.transform.eulerAngles;
			angel.y += turnSpeed;
			HeroModel.transform.eulerAngles = angel;
		}
	}
	void OnClick()
	{
		start = true;
	}
	void OnRelease()
	{
		start = false;
	}
}
