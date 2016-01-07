using UnityEngine;
using System.Collections;

public class ClickWorldButtonCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        MonoInstancePool.getInstance<ChatManager>().chat_channel = (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL;
        var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        if (manager)
        {
            manager.hideAll();
            manager.showWorldChatWindow();
			ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
			bool haveNew = chatManager.getHaveNewWorldChat();
			if(haveNew){
				manager.refreshChat();
			}
        }
    }
}
