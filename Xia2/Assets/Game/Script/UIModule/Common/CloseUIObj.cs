using UnityEngine;
using System.Collections;

public class CloseUIObj : MonoBehaviour {
	public UIWidget widget;
	void OnClick()
	{
		if(widget != null)
		{
			widget.gameObject.SetActive(false);
		}
	}
}
