using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickFriendListCallback : MonoBehaviour {
    //public UILabel FriendCount;
    //public GameObject FriendListWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        var manager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        manager.showFriendListWindow();
        manager.hideSearchListWindow();
        manager.hideInviteListWindow();
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendCount((int)GlobalDef.FriendType.FriendList);
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendList(MonoInstancePool.getInstance<FriendManager>().currentPage, (int)GlobalDef.FriendType.FriendList);
        manager.refreshFriendCount();
     }
}
