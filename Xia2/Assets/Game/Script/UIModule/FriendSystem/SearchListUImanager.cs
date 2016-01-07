using UnityEngine;
using System.Collections;

public class SearchListUImanager : MonoBehaviour {
    public GameObject FriendListWindow;
    public GameObject SearchListWindow;
    public GameObject InviteListWindow;
    public GameObject SearchedFriend;
    public UIButton AddButton;
    public UILabel MyUIDLabel;
    public UIButton AgreeButton;
    public UIButton DisagreeButton;
    public UILabel SearchFriendName;
    public UISprite SearchFriendHead;
    public UILabel Level;
    public UILabel VIPLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showAgreeAndDisagree()
    {
        if (!AgreeButton.gameObject.activeSelf)
        {
            AgreeButton.gameObject.SetActive(true);
        }
        if (!DisagreeButton.gameObject.activeSelf)
        {
            DisagreeButton.gameObject.SetActive(true);
        }
    }

    //显示搜索到的好友
    public void showSearchFriend()
    {
		this.showSearchedFriendWindow();
		this.showAddButtonWindow();
        SearchFriendName.text = MonoInstancePool.getInstance<FriendManager>().currentFriend.friendName;
        //TODO 此处应现根据imageId找到对应的图片，再把图片做参数付给SearchFriendHead
        SearchFriendHead.name = MonoInstancePool.getInstance<FriendManager>().currentFriend.imageID.ToString();
        Level.text = MonoInstancePool.getInstance<FriendManager>().currentFriend.friendLevel.ToString();
        VIPLevel.text = MonoInstancePool.getInstance<FriendManager>().currentFriend.vipLevel.ToString();
    }

    public void setMyUID()
    {
        MyUIDLabel.text = "ID:" + MonoInstancePool.getInstance<UserData>().guid.ToString();
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

    public void showSearchedFriendWindow()
    {
        if (SearchedFriend != null)
        {
            SearchedFriend.gameObject.SetActive(true);
        }
    }

    public void hideSearchedFriendWindow()
    {
        if (SearchedFriend != null)
        {
            SearchedFriend.gameObject.SetActive(false);
        }
    }

    public void showAddButtonWindow()
    {
        if (AddButton != null)
        {
            AddButton.gameObject.SetActive(true);
        }
    }

    public void hideAddButtonWindow()
    {
        if (AddButton != null)
        {
            AddButton.gameObject.SetActive(false);
        }
    }

    public void showAgreeButtonWindow()
    {
        if (AgreeButton != null)
        {
            AgreeButton.gameObject.SetActive(true);
        }
    }

    public void hideAgreeButtonWindow()
    {
        if (AgreeButton != null)
        {
            AgreeButton.gameObject.SetActive(false);
        }
    }

    public void showDisagreeButtonWindow()
    {
        if (DisagreeButton != null)
        {
            DisagreeButton.gameObject.SetActive(true);
        }
    }

    public void hideDisagreeButtonWindow()
    {
        if (DisagreeButton != null)
        {
            DisagreeButton.gameObject.SetActive(false);
        }
    }
}
