using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goods
{
	public ulong guid = 0;
	public uint templateId = 0;
	public uint number = 0;
}

public class Chat
{
    public Chat(){ }
    public int uid = 0;
    public string name = "";
    public int type = 0;
    public string data = "";
    public int targetUid = 0;
    public string targetName = "";
	public Goods goods = new Goods();
}

public class ChatManager  : MonoBehaviour
{
	/**  用于保存系统聊天对象 */
    public List<Chat> systemChatList = new List<Chat>();
	/**  用于保存世界聊天对象 */
    public List<Chat> worldChatList = new List<Chat>();
	/**  用于保存私聊对象 */
    public List<Chat> privateChatList = new List<Chat>();
	/**  用于判断是否有新聊天信息进入*/
    public bool IsDirty { get; set; }
	/**  当前聊天频道 */
    public int chat_channel = (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL;
	//下一条聊天记录的y轴坐标
	private int systemLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
	private int worldLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
	private int privateLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
	//当前页面显示的聊天记录的高度总和
	private int systemViewHeight = 0;
	private int worldViewHeight = 0;
	private int privateViewHeight = 0;
	//保存每个频道的聊天记录对象
	private List<GameObject> systemObjectList = new List<GameObject>();
	private List<GameObject> worldObjectList = new List<GameObject>();
	private List<GameObject> privateObjectList = new List<GameObject>();
	/**  聊天目标UID */
	private int targetId = 0;
	/**  物品道具ID */
	private ulong goodsId = 0;
	/**  是否已添加物品 */
	private bool haveGoods = false;
	/**  是否有新消息 */
	private bool haveNewSystemChat = false;
	private bool haveNewWorldChat = false;
	private bool haveNewPrivateChat = false;

	public void setHaveGoods(bool have){
		this.haveGoods = have;
	}

	public bool getHaveGoods(){
		return this.haveGoods;
	}

	public ulong getGoodsId(){
		return this.goodsId;
	}

	public void setGoodsId(ulong goodsId){
		this.goodsId = goodsId;
	}

	public bool getHaveNewPrivateChat(){
		return this.haveNewPrivateChat;
	}

	public void setHaveNewPrivateChat(bool haveNew){
		this.haveNewPrivateChat = haveNew;
	}

	public bool getHaveNewWorldChat(){
		return this.haveNewWorldChat;
	}
	
	public void setHaveNewWorldChat(bool haveNew){
		this.haveNewWorldChat = haveNew;
	}

	public bool getHaveNewSystemChat(){
		return this.haveNewSystemChat;
	}

	public void setHaveNewSystemChat(bool haveNew){
		this.haveNewSystemChat = haveNew;
	}

	public void setTargetId(int uid){
		targetId = uid;
	}

	public int getTargetId(){
		return this.targetId;
	}

    public void setCurrentChatChannel(int channel) 
    {
        this.chat_channel = channel;
    }

    public void setSystemChatList(Chat chat){
        this.systemChatList.Add(chat);
    }

    public List<Chat> getSystemChatList()
    {
        return this.systemChatList;
    }

    public void setWorldChatList(Chat chat)
    {
        this.worldChatList.Add(chat);
    }

    public List<Chat> getWorldChatList()
    {
        return this.worldChatList;
    }

    public void setPrivateChatList(Chat chat)
    {
        this.privateChatList.Add(chat);
    }

    public List<Chat> getPrivateChatList()
    {
        return this.privateChatList;
    }

    public void setIsDirty(bool isDirty)
    {
        this.IsDirty = isDirty;
    }

    public bool getIsDirty()
    {
        return this.IsDirty;
    }

    public void setTheLastPosition_y(int position) 
    {
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			this.systemLastPosition_y = position;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			this.worldLastPosition_y = position;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			this.privateLastPosition_y = position;
		}
    }

    public int getTheLastposition_y() 
    {
		int y = 0;
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			y = this.systemLastPosition_y;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			y = this.worldLastPosition_y;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			y = this.privateLastPosition_y;
		}
		
		return y;
    }
	

	public int getViewHeight()
	{
		int height = 0;
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			height = this.systemViewHeight;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			height = this.worldViewHeight;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			height = this.privateViewHeight;
		}
		
		return height;
	}

	public void setViewHeight(int height){
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			this.systemViewHeight = systemViewHeight + height;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			this.worldViewHeight = worldViewHeight + height;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			this.privateViewHeight = privateViewHeight + height;
		}
	}

	public List<GameObject> getChatObjectList(){
		List<GameObject> returnList = null;
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			returnList = this.systemObjectList;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			returnList = this.worldObjectList;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			returnList = this.privateObjectList;
		}

		return returnList;
	}

	public void addChatObject(GameObject chat){
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			this.systemObjectList.Add (chat);
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			this.worldObjectList.Add (chat);
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			this.privateObjectList.Add (chat);
		}
	}

	/**
    public List<Chat> getLastChat()
    {
		List<Chat> chatList = null;
        if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
        {
			chatList = this.systemChatList;
        }
        else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
        {
			chatList = this.worldChatList;
        }
        else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
        {
			chatList = this.privateChatList;
        }

		return chatList;
	} */
	
	public List<Chat> getCurrentChatList()
    {
        List<Chat> currentChatList = null;
        if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
        {
            currentChatList = this.systemChatList;
        }
        else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
        {
            currentChatList = this.worldChatList;
        }
        else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
        {
            currentChatList = this.privateChatList;
        }

        return currentChatList;
    }

	public bool getHaveNew(){
		bool haveNew = false;
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL && this.haveNewSystemChat)
		{
			haveNew = true;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL && this.haveNewWorldChat)
		{
			haveNew = true;
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL && this.haveNewPrivateChat)
		{
			haveNew = true;
		}

		return haveNew;
	}

	public void clearChatList(){
		if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL)
		{
			this.systemChatList.Clear();
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
		{
			this.worldChatList.Clear();
		}
		else if (chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
		{
			this.privateChatList.Clear();
		}
	}

	public void reset()
	{
		this.systemChatList.Clear();
		this.worldChatList.Clear ();
		this.privateChatList.Clear ();
		this.chat_channel = (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL;
		this.systemViewHeight = 0;
		this.worldViewHeight = 0;
		this.privateViewHeight = 0;
		this.targetId = 0;
		this.goodsId = 0;
		this.systemObjectList.Clear();
		this.worldObjectList.Clear();
		this.privateObjectList.Clear();
		this.systemLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
		this.worldLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
		this.privateLastPosition_y = (int)GlobalDef.ChatPosition.CHATINFOPOSITION;
	}
}
