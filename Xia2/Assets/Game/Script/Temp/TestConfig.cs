using UnityEngine;
using System.Collections;

public class TestConfig : MonoBehaviour {
	public UIPanel panel;
	// Use this for initialization
	void Start () 
	{
//		StaticEquipment.Instance ().refreshData ();
//		StaticEquipment.Instance ().print();
//		UILabel label = GetComponentInChildren<UILabel> ();
//		label.text = StaticEquipment.Instance ().getStr (400002,"name");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick()
	{
		StroyPlay s = transform.parent.GetComponentInChildren<StroyPlay>();
		if(s != null)
		{
			s.next();
		}
	}
}
