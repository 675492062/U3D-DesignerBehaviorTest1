using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendModulMsg : MonoBehaviour{
	private static FriendModulMsg module;
	//获取Instance
	public static FriendModulMsg getInstance() {
		if (module == null) {
			//第一次调用的时候 创建单例对象 并进行初始化操作
			module = new FriendModulMsg();
		}
		return module;
	}
	public int parse(SocketModel module)
	{
        switch (module.messageID)
        {
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_COUNT:// 获取好友总数
                ongGetFriendCount(module);
                break;
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_LIST:// 获取好友列表
                onGetFriendList(module);
                break;
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_FIND:// 查找好友
                onSearchFriend(module);
                break;
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_ADD://  添加好友
                onAddFriend(module);
                break;
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_DELETE://  删除好友
                onDeleteFriend(module);
                break;
            case (int)FriendMessage.FRIEND_MSG_ID.ID_S2C_FRIEND_REQUEST://  好友申请
                onInviteMe(module);
                break;
		default:
			return -1;
        }
        return 0;
    }
    //获取好友总数
    public void ongGetFriendCount(SocketModel module)
    {
		FriendMessage.MsgFriendCountRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendCountRep>(module);

        int friendCount = msg.friendCount;
        MonoInstancePool.getInstance<FriendManager>().friendCount = friendCount;
    }

    //获取好友列表
    public void onGetFriendList(SocketModel module)
    {
		FriendMessage.MsgFriendListRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendListRep>(module);

        MonoInstancePool.getInstance<FriendManager>().friendList.Clear();
        MonoInstancePool.getInstance<FriendManager>().applyLsit.Clear();
        for (int i = 0; i < msg.FriendAry.Count; i++)
        {
            Friend friend = new Friend();
            friend.fiendId = msg.FriendAry[i].uid;
            friend.friendName = msg.FriendAry[i].name;
            friend.friendLevel = msg.FriendAry[i].level;
            friend.imageID = msg.FriendAry[i].headid;
            friend.vipLevel = msg.FriendAry[i].vip;
            if (msg.type == (int)GlobalDef.FriendType.FriendList)
            {
                MonoInstancePool.getInstance<FriendManager>().friendList.Add(friend);
            }
            else if (msg.type == (int)GlobalDef.FriendType.InviteList)
            {
                MonoInstancePool.getInstance<FriendManager>().applyLsit.Add(friend);
            }
        }
        if (msg.type == (int)GlobalDef.FriendType.FriendList)       //显示好友列表
        {
            MonoInstancePool.getInstance<FriendManager>().IsDirty = true;
        }
        else if (msg.type == (int)GlobalDef.FriendType.InviteList)  //显示邀请好友列表
        {
            MonoInstancePool.getInstance<FriendManager>().IsDirty = true;
        }
    }

    //查找好友
    public void onSearchFriend(SocketModel module)
    {
		FriendMessage.MsgFriendFindRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendFindRep>(module);

        bool isFriend = msg.friend;
        Friend friend = new Friend();
        friend.fiendId = msg.info.uid;
        friend.friendName = msg.info.name;
        friend.friendLevel = msg.info.level;
        friend.imageID = msg.info.headid;
        friend.vipLevel = msg.info.vip;
        MonoInstancePool.getInstance<FriendManager>().currentFriend = friend;
        SearchListUImanager friendUIManager = (SearchListUImanager)FindObjectOfType(typeof(SearchListUImanager));
        if (friendUIManager)
        {
			friendUIManager.showSearchFriend();
        }
        if (isFriend)
        {
			friendUIManager.showSearchedFriendWindow();
            friendUIManager.hideAddButtonWindow();
        }        
    }

    //添加好友
    public void onAddFriend(SocketModel module)
    {
		FriendMessage.MsgFriendAddRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendAddRep>(module);

        Friend friend = new Friend();
        friend.fiendId = msg.info.uid;
        friend.friendName = msg.info.name;
        friend.friendLevel = msg.info.level;
        friend.imageID = msg.info.headid;
        friend.vipLevel = msg.info.vip;
        MonoInstancePool.getInstance<FriendManager>().addFriend = friend;
        bool type = msg.type;
        MonoInstancePool.getInstance<FriendManager>().addType = type;
    }

    //删除好友
    public void onDeleteFriend(SocketModel module)
    {
		FriendMessage.MsgFriendDeleteRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendDeleteRep>(module);

        int uid = msg.uid;
        MonoInstancePool.getInstance<FriendManager>().deleteUId = uid;
        MonoInstancePool.getInstance<FriendManager>().isDelete = true;
    }

    public void onInviteMe(SocketModel module)
    {
		FriendMessage.MsgFriendRequestRep msg = MsgSerializer.Deserialize<FriendMessage.MsgFriendRequestRep>(module);

        bool change = false;
        if (msg.info.uid == MonoInstancePool.getInstance<FriendManager>().currentSearchId)
        {
            change = true;
        }
        Friend friend = new Friend();
        friend.fiendId = msg.info.uid;
        friend.friendName = msg.info.name;
        friend.friendLevel = msg.info.level;
        friend.imageID = msg.info.headid;
        friend.vipLevel = msg.info.vip;
        MonoInstancePool.getInstance<FriendManager>().applyLsit.Add(friend);
        var searchUIManager = (SearchListUImanager)FindObjectOfType<SearchListUImanager>();
        if (searchUIManager
            && searchUIManager.SearchedFriend.gameObject.activeSelf
            && change)
        {
            //显示同意和拒绝按钮
            //friendUIManager.hideAddButton();
            searchUIManager.showAgreeAndDisagree();
        }
    }
}
