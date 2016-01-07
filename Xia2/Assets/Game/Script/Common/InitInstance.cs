using UnityEngine;
using System.Collections;

public class InitInstance : MonoBehaviour {

	void Awake()
	{
		MonoInstancePool.getInstance<UserData>();
		MonoInstancePool.getInstance<BagManager>();
		MonoInstancePool.getInstance<ChatManager>();
		MonoInstancePool.getInstance<FriendManager>();
		MonoInstancePool.getInstance<HeroManager>();
		MonoInstancePool.getInstance<MailManager>();
//		MonoInstancePool.getInstance<ShopManager1>();
		MonoInstancePool.getInstance<FriendModulMsg>();
		MonoInstancePool.getInstance<ItemSystemModuleMsg>();
		MonoInstancePool.getInstance<LoginModuleMsg>();
		MonoInstancePool.getInstance<NoticeModuleMsg>();
		MonoInstancePool.getInstance<UserDataModuleMsg>();
		MonoInstancePool.getInstance<SendFriendSystemHander>();
		MonoInstancePool.getInstance<SendItemSystemMsgHander>();
		MonoInstancePool.getInstance<SendMailSystemHander>();
		MonoInstancePool.getInstance<SendMessageHander>();
		MonoInstancePool.getInstance<SendUserDataMsgHander>();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
