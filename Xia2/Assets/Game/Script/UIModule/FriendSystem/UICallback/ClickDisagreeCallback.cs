using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickDisagreeCallback : MonoBehaviour {
    public UILabel Title;
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
        string friendName = Title.text;
        long uid = 0;
        Friend f = new Friend();
        List<Friend> applyLsit = MonoInstancePool.getInstance<FriendManager>().applyLsit;
        foreach (Friend friend in applyLsit)
        {
            if (friend.friendName == friendName)
            {
                uid = friend.fiendId;
                f = friend;
            }
        }
        MonoInstancePool.getInstance<FriendManager>().applyLsit.Remove(f);
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendAgreeOrDisagree(uid, false);
		var inviteListUIManager = (InviteListUIManager)FindObjectOfType<InviteListUIManager> ();
		inviteListUIManager.deleteInviteFriendObject (uid);
        //MonoInstancePool.getInstance<FriendManager>().inviteObject.Remove(transform.parent.gameObject);
        //Destroy(transform.parent.gameObject);
    }
}
