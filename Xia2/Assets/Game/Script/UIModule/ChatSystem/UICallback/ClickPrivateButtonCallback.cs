using UnityEngine;
using System.Collections;

public class ClickPrivateButtonCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        MonoInstancePool.getInstance<ChatManager>().chat_channel = (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL;
        var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        if (manager)
        {
            manager.hideAll();
            manager.showPrivateChatWindow();
			ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
			bool haveNew = chatManager.getHaveNewPrivateChat();
			if(haveNew){
				manager.refreshChat();
			}
        }
    }
}
