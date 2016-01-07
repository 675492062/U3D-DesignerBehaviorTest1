using UnityEngine;
using System.Collections;

public class uClickCloseBttonCallabck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var manager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        manager.hideChatWindow();
        
    }
}
