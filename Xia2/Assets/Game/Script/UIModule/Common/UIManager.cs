using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UIManager : MonoBehaviour {
	public UIPanel Parent;
	public Transform []UIPrefabs;
	public float testTime = 1f;
	public float tempTestTime = 0f;
	Dictionary<string, Transform> dict = new Dictionary<string, Transform>();
	// Use this for initialization
	void Start () 
	{
		initPrefabs ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempTestTime += Time.deltaTime;
		if(tempTestTime >= testTime)
		{
			tempTestTime = 0f;
			int count = 0;
			for(int i = 0; i < dict.Count; i++)
			{
				if(!dict.ElementAt(i).Value.gameObject.activeSelf)
				{
					count++;
				}
			}
			if(count >= dict.Count)
			{
				MainMenuManager menu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));
				if(menu != null)
				{
					menu.showEffect();
				}
			}
			else 
			{
				MainMenuManager menu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));
				if(menu != null)
				{
					menu.hideEffect();
				}
			}
		}
	}
	public void initPrefabs()
	{
		for(int i = 0; i < UIPrefabs.Length; i++)
		{
			if(UIPrefabs[i] == null)
			{
				continue;
			}
			if(dict.ContainsKey(UIPrefabs[i].name))
			{
				continue;
			}

			Transform ui = Instantiate(UIPrefabs[i], Vector3.zero, Quaternion.identity) as Transform;
			ui.parent = Parent.transform;
			ui.transform.localPosition = Vector3.zero;
			ui.transform.localScale = Vector3.one;

			dict.Add(UIPrefabs[i].name, ui);
			ui.gameObject.SetActive(false);
		}
	}
	public void show(string prefabName)
	{
		if(dict.ContainsKey(prefabName))
		{
			dict[prefabName].gameObject.SetActive(true);
		}
		
		MainMenuManager menu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));
		if(menu != null)
		{
			menu.hideEffect();
		}
	}
	public void hide(string prefabName)
	{
		if(dict.ContainsKey(prefabName))
		{
			dict[prefabName].gameObject.SetActive(false);
		}

	}
	public void hideAll()
	{
		for (int i = 0; i < dict.Count; i++) 
		{
			dict.ElementAt(i).Value.gameObject.SetActive(false);
		}
	}
	public Transform getPanel (string prefabName)
	{
		if(dict.ContainsKey(prefabName))
		{
			return dict[prefabName];
		}
		return null;
	}
	public void debug()
	{
		for(int i = 0; i < UIPrefabs.Length; i++)
		{
			Debug.Log("name " + UIPrefabs[i].name);
		}
	}
	void OnApplicationPause(bool pocus)
	{
		Debug.Log ("OnApplicationPause " + pocus);
	}
	void OnApplicationFocus(bool focus)
	{
		Debug.Log ("OnApplicationFocus: " + focus);
	}
	void OnApplicationQuit()
	{
		Debug.Log ("OnApplicationQuit: "); 
	}
}
