using UnityEngine;
using System.Collections;

public class Infomation : MonoBehaviour {
    public int uid;
    public string name;
    public ulong guid;
    public int type;  //0 表示人名连接  1 表示道具连接
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setWidth(int width)
	{
		UISprite sp = GetComponentInChildren<UISprite>();
		if(sp != null)
		{
			sp.width = width;
			
			BoxCollider collider = GetComponentInChildren<BoxCollider>();
			if(collider)
			{
				collider.size = sp.localSize;
			}
		}

	}
	public void setHeight(int height)
	{
		UISprite sp = GetComponentInChildren<UISprite>();
		if(sp != null)
		{
			sp.height = height;
			
			BoxCollider collider = GetComponentInChildren<BoxCollider>();
			if(collider)
			{
				collider.size = sp.localSize;
			}
		}
	}
	void OnClick()
	{
		Debug.Log("click :" + uid);
        var chatUImanager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
        if (chatUImanager)
        {
            chatUImanager.showShaderWindow();
			if(type == 0){		//人名连接
				chatUImanager.showChatNameLinkWindow();
				var chatNameUIManager = (aChatNameUIManager)FindObjectOfType<aChatNameUIManager>();
				if(chatNameUIManager){
					chatNameUIManager.setName(name);
				}
				ClickNameLinkPrivateChat cnlpc = (ClickNameLinkPrivateChat)FindObjectOfType<ClickNameLinkPrivateChat>();
				if(cnlpc){
					cnlpc.uid = uid;
				}
			}else{               //道具连接
				if(guid > 0){//此操作应该根据guid去检测道具是否存在，不应该判断>0
					chatUImanager.showChatItemLinkWindow();
					var chatItemUIManager = (ChatItemUIManager)FindObjectOfType<ChatItemUIManager>();
					if(chatItemUIManager){
						chatItemUIManager.setGuid(guid);
					}
				}else{
					chatUImanager.hideShaderWindow();
				}
			}
        } 
	}
}
