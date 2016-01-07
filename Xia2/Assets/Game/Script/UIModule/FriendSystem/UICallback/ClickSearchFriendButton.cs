using UnityEngine;
using System.Collections;
using System;

public class ClickSearchFriendButton : MonoBehaviour {
    public UILabel UISearchName;
    public UILabel FriendName;
    public UISprite Sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var manager = (SearchListUImanager)FindObjectOfType<SearchListUImanager>();
        if (UISearchName.text != "")
        {
			MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriend((Convert.ToInt32(UISearchName.text)));
            MonoInstancePool.getInstance<FriendManager>().currentSearchId = Convert.ToInt32(UISearchName.text);
            //manager.showSearchedFriendWindow();
            //manager.showAddButtonWindow();
        }
        UISearchName.text = "";
        manager.hideAgreeButtonWindow();
        manager.hideDisagreeButtonWindow();
    }
}
