using UnityEngine;
using System.Collections;

public class Model_show_hide : MonoBehaviour {
	int idx = 0;
	public GameObject hero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		hero.GetComponentInChildren<HeroModelInfo>().showModelByIdx(idx);
		idx++;
	}
}
