using UnityEngine;
using System.Collections;

public class ClickChatInputCallback : MonoBehaviour {
	public UIPanel test;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UIInput input = (UIInput)GetComponent<UIInput>();
		string chat = input.value;
		ChatManager chatManager = MonoInstancePool.getInstance<ChatManager>();
		if ( Input.GetKey( KeyCode.Delete ) || Input.GetKey(KeyCode.Backspace) || Input.GetKey(KeyCode.Return))
		{
			//如果存在Ψ[符号，则检测此符号后面的字符中是否含有]
			if(chat.Contains("Ψ[")){
				if(!chat.Contains("]") || chat.IndexOf("]") < chat.IndexOf("Ψ")){
					input.value = chat.Substring(0, chat.IndexOf("Ψ"));
					chatManager.setHaveGoods(false);	//设置添加物品状态为未添加
				}
			}
		}
	}

	void OnClick(){

	}
}
