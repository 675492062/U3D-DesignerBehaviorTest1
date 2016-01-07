using UnityEngine;
using System.Collections;
using System.Linq;

public class InviteListUIManager : MonoBehaviour {
    public GameObject FriendListWindow;
    public GameObject SearchListWindow;
    public GameObject InviteListWindow;
    public GameObject NewFriendCountWindow;
    public GameObject NewInviteReminder;
    public UILabel FriendCount;
    public GameObject InviteTable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MonoInstancePool.getInstance<FriendManager>().IsDirty)
        {
            MonoInstancePool.getInstance<FriendManager>().IsDirty = false;
            RefreshInviteList();
        }
	}

    void RefreshInviteList()
    {
        for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Count; i++)
        {
            GameObject go = MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.ElementAt(i).Value;
            Destroy(go);
        }
        MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Clear();
        int index = 0;
        foreach (Friend friend in MonoInstancePool.getInstance<FriendManager>().applyLsit)
        {
            LoadInviteList(friend.fiendId,friend.friendName, index, "NGUI");
            index++;
        }
    }

	/**  加载邀请好友对象 */
    void LoadInviteList(long uid, string title, int index, string spritName)
    {
		GameObject instance = Instantiate(Resources.Load("Prefab/FriendSystem/ApplyFriend", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = InviteTable.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(-370, 90 - (index * 108), 0);
        ClickInviteFriendCallback s = instance.GetComponent<ClickInviteFriendCallback>();
        s.Sprite.name = spritName;
        s.Title.text = title;
        MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Add(uid, instance);
    }

	/**  更新页数 */
    public void refreshFriendCount()
    {
        FriendCount.text = MonoInstancePool.getInstance<FriendManager>().currentPage + "/" + MonoInstancePool.getInstance<FriendManager>().friendCount;
    }

	public void deleteInviteFriendObject(long uid){
		GameObject delObject = MonoInstancePool.getInstance<FriendManager>().inviteObjectDic[uid];
		Destroy (delObject);
		MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Remove (uid);
		for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.Count; i++)
		{
			GameObject go = MonoInstancePool.getInstance<FriendManager>().inviteObjectDic.ElementAt(i).Value;
			go.transform.localPosition = new Vector3(-370, 90 - (i * 108), 0);
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

    public void showNewFriendCountWindow()
    {
        if (NewFriendCountWindow != null)
        {
            NewFriendCountWindow.gameObject.SetActive(true);
        }
    }

    public void hideNewFriendCountWindow()
    {
        if (NewFriendCountWindow != null)
        {
            NewFriendCountWindow.gameObject.SetActive(false);
        }
    }

    public void showNewInviteReminder()
    {
        if (NewInviteReminder != null)
        {
            NewInviteReminder.gameObject.SetActive(true);
        }
    }

    public void hideNewInviteReminder()
    {
        if (NewInviteReminder != null)
        {
            NewInviteReminder.gameObject.SetActive(false);
        }
    }
}
