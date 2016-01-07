using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class FriendMainUIManager : MonoBehaviour {
    public GameObject FriendListButton;         //好友列表按钮
    public GameObject SerachFriendButton;       //搜素好友按钮
    public GameObject InviteFriendButton;       //邀请好友按钮
    public GameObject FriendListWindow;
    public GameObject SearchListWindow;
    public GameObject InviteListWindow;
    public UILabel FriendCount;
    public UIPanel FriendContentWindow;
    public GameObject ChatWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MonoInstancePool.getInstance<FriendManager>().isDelete)
        {
            MonoInstancePool.getInstance<FriendManager>().isDelete = false;
            deleteFirend();
        }
	}

    public void refreshInviteObject()
    {
		FriendManager manager = MonoInstancePool.getInstance<FriendManager>();
		Friend currentFriend = manager.getCurrentFriend ();
		GameObject inviteObject = manager.getDeleteInviteObject (currentFriend.fiendId);
		Destroy (inviteObject);
		manager.deleteInviteObject (currentFriend.fiendId);
        //MonoInstancePool.getInstance<FriendManager>().inviteObject.Remove(MonoInstancePool.getInstance<FriendManager>().currentGameObject);
       // Destroy(MonoInstancePool.getInstance<FriendManager>().currentGameObject);
		for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Count; i++)
		{
			GameObject go = MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.ElementAt(i).Value;
			go.transform.localPosition = new Vector3(-370, 90 - (i * 108), 0);
		}
        //for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().inviteObject.Count; i++)
        //{
        //    MonoInstancePool.getInstance<FriendManager>().inviteObject[i].transform.localPosition = new Vector3(-370, 90 - (i * 108), 0);
        //}
    }

    void deleteFirend()
    {
        long uid = MonoInstancePool.getInstance<FriendManager>().deleteUId;
        Friend friend = null;
        foreach (Friend f in MonoInstancePool.getInstance<FriendManager>().friendList)
        {
            if (f.fiendId == uid)
            {
                friend = f;
            }
        }
        MonoInstancePool.getInstance<FriendManager>().friendList.Remove(friend);
        if (MonoInstancePool.getInstance<FriendManager>().friendObjectDic.ContainsKey(uid))
        {
            Destroy( MonoInstancePool.getInstance<FriendManager>().friendObjectDic[uid]);
            MonoInstancePool.getInstance<FriendManager>().friendObjectDic.Remove(uid);
        }

        for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().friendObjectDic.Count; i++)
        {
            GameObject go = MonoInstancePool.getInstance<FriendManager>().friendObjectDic.ElementAt(i).Value;
            go.transform.localPosition = new Vector3(-200, -(go.transform.position.y + (i * 108)) + 140, 0);
        }
    }

    public void showChatWindow()
    {
        if(ChatWindow != null)
        {
            ChatWindow.gameObject.SetActive(true);
        }
    }

    public void hideFriendwindow() 
    {
        this.gameObject.SetActive(false);
    }

    public void hideFriendContentWindow()
    {
        if (FriendContentWindow != null)
        {
            FriendContentWindow.gameObject.SetActive(false);
        }
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

    public void showSearchListWindow()
    {
        if (SearchListWindow != null)
        {
            SearchListWindow.gameObject.SetActive(true);
        }
    }

    public void hideSearchListWindow()
    {
        if (SearchListWindow != null)
        {
            SearchListWindow.gameObject.SetActive(false);
        }
    }

    public void showInviteListWindow()
    {
        if (InviteListWindow != null)
        {
            InviteListWindow.gameObject.SetActive(true);
        }
    }

    public void hideInviteListWindow()
    {
        if (InviteListWindow != null)
        {
            InviteListWindow.gameObject.SetActive(false);
        }
    }

    //清除好友显示对象
    public void ClearFriendInstance()
    {
        foreach (KeyValuePair<long, GameObject> friendObject in MonoInstancePool.getInstance<FriendManager>().friendObjectDic)
        {
            Destroy(friendObject.Value);
        }
    }

    public void refreshFriendCount()
    {
        FriendCount.text = MonoInstancePool.getInstance<FriendManager>().currentPage + "/" + MonoInstancePool.getInstance<FriendManager>().friendCount;
    }
}
