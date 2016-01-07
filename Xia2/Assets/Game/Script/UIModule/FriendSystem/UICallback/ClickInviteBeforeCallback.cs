using UnityEngine;
using System.Collections;

public class ClickInviteBeforeCallback : MonoBehaviour {
    public UILabel FriendCount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (MonoInstancePool.getInstance<FriendManager>().currentPage + 1 <= MonoInstancePool.getInstance<FriendManager>().friendCount)
        {
            MonoInstancePool.getInstance<FriendManager>().setCurrentPage(MonoInstancePool.getInstance<FriendManager>().currentPage + 1);
			MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendCount((int)GlobalDef.FriendType.InviteList);
			MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendList(MonoInstancePool.getInstance<FriendManager>().currentPage, (int)GlobalDef.FriendType.InviteList);
            var manager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
            manager.refreshFriendCount();
        }
    }
}
