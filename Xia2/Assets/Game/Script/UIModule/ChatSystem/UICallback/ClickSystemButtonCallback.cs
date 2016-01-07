using UnityEngine;
using System.Collections;

public class ClickSystemButtonCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        MonoInstancePool.getInstance<ChatManager>().chat_channel = (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL;
        var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        if (manager)
        {
            manager.hideAll();
            manager.showSystemChatWindow();
			ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
			bool haveNew = chatManager.getHaveNewSystemChat();
			if(haveNew){
				manager.refreshChat();
			}
        }
    }
}
