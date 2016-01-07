using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickInviteFriendCallback : MonoBehaviour {

    public UILabel Title;
    public UISprite Sprite;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        var friendMainUIManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        friendMainUIManager.FriendContentWindow.gameObject.SetActive(true);
        var manager = (FriendContentUIManager)FindObjectOfType<FriendContentUIManager>();
        manager.showAgreeButton();
        manager.showDisagreeButton();
        manager.hideAddButton();
        manager.hideDeleteButton();
        string friendName = Title.text;
        MonoInstancePool.getInstance<FriendManager>().setCurrentFriend(friendName);
        MonoInstancePool.getInstance<FriendManager>().currentGameObject = this.gameObject;
    }    
}
