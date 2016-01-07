using UnityEngine;
using System.Collections;
using System;

public class SendShopMsgHandler : MonoBehaviour {

	public void SendShopListReq(){
		foreach(int type in Enum.GetValues(typeof(ItemMessage.ENUM_SHOP_TYPE))){
			//Debug.LogError("type is " + type);
			sendGetShopListReq(type);
		}
	}

	//	ID_C2S_GET_SHOP_ITEM_LIST		= 40009; // 获取商品列表
	//	ID_S2C_GET_SHOP_ITEM_LIST		= 40010; // 获取商品列表
	public void sendGetShopListReq(int shopId)
	{
		ItemMessage.MsgGetShopItemListReq msg = new ItemMessage.MsgGetShopItemListReq();
		msg.idx = shopId;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_GET_SHOP_ITEM_LIST, msg);	
	}
	
	//	ID_C2S_REFRESH_SHOP_ITEM_LIST	= 40013; // 手动刷新商品列表
	//	ID_S2C_REFRESH_SHOP_ITEM_LIST	= 40014; // 手动刷新商品列表
	public void sendRefreshShopListReq(int type , int shopId)
	{
		ItemMessage.MsgRefreshShopItemListReq msg = new ItemMessage.MsgRefreshShopItemListReq();
		msg.type = type;
		msg.idx = shopId;
		
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_REFRESH_SHOP_ITEM_LIST, msg);	
	}
	//	ID_C2S_BUY_SHOP_ITEM			= 40015; // 购买商品
	//	ID_S2C_BUY_SHOP_ITEM			= 40016; // 购买商品
	public void sendBuyItemReq(int shopId , int idx)
	{
		ItemMessage.MsgBuyItemReq msg = new ItemMessage.MsgBuyItemReq();
		msg.idx = (uint)shopId;
		msg.grid = idx;
		
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_BUY_SHOP_ITEM, msg);	
	}
	//	ID_C2S_SELL_ITEM				= 40017; // 出售商品
	//	ID_S2C_SELL_ITEM				= 40018; // 出售商品
	public void sendSellItemReq(long guid, int num ,int type)
	{
		ItemMessage.MsgSellItemReq msg = new ItemMessage.MsgSellItemReq();
		msg.guid = (ulong)guid;
		msg.number = num;
		msg.type = type;
		
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_SELL_ITEM, msg);	
	}
}
