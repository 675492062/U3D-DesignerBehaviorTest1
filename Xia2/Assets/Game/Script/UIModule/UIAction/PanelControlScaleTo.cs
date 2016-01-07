using UnityEngine;
using System.Collections;

public class PanelControlScaleTo : MonoBehaviour {

	public UIPanel panel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if (panel.gameObject.activeSelf) 
		{
			panel.gameObject.SetActive(false);
		}
		else 
		{
			panel.gameObject.SetActive(true);

			ScaleTo action = panel.GetComponentInChildren<ScaleTo>();
			if(action)
			{
				action.setScale(0.5f);
				action.runAction();
			}
		}
	}
}
