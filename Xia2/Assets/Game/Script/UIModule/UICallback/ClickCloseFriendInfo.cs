using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickCloseFriendInfo : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        var manager = (FriendContentUIManager)FindObjectOfType<FriendContentUIManager>();
        if (manager) 
        {
            manager.hideFriendContentWindow();
        }
        
        //if (MonoInstancePool.getInstance<FriendManager>().FriendInfoWindow.gameObject.activeSelf)
        //{
        //    MonoInstancePool.getInstance<FriendManager>().FriendInfoWindow.gameObject.SetActive(false);
        //} 
    }
}
