using UnityEngine;
using System.Collections;

public class HeroModelInfo : MonoBehaviour {
	public GameObject [] Models;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void hideAll()
	{
		for(int i = 0; i < Models.Length; i++)
		{
			Models[i].gameObject.SetActive(false);
		}
	}
	public void showModelByIdx(int idx)
	{
		if(idx < 0 || idx >= Models.Length)
		{
			return;
		}
		hideAll();
		Models[idx].transform.gameObject.SetActive(true);
	}
}
