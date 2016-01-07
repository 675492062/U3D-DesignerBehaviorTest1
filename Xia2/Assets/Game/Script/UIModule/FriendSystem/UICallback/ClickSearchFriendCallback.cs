using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickSearchFriendCallback : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var friendMainUIManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        friendMainUIManager.FriendContentWindow.gameObject.SetActive(true);
        var manager = (FriendContentUIManager)FindObjectOfType<FriendContentUIManager>();
        bool isFriend = MonoInstancePool.getInstance<FriendManager>().checkFriend(MonoInstancePool.getInstance<FriendManager>().currentFriend);
        if (isFriend)
        {
            manager.hideAddButton();
            manager.showDeleteButton();
        }
        else
        {
            manager.showAddButton();
            manager.hideDeleteButton();
        } 
        manager.hideAgreeButton();
        manager.hideDisagreeButton();
    }
}
