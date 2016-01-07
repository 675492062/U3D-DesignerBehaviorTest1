using UnityEngine;
using System.Collections;

public class ClickSharderCallback : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        if (manager)
        {
            manager.hideChatNameLinkWindow();
			manager.hideChatItemLinkWindow();
            manager.hideShaderWindow();
        }
    }
}
