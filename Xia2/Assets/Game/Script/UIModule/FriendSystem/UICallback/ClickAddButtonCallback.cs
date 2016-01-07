using UnityEngine;
using System.Collections;

public class ClickAddButtonCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        //添加好友
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendAddFriend(MonoInstancePool.getInstance<FriendManager>().currentFriend.fiendId);
        MonoInstancePool.getInstance<FriendManager>().currentFriend = null;
        var friendMainUIManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        friendMainUIManager.hideFriendContentWindow();
        var searchListUIManager = (SearchListUImanager)FindObjectOfType<SearchListUImanager>();
        searchListUIManager.hideSearchedFriendWindow();
        searchListUIManager.hideAddButtonWindow();
    }
}
