using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatUIManager : MonoBehaviour
{
    public UIPanel SystemChatWindow;
    public UIPanel WorldChatWindow;
    public UIPanel PrivateChatWindow;
    public UIPanel ChatNameLinkWindow;
    public UIPanel ShaderWindow;
    public UIInput Input;
	public UIPanel ChatItemLinkWindow;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (MonoInstancePool.getInstance<ChatManager>().getIsDirty())
        {
			MonoInstancePool.getInstance<ChatManager>().setIsDirty(false);
			var haveNew = MonoInstancePool.getInstance<ChatManager>().getHaveNew();
			if(haveNew){
				refreshChat();
			}
        }
    }

    public void refreshChat()
    {
        
        string text = "";
        //获取当前聊天列表
		List<Chat> chatList = MonoInstancePool.getInstance<ChatManager>().getCurrentChatList();
		foreach (Chat chat in chatList) {
			ulong guid = 0;		
			if(chat.goods !=null){
				guid = chat.goods.guid;
			}
			switch (chat.type)
			{
			case (int)GlobalDef.CHAT_CHANNEL.ALL_CHANNEL:       //系统	
				//if (chat.uid == MonoInstancePool.getInstance<UserData>().guid)
				//{
				//	text = "[6A5ACD]<" + GlobalDef.MYSELF + ">[-] : " + chat.data;	
				//}
				//else
				//{
				//	text = "[ff0000]<" + GlobalDef.SYSTEMCHATCHANNEL + ">[-] : " + chat.data;
				//}      
				text = "[6A5ACD]<" + GlobalDef.MYSELF + ">[-] : " + chat.data;
				load(chatList.Count - 1, text, chat.uid, chat.name, guid);
				break;
			case (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL:     //世界
				if (chat.uid == MonoInstancePool.getInstance<UserData>().guid)
				{
					text = "[ffffff]<" + GlobalDef.MYSELF + ">[-] : " + chat.data;
				}
				else
				{
					text = "[ff0000]Ψ[<" + chat.name + ">][-] : " + chat.data;
				}
				
				load(chatList.Count - 1, text, chat.uid, chat.name, guid);
				break;
			case (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL:   //私聊
				if (chat.uid == MonoInstancePool.getInstance<UserData>().guid)
				{
					text = "[ffffff]<" + GlobalDef.PRIVATECHATCHANNEL + ">发送给[ff0000]Ψ[" + chat.targetName + "][-]: " + chat.data;
					load(chatList.Count - 1, text, chat.targetUid, chat.targetName, guid);
				}
				else
				{
					text = "[ff0000]Ψ[<" + chat.name + ">][-] : " + chat.data;
					load(chatList.Count - 1, text, chat.uid, chat.name, guid);
				}
				break;
			}
		}

		MonoInstancePool.getInstance<ChatManager>().clearChatList ();
	}
	
	void load(int index, string text, int uid, string name, ulong guid)
	{
		GameObject instance = Instantiate(Resources.Load("Prefab/ChatSystem/ChatPrefab", typeof(GameObject))) as GameObject;
		instance.gameObject.SetActive(true);
         if (MonoInstancePool.getInstance<ChatManager>().chat_channel == (int)GlobalDef.CHAT_CHANNEL.PRIVATE_CHANNEL)
         {
			instance.transform.parent = PrivateChatWindow.gameObject.transform;
         }
         else if (MonoInstancePool.getInstance<ChatManager>().chat_channel == (int)GlobalDef.CHAT_CHANNEL.WORLD_CHANNEL)
         {
			instance.transform.parent = WorldChatWindow.gameObject.transform;
         }
         else
         {
			instance.transform.parent = SystemChatWindow.gameObject.transform;
         }
        LinkTest s = instance.GetComponent<LinkTest>();
		s.loadText(text, uid, name, guid);//加载聊天记录
        UILabel label = s.GetComponentInChildren<UILabel>();
        instance.transform.localScale = Vector3.one;
		//获取当前记录的y轴坐标
		int sprite_y = MonoInstancePool.getInstance<ChatManager>().getTheLastposition_y();
		//根据字体的高度算出来的数值，不能写死，有待改善
		int offset_y = (label.height / 28 - 1) * 14;
		int y = sprite_y - offset_y;
		//设置聊天记录的位置
		instance.transform.localPosition = new Vector3(0, y, 0);
		//设置此时此频道所有聊天记录的总高度
		MonoInstancePool.getInstance<ChatManager>().setViewHeight (label.height);
		int viewHeight = MonoInstancePool.getInstance<ChatManager>().getViewHeight ();
		//如果总高度在屏幕范围内，则下一条记录的y轴坐标下移当前记录的高度
		if (viewHeight <= (int)GlobalDef.ChatPosition.CHATVIEWHEIGHT) {
			MonoInstancePool.getInstance<ChatManager>().setTheLastPosition_y(sprite_y - label.height);	//设置下一条记录的位置
		}
		MonoInstancePool.getInstance<ChatManager>().addChatObject (instance);
		List<GameObject> chatObjectList = MonoInstancePool.getInstance<ChatManager>().getChatObjectList ();
		if (chatObjectList.Count >= GlobalDef.MAXCHATITEM) {
			Destroy(chatObjectList[0].gameObject);
			chatObjectList.Remove(chatObjectList[0]);
		}
		//如果聊天条目超过当前页面高度，则每条记录上移当前记录的高度
		if (viewHeight > (int)GlobalDef.ChatPosition.CHATVIEWHEIGHT) {
			foreach (GameObject obj in chatObjectList) {
				obj.transform.localPosition = new Vector3(0, obj.transform.localPosition.y + label.height, 0);		
			}
		}
    }

    public void setInput(long goodsId)
    {
		if (!MonoInstancePool.getInstance<ChatManager>().getHaveGoods ()) {//检测是否已添加物品
			//此处应根据物品ID得到物品名字，暂时先写成这样了
			string name = ""+goodsId;
			MonoInstancePool.getInstance<ChatManager>().setGoodsId ((ulong)goodsId);
			Input.value = Input.value + "Ψ[" + name + "]";
			MonoInstancePool.getInstance<ChatManager>().setHaveGoods(true);
		}
    }

	public void showChatItemLinkWindow(){
		if (ChatItemLinkWindow != null) {
			ChatItemLinkWindow.gameObject.SetActive(true);		
		}
	}

	public void hideChatItemLinkWindow(){
		if (ChatItemLinkWindow != null) {
			ChatItemLinkWindow.gameObject.SetActive(false);		
		}
	}

    public void showShaderWindow()
    {
        if (ShaderWindow != null)
        {
            ShaderWindow.gameObject.SetActive(true);
        }
    }

    public void hideShaderWindow()
    {
        if (ShaderWindow != null)
        {
            ShaderWindow.gameObject.SetActive(false);
        }
    }

    public void showChatNameLinkWindow()
    {
        if (ChatNameLinkWindow != null)
        {
            ChatNameLinkWindow.gameObject.SetActive(true);
        }
    }

    public void hideChatNameLinkWindow()
    {
        if (ChatNameLinkWindow != null)
        {
            ChatNameLinkWindow.gameObject.SetActive(false);
        }
    }

    public void showWorldChatWindow()
    {
        if (WorldChatWindow != null)
        {
            WorldChatWindow.gameObject.SetActive(true);
        }
    }

    public void hideWorldChatWindow()
    {
        if (WorldChatWindow != null)
        {
            WorldChatWindow.gameObject.SetActive(false);
        }
    }

    public void showSystemChatWindow()
    {
        if (SystemChatWindow != null)
        {
            SystemChatWindow.gameObject.SetActive(true);
        }
    }

    public void hideSystemChatWindow()
    {
        if (SystemChatWindow != null)
        {
            SystemChatWindow.gameObject.SetActive(false);
        }
    }

    public void showPrivateChatWindow()
    {
        if (PrivateChatWindow != null)
        {
            PrivateChatWindow.gameObject.SetActive(true);
        }
    }

    public void hidePrivateChatWindow()
    {
        if (PrivateChatWindow != null)
        {
            PrivateChatWindow.gameObject.SetActive(false);
        }
    }

    public void hideChatWindow()
    {
        this.gameObject.SetActive(false);
        hideAll();
    }

    public void hideAll()
    {
        if (PrivateChatWindow != null)
        {
            PrivateChatWindow.gameObject.SetActive(false);
        }

        if (SystemChatWindow != null)
        {
            SystemChatWindow.gameObject.SetActive(false);
        }

        if (WorldChatWindow != null)
        {
            WorldChatWindow.gameObject.SetActive(false);
        }
    }
}
