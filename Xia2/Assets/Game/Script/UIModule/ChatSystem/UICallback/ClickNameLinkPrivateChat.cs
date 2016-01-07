using UnityEngine;
using System.Collections;

public class ClickNameLinkPrivateChat : MonoBehaviour {
	public int uid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
		manager.hideChatNameLinkWindow ();
		manager.hideShaderWindow ();
		manager.hideAll ();
		manager.showPrivateChatWindow ();
		ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
		chatManager.setTargetId (uid);
		chatManager.setCurrentChatChannel ((int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL);
	}
}
