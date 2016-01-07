using UnityEngine;
using System.Collections;

public class Tab3CallBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        MonoInstancePool.getInstance<ChatManager>().chat_channel = (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL;
    }
}
