using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SendChatMsg : MonoBehaviour {

	public UIInput mInput;
// 	public UITextList AllTextList;
//     public UITextList WorldTextList;
//     public UITextList PrivateTextList;
    //public UIButton mButton;

	List<string> chatText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnClick()
	{
		string text = NGUIText.StripSymbols(mInput.value);

		if (!string.IsNullOrEmpty(text))
		{
			ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
			int targetId = chatManager.getTargetId();
			//发送之前检测是否是GM协力 sudo aa 1234
			if (text.Contains ("sudo ")) {
				string[] str=text.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);  
				if(str.Length != 3)
				{
					MonoInstancePool.getInstance<SendMessageHander>().SendChatRequest(MonoInstancePool.getInstance<ChatManager>().chat_channel, text, targetId, chatManager.getGoodsId());
				}
				else
				{
					MonoInstancePool.getInstance<SendMessageHander>().SendCreateGMRequest(Convert.ToInt32(str[str.Length - 1]),str[1]);
				}
			}
			else
			{
				//发送之前我需要检测是否含有物品或者道具
				MonoInstancePool.getInstance<SendMessageHander>().SendChatRequest(MonoInstancePool.getInstance<ChatManager>().chat_channel, text, targetId, chatManager.getGoodsId());
			}
				
			//重置物品道具ID
			chatManager.setGoodsId(0);
			chatManager.setHaveGoods(false);
			mInput.value = "";
			mInput.isSelected = false;

		}
	}
}
