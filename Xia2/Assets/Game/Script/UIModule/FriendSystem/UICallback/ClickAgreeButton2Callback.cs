using UnityEngine;
using System.Collections;

public class ClickAgreeButton2Callback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        var friendContentUIManager = (FriendContentUIManager)FindObjectOfType<FriendContentUIManager>();
        if (friendContentUIManager) 
        {
            friendContentUIManager.hideFriendContentWindow();
        }
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendAgreeOrDisagree(MonoInstancePool.getInstance<FriendManager>().currentFriend.fiendId, true);

        var friendMainUiManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        if (friendMainUiManager)
        {
            friendMainUiManager.refreshInviteObject();
        }
    }
}
