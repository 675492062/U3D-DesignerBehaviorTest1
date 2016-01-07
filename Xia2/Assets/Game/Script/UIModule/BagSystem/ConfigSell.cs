using UnityEngine;
using System.Collections;

public class ConfigSell : MonoBehaviour {

	public UIPanel info;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if(info!=null)
		{
			info.gameObject.SetActive(true);
			ScaleTo action = info.GetComponentInChildren<ScaleTo>();
			if(action)
			{
				action.setScale(0.5f);

				action.runAction();
			}
		}
	}
}
