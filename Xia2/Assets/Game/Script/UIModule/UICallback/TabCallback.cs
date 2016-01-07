using UnityEngine;
using System.Collections;

public class TabCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        MonoInstancePool.getInstance<ChatManager>().chat_channel = (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL;
    }
}
