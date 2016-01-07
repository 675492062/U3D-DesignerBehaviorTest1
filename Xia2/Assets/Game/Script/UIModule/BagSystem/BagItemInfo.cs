using UnityEngine;
using System.Collections;

public class BagItemInfo : MonoBehaviour {

	public UILabel label_guid;
	public UILabel label_templateID;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setGuid(long guid)
	{
		label_guid.text = "" + guid;
	}
	public void setTemplateID(int templateID)
	{
		label_templateID.text = "" + templateID;
	}
}
