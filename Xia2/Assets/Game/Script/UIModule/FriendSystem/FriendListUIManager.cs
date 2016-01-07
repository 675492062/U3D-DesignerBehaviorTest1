using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FriendListUIManager : MonoBehaviour {
    public UIPanel SubPanel;
    public GameObject FriendListWindow;
    public GameObject SearchListWindow;
    public GameObject InviteListWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MonoInstancePool.getInstance<FriendManager>().IsDirty)
        {
            MonoInstancePool.getInstance<FriendManager>().IsDirty = false;
            RefreshFriendList();
        }
	}

    void RefreshFriendList()
    {
        for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().friendObjectDic.Count; i++)
        {
            GameObject go = MonoInstancePool.getInstance<FriendManager>().friendObjectDic.ElementAt(i).Value;
            Destroy(go);
        }
        MonoInstancePool.getInstance<FriendManager>().friendObjectDic.Clear();

        int index = 0;//计算位置的索引
        foreach (Friend friend2 in MonoInstancePool.getInstance<FriendManager>().friendList)
        {
            LoadFriendList(friend2.fiendId, friend2.friendName, index, "NGUI", friend2.friendLevel, friend2.vipLevel);
            index++;
        }
    }

    void LoadFriendList(long uid, string title, int index, string spritName, int level, int VipLevel)
    {
        GameObject instance = Instantiate(Resources.Load("Prefab/FriendSystem/Friend", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = SubPanel.gameObject.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(-200, -(instance.transform.position.y + (index * 108)) + 140, 0);
        ClickFriendCallback s = instance.GetComponent<ClickFriendCallback>();
        s.Sprite.name = spritName;
        s.Title.text = title;
        s.Level.text = level.ToString();
        s.VipLevel.text = VipLevel.ToString();
        MonoInstancePool.getInstance<FriendManager>().friendObjectDic.Add(uid, instance);
        //MonoInstancePool.getInstance<FriendManager>().friendObject.Add(instance);
    }

    public void showFriendListWindow()
    {
        if (FriendListWindow != null)
        {
            FriendListWindow.gameObject.SetActive(true);
        }
    }

    public void hideFriendListWindow()
    {
        if (FriendListWindow != null)
        {
            FriendListWindow.gameObject.SetActive(false);
        }
    }

    public void showSearchListWindowWindow()
    {
        if (SearchListWindow != null)
        {
            SearchListWindow.gameObject.SetActive(true);
        }
    }

    public void hideSearchListWindowWindow()
    {
        if (SearchListWindow != null)
        {
            SearchListWindow.gameObject.SetActive(false);
        }
    }

    public void showInviteListWindowWindow()
    {
        if (InviteListWindow != null)
        {
            InviteListWindow.gameObject.SetActive(true);
        }
    }

    public void hideInviteListWindowWindow()
    {
        if (InviteListWindow != null)
        {
            InviteListWindow.gameObject.SetActive(false);
        }
    }
}
