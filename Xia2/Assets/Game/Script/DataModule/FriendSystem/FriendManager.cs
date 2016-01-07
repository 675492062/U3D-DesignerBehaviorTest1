using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
* 好友属性
*/
public class Friend
{
    public Friend() { }
    public int fiendId = 0;
	public int imageID = 0;
	public string friendName = "";
	public int friendLevel = 0;
    public int vipLevel = 0;
}

public class FriendManager : MonoBehaviour
{
	/**  用于判断好友列表是否有更新 */
    public bool IsDirty { get; set; }
	/**  删除的好友的UID*/
    public int deleteUId = 0;
	/**  用于判断是否有好友删除 */
    public bool isDelete { get; set; }
	/**  删除的好友对象 */
    public Friend deleteFriend = null;
	/**  用于保存好友对象 */
    public List<Friend> friendList = new List<Friend>();
	/**  当前选中的好友对象 */
    public Friend currentFriend = null;
	/**  当前选中的好友的显示对象 */
    public GameObject currentGameObject; 
	/**  用于保存好友申请列表 */
    public List<Friend> applyLsit = new List<Friend>();
	/**  好友总页数 */
    public int friendCount = 0;
	/**  添加或者同意的好友 */
    public Friend addFriend = null; 
	/**  添加成功类型 true 自己同意 false 别人同意 */
    public bool addType = false;       
	/**  当前页 */
    public int currentPage = 1;
	/**  当前搜索的的好友的UID */
    public int currentSearchId = 0;
	/**  用于保存生成的好友显示对象 */
    public Dictionary<long, GameObject> friendObjectDic = new Dictionary<long, GameObject>();
	/**  用于保存生成的申请好友显示对象 */
    public Dictionary<long, GameObject> inviteObjectDic = new Dictionary<long, GameObject>();

	public Dictionary<long, GameObject> getInviteObjectDic(){
		return this.inviteObjectDic;
	}

	public void deleteInviteObject(long uid){
		this.inviteObjectDic.Remove (uid);
	}

	public Friend getCurrentFriend(){
		return this.currentFriend;
	}

	public GameObject getDeleteInviteObject(long uid){
		return this.inviteObjectDic [uid];
	}

    //设置当前操作的好友(针对邀请列表内的好友)
    public void setCurrentFriend(string name)
    {
        foreach (Friend friend in applyLsit)
        {
            if (friend.friendName == name)
            {
                this.currentFriend = friend;
            }
        }
    }

	//设置当前操作的好友（针对好友列表内的好友）
	public void setCurrentFriend2(string name){
		foreach (Friend friend in friendList)
		{
			if (friend.friendName == name)
			{
				this.currentFriend = friend;
			}
		}
	}
    //设置删除对象
    public void setDeleteFriend(int uid)
    {
        foreach (Friend f in friendList)
        {
            if (f.fiendId == deleteUId)
            {
                deleteFriend = f;
            }
        }
    }

    public bool checkFriend(Friend friend)
    {
        bool isFriend = false;
        foreach (Friend f in friendList)
        {
            if (f.fiendId == friend.fiendId)
            {
                isFriend = true;
            }
        }
        return isFriend;
    }

    public void setCurrentPage(int page) 
    {
        this.currentPage = page;
    }

    
}
