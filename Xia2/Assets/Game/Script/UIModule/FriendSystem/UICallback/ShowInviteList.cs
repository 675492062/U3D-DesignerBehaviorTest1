using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowInviteList : MonoBehaviour {
    public UILabel FriendCount;
    public GameObject InviteListWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (InviteListWindow != null)
        {
            InviteListWindow.gameObject.SetActive(true);
        }
        var manager = (InviteListUIManager)FindObjectOfType<InviteListUIManager>();
        manager.hideFriendListWindow();
        manager.hideSearchListWindow();
        //发送请求申请列表请求
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendList(MonoInstancePool.getInstance<FriendManager>().currentPage, (int)GlobalDef.FriendType.InviteList);
        //获取申请好友总数
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendGetFriendCount((int)GlobalDef.FriendType.InviteList);
        manager.hideNewFriendCountWindow();
        manager.hideNewInviteReminder();
        manager.refreshFriendCount();

    }
}
