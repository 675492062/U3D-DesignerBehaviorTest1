using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SendFriendSystemHander : MonoBehaviour{

    public void SendGetFriendCount(int type)
    {
        FriendMessage.MsgFriendCountReq msg = new FriendMessage.MsgFriendCountReq();
        msg.type = type;
     
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_COUNT, msg);
    }

    public void SendGetFriendList(int page, int type)
    {
        FriendMessage.MsgFriendListReq msg = new FriendMessage.MsgFriendListReq();
        msg.page = page;
        msg.type = type;
       
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_LIST, msg);
    }

    public void SendGetFriend(long uid)
    {
        FriendMessage.MsgFriendFindReq msg = new FriendMessage.MsgFriendFindReq();
        msg.uid = Convert.ToInt32(uid);
        
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_FIND, msg);
    }

    public void SendAddFriend(long uid)
    {
        FriendMessage.MsgFriendAddReq msg = new FriendMessage.MsgFriendAddReq();
        msg.uid = Convert.ToInt32(uid);
        
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_ADD, msg);
    }

    public void SendDeleteFriend(long uid)
    {
        FriendMessage.MsgFriendDeleteReq msg = new FriendMessage.MsgFriendDeleteReq();
        msg.uid = Convert.ToInt32(uid);
        
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_DELETE, msg);
    }
    public void SendAgreeOrDisagree(long uid, bool result)
    {
        FriendMessage.MsgFriendRequestReq msg = new FriendMessage.MsgFriendRequestReq();
        msg.uid = Convert.ToInt32(uid);
        msg.result = result;
        
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FriendMessage.FRIEND_MSG_ID.ID_C2S_FRIEND_REQUEST, msg);
    }
}
