using UnityEngine;
using System.Collections.Generic;
using System.IO;
using ItemMessage;

public class SendItemSystemMsgHander : MonoBehaviour{

	//	ID_C2S_ITEM_LIST				= 40001; // 获取道具列表
	//	ID_S2C_ITEM_LIST				= 40002; // 获取道具列表
	public void sendGetItemListReq(int type)
	{
		ItemMessage.MsgGetItemListReq msg = new ItemMessage.MsgGetItemListReq();
		msg.type = type;

		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_ITEM_LIST, msg);	
	}
	//	ID_C2S_ITEM_USE				    = 40003; // 使用道具
	//	ID_S2C_ITEM_USE				    = 40004; // 使用道具
	public void sendUseItemReq(long guid, int num, long heroID)
	{
		ItemMessage.MsgUseItemReq msg = new ItemMessage.MsgUseItemReq();
		msg.guid = (ulong)guid;
		msg.number = (uint)num;
		msg.heroGuid = heroID;

		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_ITEM_USE, msg);	
	}
	//	ID_C2S_ITEM_DEL				    = 40005; // 删除道具
	//	ID_S2C_ITEM_DEL				    = 40006; // 删除道具
	public void sendDelItemReq(int bagType,long guid, int num)
	{
		ItemMessage.MsgDelItemReq msg = new ItemMessage.MsgDelItemReq();
		msg.type = bagType;
		msg.guid = (ulong)guid;
		msg.number = num;
	
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_ITEM_DEL, msg);	
	}
	//	ID_C2S_ITEM_ADD				    = 40007; // 添加道具
	//	ID_S2C_ITEM_ADD				    = 40008; // 添加道具
	public void sendAddItemReq(int bagType, uint templateID)
	{
		ItemMessage.MsgAddItemReq msg = new ItemMessage.MsgAddItemReq();
		msg.templateID = templateID;
		msg.type = bagType;
	
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_ITEM_ADD, msg);	
	}

    //ID_C2S_REINFORCEMENT_EQUIP         = 40019; // 装备强化
    //ID_S2C_REINFORCEMENT_EQUIP         = 40020; // 装备强化 
    public void SendGetReinforcementEquip(ulong guid,ulong heroId, int normal,  int advanced)
    {
        //装备强化
        ItemMessage.MsgReinforcementEquipReq msg = new ItemMessage.MsgReinforcementEquipReq();
        msg.guid = guid;
        msg.heroId = heroId;
        msg.normal = normal;
        msg.advanced = advanced;

        Debug.Log(guid + "----------heroId----" + heroId + "---------normal---------" + normal + "------advanced----" + advanced);

        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_REINFORCEMENT_EQUIP, msg);
    }

    //ID_C2S_UPDATE_EQUIP_STAR           = 40017; // 装备升星
	//ID_S2C_UPDATE_EQUIP_STAR           = 40018; // 装备升星
    public void SendGetEquipmentStar(ulong guid, ulong heroId)
    {
        //装备升星
        ItemMessage.MsgUpdateEquipStarReq msg = new ItemMessage.MsgUpdateEquipStarReq();
        msg.guid = guid;
        msg.heroId = heroId;

        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_UPDATE_EQUIP_STAR, msg);
    }

    //ID_C2S_INLAY_GEM                   = 40021; // 宝石镶嵌
	//ID_S2C_INLAY_GEM                   = 40022; // 宝石镶嵌  
    public void SendGetInlayGem(ulong equipGuid, ulong gemId, ulong heroGuid)
    {
        //宝石镶嵌
        ItemMessage.MsgInlayGemReq msg = new ItemMessage.MsgInlayGemReq();
        msg.guid = equipGuid;
        msg.gemGuid = gemId;
        msg.guid = heroGuid;

        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_INLAY_GEM, msg);
    }
//	ID_C2S_WEAR_EQUIP                  = 40023; // 穿装备 
//	ID_S2C_WEAR_EQUIP                  = 40024; // 穿装备
	public void SendPutOnEquipment(long item_guid, long hero_guid)
	{
		MsgWearEquipReq msg = new MsgWearEquipReq();
		msg.guid = (ulong)item_guid;
		msg.heroId = (ulong)hero_guid;

		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_WEAR_EQUIP, msg);
	}
//	ID_C2S_DROP_EQUIP                  = 40025; // 脱装备
//	ID_S2C_DROP_EQUIP                  = 40026; // 脱装备
	public void SendPutOffEquipment(long item_guid, ulong hero_guid)
	{
		MsgDropEquipReq msg = new MsgDropEquipReq();
		msg.guid = (ulong)item_guid;
		msg.heroId = hero_guid;

		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_DROP_EQUIP, msg);
	}

    //ID_C2S_EQUIP_RESOLVE               = 40027; // 熔炼装备
    //ID_S2C_EQUIP_RESOLVE               = 40028; // 熔炼装备
    public void SendSmeltingEquip(List<ulong> guids) 
    {
        MsgEquipResolveReq msg = new MsgEquipResolveReq();
        for (int i = 0;  i<guids.Count; i++)
        {
            msg.guid.Add(guids[i]);
        }

        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_EQUIP_RESOLVE, msg);
    }

    // ID_C2S_EQUIP_FORGE   锻造装备
    public void SendForgingEquip(ulong equipGuid, ulong equipID, ulong heroId, bool ignorelost)
    {
        MsgEquipForgeReq msg = new MsgEquipForgeReq();
        msg.guid = equipGuid;
        msg.forgeid = equipID;
        msg.heroId = heroId;
        msg.ignorelost = ignorelost;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)ItemMessage.ITEM_MSG_ID.ID_C2S_EQUIP_FORGE, msg);
    }
}
