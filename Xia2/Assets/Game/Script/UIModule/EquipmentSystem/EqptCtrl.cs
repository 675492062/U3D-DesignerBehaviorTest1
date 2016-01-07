/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-14   WP      Initial version
 *      12-25   WP      新版本改版
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EqptCtrl : MonoBehaviour
{
    public EqptPnlBag pnlBag;

    public GameObject pnlWaitCallBack;

    /// <summary>
    /// 二级面板，其中包含了 enhance forge
    /// </summary>
    public GameObject pnlSecond;

    public EqptPanelEnhance pnlEnhance;

    public EqptPanelForge pnlForge;

    /// <summary>
    /// 当前公用面板中的Slot
    /// </summary>
    public EqptSlot curSlot;

    private static EqptCtrl mInstance;
    public static EqptCtrl instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = UnityEngine.Object.FindObjectOfType(typeof(EqptCtrl)) as EqptCtrl;
            }
            return mInstance;
        }
    }

    //private EqptPanel currentPanel; //取消当前面板设定

    private EquipmentItem selectItem
    {
        get
        {
            return selectSlot.GetItem();
        }
        set
        {
            mSlot = GetDefaultSlot();
        }
    }

    private delegate void OnClickBack();

    private event OnClickBack onClickBack;

    private EqptSlot mSlot;
    private EqptSlot selectSlot
    {
        get
        {
            if (mSlot == null)
            {
                mSlot = GetDefaultSlot();
                Debug.Log("--------Get default slot", mSlot);
            }
            return mSlot;
        }
        set
        {
            if (mSlot != value)
            {
                mSlot = value;
            }
        }
    }

    void OnEnable()
    {
        onClickBack += ExitPanel;
        //TODO 当装备有改变，需要刷新
        //pnlBag.SetRefresh();

        UIPanel panel = NGUITools.FindInParents<UIPanel>(gameObject);
        UICurrencyManager.Show(transform, panel.depth);

        BtnEquip(selectSlot);
    }

    void OnDisable()
    {
        if (onClickBack != null) onClickBack = null;
    }

    void RefreshCurEquip()
    {
        curSlot.Refresh(selectItem);
        curSlot.SetPropsDesc();
    }

    /// <summary>
    /// 装备点击
    /// </summary>
    /// <param name="item"></param>
    /// <param name="isOnChar">是否在玩家身上</param>
    public void BtnEquip(EqptSlot slot)
    {
        SetCurrentSlot(slot);

        //currentPanel.OnEquipClick(slot, hero_guid);

        //更新当前选择框
        pnlBag.SetSelectObj(slot.gameObject.transform);
    }

    public void BtnToEnhance()
    {
        ToSecondPanel(true);
    }

    public void BtnToForging()
    {
        ToSecondPanel(false);
        pnlForge.Refresh();
    }

    public void BtnToBack()
    {
        if (onClickBack != null)
        {
            Debug.Log(onClickBack.ToString());
            onClickBack();
        }
    }

    void ToSecondPanel(bool isEnhance)
    {
        pnlBag.gameObject.SetActive(false);
        pnlSecond.gameObject.SetActive(true);
        pnlEnhance.gameObject.SetActive(isEnhance);
        pnlForge.gameObject.SetActive(!isEnhance);
        onClickBack += ExitSecondPanel;
        onClickBack -= ExitPanel; ;
        //Debug.Log("enter ToSecondPanel ");

    }

    void ExitPanel()
    {
        onClickBack -= ExitPanel;
        gameObject.SetActive(false);
        //Debug.Log("Exit panel ");
    }

    void ExitSecondPanel()
    {
        pnlBag.gameObject.SetActive(true);
        pnlSecond.gameObject.SetActive(false);
        onClickBack -= ExitSecondPanel;
        onClickBack += ExitPanel;
        //Debug.Log("Exit second ");
    }

    private void SetCurrentSlot(EqptSlot slot)
    {
        selectSlot = slot;
        RefreshCurEquip();
    }

    public EqptSlot GetCurrentSlot() { return selectSlot; }

    /// <summary>
    /// 返回第一个有装备的Slot
    /// </summary>
    /// <returns></returns>
    public EqptSlot GetDefaultSlot()
    {
        List<EqptSlot> slots = pnlBag.GetSlots();
        EqptSlot slot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            EquipmentItem item = slots[i].GetItem();
            if (item == null) continue;

            slot = slots[i];
            Debug.Log("-------default is slot " + slot, slot);
            //pnlBag.SetSelectObj(slot.transform);
            return slot;
        }

        return slot;
    }

    #region SendMessage to server Event

    public void SmeltingCallBack(List<MaterialItem> items)
    {
        pnlWaitCallBack.SetActive(false);
        EqptPanelSmelt.instance.SmeltingCallBack(items);
        pnlBag.Refresh();
        if (selectItem != null)
        {
            //Debug.Log("Destory curren item is " + currentItem.name);
            selectItem = null;
        }
        //currentPanel.Refresh();
    }

    public void ForgingCallBack(ulong guid, ulong heroID, Property.Equip equip)
    {
        //Debug.Log("callback");
        long oldGuid = selectItem.guid;
        pnlWaitCallBack.SetActive(false);
        EquipmentItem it;
        if (heroID > 0)
        {
            Debug.Log("heroID : " + heroID + "  new item guid " + guid + " old item guid " + oldGuid);
            it = MonoInstancePool.getInstance<HeroManager>().getHero((long)heroID).equipmentList.getItemByGuid(oldGuid);
            it.parseData(equip);
        }
        else
        {
            BagStruct bag = MonoInstancePool.getInstance<BagManager>().getEquipmentBag();
            it = bag.getItem(oldGuid) as EquipmentItem;
            it.parseData(equip);
            Debug.Log("current == bag : " + (selectItem == it));
        }

        //在面板上更新这个装备
        pnlBag.Refresh();
        selectItem = it;
        pnlForge.CallBack(selectItem);

    }

    public void ForgingEvent(EquipmentItem item, ulong hero_guid, bool ignorelost)
    {
        Debug.Log("sendmessage guid :" + item.guid + "  hero _  guid " + hero_guid);
        WaitForCallBack();
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().SendForgingEquip((ulong)item.guid, (ulong)item.formerid, hero_guid, ignorelost);
    }

    public void SmeltingEvent(List<ulong> list)
    {
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().SendSmeltingEquip(list);
        WaitForCallBack();
    }

    public void EnhanceEvent()
    {
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().SendGetReinforcementEquip
            ((ulong)selectItem.guid, (ulong)selectSlot.GetHeroGuid(), 1, 0);

        WaitForCallBack();
    }

    public void EnhanceCallBack()
    {
        pnlWaitCallBack.SetActive(false);
        RefreshCurEquip();
        pnlEnhance.Refresh();
    }

    /// <summary>
    /// 开始等待服务器调
    /// </summary>
    void WaitForCallBack()
    {
        pnlWaitCallBack.SetActive(true);
    }

    #endregion
}
