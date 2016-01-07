﻿using UnityEngine;
using System.Collections;

public class ClickSelectTeamNameCallback : MonoBehaviour {
    public UIInput TeamName;
    public GameObject TeamNameWindow;
    public GameObject TeamHeadWindow;
    public GameObject offset;
    public int count = 4;

    public string[] spritName = new string[] { "NGUI", "NGUI", "NGUI", "NGUI" };

    public int[] texts = new int[] { 1, 2, 3, 4 };
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (TeamName)
        {
            MonoInstancePool.getInstance<UserData>().teamName = TeamName.value;
        }
        if (TeamNameWindow.gameObject.activeSelf)
        {
            TeamNameWindow.gameObject.SetActive(false);
        }
        if (!TeamHeadWindow.gameObject.activeSelf)
        {
            TeamHeadWindow.gameObject.SetActive(true);
        }

        //根据配表加载战队头像
        for (int i = 0; i < 4; i++)
        {
            Load(i, spritName[i]);
        }
        //重新排列
        UIGrid grid = (UIGrid)offset.GetComponentInChildren<UIGrid>();
        grid.repositionNow = true;
    }
    void Load(int text, string spritName)
    {
		GameObject instance = Instantiate(Resources.Load("Prefab/LoginSystem/TeamImage", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = offset.transform;
        instance.transform.localScale = Vector3.one;
        Vector3 pos = instance.transform.position;
        pos.y -= 100;
        instance.transform.position = pos;

        offset s = instance.GetComponent<offset>();
        s.label.text = text.ToString();
        s.sprite.name = spritName;
        MonoInstancePool.getInstance<UserData>().TeamImageObject.Add(instance);
    }
}
