using UnityEngine;
using System.Collections;

public class CreateItem : MonoBehaviour {

	public Transform parent;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void addItem(string text, string name, Transform parentUI)
	{
		GameObject instance = Instantiate(Resources.Load("Prefab/Item/Item", typeof(GameObject))) as GameObject;
		instance.gameObject.SetActive(true);
		instance.transform.parent = parentUI;
		instance.transform.localScale = Vector3.one;
		offset s = instance.GetComponent<offset>();
		s.label.text = text;
		s.sprite.name = name;	
	}
	void OnClick()
	{
		for (int i = 0; i < 4; i++) 
		{
			addItem("NGUI", "NGUI", parent);		
		}
	}
}
