using UnityEngine;
using System.Collections;

public class ClickDeleteFriendCallback : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        var friendContentUIManager = (FriendContentUIManager)FindObjectOfType<FriendContentUIManager>();
        if (friendContentUIManager)
        {
            friendContentUIManager.hideFriendContentWindow();
        } 
        //调用删除接口
		MonoInstancePool.getInstance<SendFriendSystemHander>().SendDeleteFriend(MonoInstancePool.getInstance<FriendManager>().currentFriend.fiendId);
    }
}