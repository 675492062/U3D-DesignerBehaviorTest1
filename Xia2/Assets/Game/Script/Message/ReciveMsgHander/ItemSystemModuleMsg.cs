using UnityEngine;
using System.Collections.Generic;

public class ItemSystemModuleMsg : MonoBehaviour
{

    public int parse(SocketModel module)
    {
        switch (module.messageID)
        {
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_ITEM_LIST:// 获取道具列表
                onGetItemList(module);
                break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_ITEM_USE: // 使用道具
                onUseItem(module);
                break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_ITEM_DEL: // 删除道具
                onDelItem(module);
                break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_ITEM_ADD: // 添加道具
                onAddItem(module);
                break;
            //shop
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_GET_SHOP_ITEM_LIST: // 获取商品列表
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_REFRESH_SHOP_ITEM_LIST: // 刷新商品列表
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_BUY_SHOP_ITEM: // 购买商品
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_SELL_ITEM: // 出售商品
            	MonoInstancePool.getInstance<ShopModuleMsg>().parse(module);
                break;
            //equipment
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_REINFORCEMENT_EQUIP:   //装备强化
                onReinforcementEquip(module);
                break;
            //case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_UPDATE_EQUIP_STAR:     //装备升星
            //    onGetEquipmentStar(module);
            //    break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_INLAY_GEM:             //宝石镶嵌
                break;
            //		case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_WEAR_EQUIP:            //穿装备
            //			onPutOnEquip(module);
            //			break;
            //		case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_DROP_EQUIP:            //脱装备
            //			onPutOffEquip(module);
            //break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_EQUIP_RESOLVE:     //熔炼装备
                onSmeltingEquip(module);
                break;
            case (int)ItemMessage.ITEM_MSG_ID.ID_S2C_EQUIP_FORGE:
                onForgingEquip(module);
                break;
            default:
                return -1;
        }
        return 0;
    }
    public void onGetItemList(SocketModel module)
    {
        ItemMessage.MsgGetItemListRep msg = MsgSerializer.Deserialize<ItemMessage.MsgGetItemListRep>(module);
        BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(msg.type);
        if (bag == null)
        {
            Debug.LogError("have not this bag!");
            return;
        }
        bag.clear();
        //Debug.Log("bag: " + msg.type + " have: " + msg.itemList.Count + " " + msg.equipList.Count);
        if (msg.type == (int)GlobalDef.BagType.B_EQUIPMENT)
        {
            for (int i = 0; i < msg.equipList.Count; i++)
            {
                Property.Equip item = msg.equipList[i];
                EquipmentItem baseItem = new EquipmentItem();
                baseItem.parseData(item);
                bag.addItem(baseItem);
                bag.IsDirty = true;
            }
        }
        else
        {
            for (int i = 0; i < msg.itemList.Count; i++)
            {
                Property.Item item = msg.itemList[i];
                BaseItem baseItem = MonoInstancePool.getInstance<BagManager>().createItemByData(item);
                bag.addItem(baseItem);
                bag.IsDirty = true;
            }
        }
    }
    public void onUseItem(SocketModel module)
    {
        ItemMessage.MsgUseItemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgUseItemRep>(module);

        Debug.Log("use: " + msg.guid + " effect:  " + msg.value);
    }
    public void onDelItem(SocketModel module)
    {
        ItemMessage.MsgDelItemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgDelItemRep>(module);

        BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(msg.type);
        if (bag == null)
        {
            Debug.LogError("have not this bag!");
            return;
        }
        long guid = (long)msg.guid;
        int num = msg.number;
        if (num <= 0)
        {
            bag.removeItem(guid);
        }
        else
        {
            bag.setItemNum(guid, num);
        }
        bag.IsDirty = true;
    }
    public void onAddItem(SocketModel module)
    {
        ItemMessage.MsgAddItemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgAddItemRep>(module);

        BagStruct bag = MonoInstancePool.getInstance<BagManager>().getBagByType(msg.type);
        if (bag == null)
        {
            Debug.LogError("have not this bag!");
            return;
        }
        BaseItem baseItem = null;
        if (msg.equip != null)
        {
            baseItem = new EquipmentItem();
            (baseItem as EquipmentItem).parseData(msg.equip);
        }
        else
        {
            baseItem = MonoInstancePool.getInstance<BagManager>().createItemByData(msg.item);
        }

        Debug.Log("addItem num: " + baseItem.haveNum);
        bag.addItem(baseItem);
        bag.IsDirty = true;
    }

    public void onReinforcementEquip(SocketModel module)
    {
        //强化
        ItemMessage.MsgReinforcementEquipRep msg = MsgSerializer.Deserialize<ItemMessage.MsgReinforcementEquipRep>(module);
        int id = (int)msg.heroId;
        if (id == 0)
        {
            EquipmentItem item = (EquipmentItem)MonoInstancePool.getInstance<BagManager>().getEquipmentBag().getItem((long)msg.itemGuid);
            if (item == null)
            {
                Debug.LogError("has not this item!");
                return;
            }
            item.equiplev = msg.level;
            item.isDirty = true;
            MonoInstancePool.getInstance<BagManager>().getEquipmentBag().IsDirty = true;
        }
        else
        {
            HeroData data = MonoInstancePool.getInstance<HeroManager>().getHero((long)msg.heroId);
            if (data == null)
            {
                Debug.LogError("has not this heroData!");
                return;
            }

            EquipmentItem item = data.equipmentList.getItemByGuid((long)msg.itemGuid);
            item.equiplev = msg.level;
            item.isDirty = true;
            data.equipmentList.isDirty = true;
        }

        EqptCtrl.instance.EnhanceCallBack();

        //Debug.Log(msg.itemGuid + "----------exp----" + msg.exp + "---------level---------" + msg.level + "KKKKKKKKKKKKK");
    }

    //public void onGetEquipmentStar(SocketModel module)
    //{
    //    //升星
    //    ItemMessage.MsgUpdateEquipStarRep msg = MsgSerializer.Deserialize<ItemMessage.MsgUpdateEquipStarRep>(module);
    //    int id = (int)msg.heroId;

    //    if (id == 0)
    //    {
    //        EquipmentItem item = (EquipmentItem)MonoInstancePool.getInstance<BagManager>().getEquipmentBag().getItem((long)msg.itemGuid);
    //        if (item == null)
    //        {
    //            Debug.LogError("has not this item!");
    //            return;
    //        }
    //        item.changeStar = msg.star;
    //        MonoInstancePool.getInstance<BagManager>().getEquipmentBag().IsDirty = true;

    //        EquipmentUIMananger manager = (EquipmentUIMananger)FindObjectOfType(typeof(EquipmentUIMananger));
    //        if (manager == null)
    //            return;
    //        manager.getStrengthEquipment().setEquipHeroId(null);
    //        manager.getStrengthEquipment().EquipmentUpdate(item);
    //    }
    //    else
    //    {
    //        HeroData data = MonoInstancePool.getInstance<HeroManager>().getHero((long)msg.itemGuid);
    //        if (data == null)
    //        {
    //            Debug.LogError("has not this heroData!");
    //            return;
    //        }
    //        EquipmentItem item = data.equipmentList.getItemByIdx((int)msg.itemGuid);
    //        item.changeStar = msg.star;
    //        data.equipmentList.isDirty = true;

    //        EquipmentUIMananger manager = (EquipmentUIMananger)FindObjectOfType(typeof(EquipmentUIMananger));
    //        if (manager == null)
    //            return;
    //        manager.getStrengthEquipment().setEquipHeroId(data);
    //        manager.getStrengthEquipment().EquipmentUpdate(item);
    //    }
    //}

    public void onGetInlayGem(SocketModel module)
    {
        //镶嵌
        ItemMessage.MsgInlayGemRep msg = MsgSerializer.Deserialize<ItemMessage.MsgInlayGemRep>(module);
        int id = (int)msg.heroId;
        if (id == 0)
        {
            EquipmentItem item = (EquipmentItem)MonoInstancePool.getInstance<BagManager>().getEquipmentBag().getItem((long)msg.guid);
            if (item == null)
            {
                Debug.LogError("has not this item!");
                return;
            }
            int count = msg.gemAry.Count;
            for (int i = 0; i < count; i++)
            {
                Property.Item gem = msg.gemAry[i];
                item.gemList.Clear();
                DiamondItem diamon = new DiamondItem();
                diamon.parseData(gem);
                item.addDiamonItem(diamon.guid, diamon);
            }

            MonoInstancePool.getInstance<BagManager>().getEquipmentBag().IsDirty = true;
        }
        else
        {
            HeroData data = MonoInstancePool.getInstance<HeroManager>().getHero((long)msg.heroId);
            if (data == null)
            {
                Debug.LogError("has not this heroData!");
                return;
            }
            EquipmentItem item = data.equipmentList.getItemByGuid((long)msg.guid);
            int count = msg.gemAry.Count;
            for (int i = 0; i < count; i++)
            {
                Property.Item gem = msg.gemAry[i];
                item.gemList.Clear();
                DiamondItem diamon = new DiamondItem();
                diamon.parseData(gem);
                item.addDiamonItem(diamon.guid, diamon);
            }
            data.equipmentList.isDirty = true;
        }
    }

    /// <summary>
    /// 熔炼
    /// </summary>
    /// <param name="module"></param>
    public void onSmeltingEquip(SocketModel module)
    {
        ItemMessage.MsgEquipResolveRep msg = MsgSerializer.Deserialize<ItemMessage.MsgEquipResolveRep>(module);
        List<MaterialItem> items = new List<MaterialItem>();

        //mats加入背包
        BagStruct bag = MonoInstancePool.getInstance<BagManager>().getMaterialBag();
        for (int i = 0; i < msg.list.Count; i++)
        { 
            MaterialItem item = new MaterialItem();
            item.parseData(msg.list[i].id,msg.list[i].number);
            items.Add(item);
            bag.addItem(item);
        }

        EqptCtrl.instance.SmeltingCallBack(items);
    }

    /// <summary>
    /// 锻造
    /// </summary>
    /// <param name="module"></param>
    public void onForgingEquip(SocketModel module)
    {
        ItemMessage.MsgEquipForgeRep msg = MsgSerializer.Deserialize<ItemMessage.MsgEquipForgeRep>(module);
        EqptCtrl.instance.ForgingCallBack(msg.guid,msg.heroId, msg.equipInfo);

        //Debug.Log("-------------------------server call back: guid : " + msg.guid + "  heroID  " + msg.heroId + "equip temID " + msg.equipInfo.templateid);
    }
}
