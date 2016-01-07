using UnityEngine;
using System.Collections;

public class ClickPrivateChatCallback : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnClick()
    {
        var firendMainUIManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        firendMainUIManager.hideFriendwindow();
        firendMainUIManager.hideFriendContentWindow();
        firendMainUIManager.showChatWindow();
        var chatUIManager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        chatUIManager.showPrivateChatWindow();
        chatUIManager.hideSystemChatWindow();
        chatUIManager.hideWorldChatWindow();
		ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
		chatManager.setCurrentChatChannel((int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL);
		chatManager.setTargetId (MonoInstancePool.getInstance<FriendManager>().currentFriend.fiendId);
    }
}
