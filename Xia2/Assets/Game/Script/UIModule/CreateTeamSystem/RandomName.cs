using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomName : MonoBehaviour {
	
	string[] NameLib = new string[]{"夏侯惇", "夏侯淳", "曹操", "关羽", "大象", "刘皇叔"};

	public UIInput m_name;

	// Use this for initialization
	void Start ()
	{
		m_name.value = GetRandomName();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnClick()
	{
		m_name.value = GetRandomName();
	}

	public string GetRandomName()
	{
		int index = Random.Range(0, NameLib.Length);
		return NameLib[index];
	}
}
