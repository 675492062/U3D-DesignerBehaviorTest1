using UnityEngine;
using System.Collections;

public class AddHeroTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendHeroCall(100001);
		MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendHeroCall(100002);
		MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendHeroCall(100003);
	}
}
