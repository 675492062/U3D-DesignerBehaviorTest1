using UnityEngine;
using System.Collections;

public class ClickDisagreeButton2Callback : MonoBehaviour {

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
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendAgreeOrDisagree(MonoInstancePool.getInstance<FriendManager>().currentFriend.fiendId, false);
        var friendMainUiManager = (FriendMainUIManager)FindObjectOfType<FriendMainUIManager>();
        if (friendMainUiManager)
        {
            friendMainUiManager.refreshInviteObject();
        }
        
        //MonoInstancePool.getInstance<FriendManager>().inviteObject.Remove(MonoInstancePool.getInstance<FriendManager>().currentGameObject);
        //Destroy(MonoInstancePool.getInstance<FriendManager>().currentGameObject);
       // for (int i = 0; i < MonoInstancePool.getInstance<FriendManager>().inviteObject.Count; i++)
       // {
        //    MonoInstancePool.getInstance<FriendManager>().inviteObject[i].transform.localPosition = new Vector3(-370, 90 - (i * 108), 0);
        //} 
    }
}
  