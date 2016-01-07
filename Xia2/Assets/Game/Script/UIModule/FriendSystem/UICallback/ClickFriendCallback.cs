using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickFriendCallback : MonoBehaviour {
    public UILabel Title;
    public UISprite Sprite;
    public UILabel Level;
    public UILabel VipLevel;
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
        manager.showDeleteButton();
        manager.hideAddButton();
        manager.hideAgreeButton();
        manager.hideDisagreeButton();
        string friendName = Title.text;
        MonoInstancePool.getInstance<FriendManager>().setCurrentFriend2(friendName);
        MonoInstancePool.getInstance<FriendManager>().currentGameObject = this.gameObject;
    }    
}
