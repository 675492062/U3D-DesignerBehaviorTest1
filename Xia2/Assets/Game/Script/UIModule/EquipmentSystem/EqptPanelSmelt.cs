/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-14   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 熔炼面板（分解）
/// </summary>
public class EqptPanelSmelt : EqptPanel
{
    public static EqptPanelSmelt instance;

    /// <summary>
    /// 当前面板里面的5个装备槽
    /// </summary>
    public List<EqptSmeltSlot> slots = new List<EqptSmeltSlot>();

    public List<MTLSlot> mtlSlots = new List<MTLSlot>();

    public GameObject pnlCallBack;

    public GameObject pnlTipQuality;

    public List<MTLSlot> mtlSlotsByCallBack = new List<MTLSlot>();

    public UIGrid grdSmeltSlot;

    public EqptSmeltSlot prbSmeltSlot;

    /// <summary>
    /// 当前已选装备槽
    /// </summary>
    private List<EqptSlot> curSelSlots = new List<EqptSlot>();

    private List<EquipmentItem> mCurEquipItems = new List<EquipmentItem>();
    /// <summary>
    /// 当前已选物品
    /// </summary>
    private List<EquipmentItem> curEquipItems
    {
        get 
        {
            if (mCurEquipItems.Count != curSelSlots.Count)
            {
                mCurEquipItems.Clear();
                for (int i = 0; i < curSelSlots.Count; i++) mCurEquipItems.Add(curSelSlots[i].GetItem());
            }
            return mCurEquipItems;
        }
    }

    private List<int> mtlIds = new List<int>();

    private bool isRefresh = false;

    void Awake() { instance = this; }

    void OnEnable()
    {
        if (!isRefresh) Refresh();
    }

    //public override void OnEquipClick(EqptSlot s, ulong hero_guid = 0)
    //{
    //    EquipmentItem item = s.GetItem();
    //    if (curEquipItems.Contains(item))
    //    {
    //        foreach (EqptSmeltSlot sl in slots) { if (sl.GetItem() == item) { sl.ShowByTarget(null); } }
    //        RemoveEquipSlot(s);
    //    }
    //    else
    //    {
    //        //Debug.Log("AddItem");
    //        localSlot = s;
    //        if (IsFullForAddSlot(s))
    //        {
    //            RefreshMatItem();
    //        }
    //        else
    //        {
    //            Debug.Log("TODO：是否替换一个");
    //        }
    //    }
    //}

    /// <summary>
    /// 服务器返回清空
    /// </summary>
    public override void Refresh()
    {
        if (isRefresh) return;
        else
        {
            isRefresh = true;
            foreach (MTLSlot slot in mtlSlots)
            {
                slot.Refresh(null);
            }
            foreach (EqptSmeltSlot s in slots)
            {
                s.ShowByTarget(null);
            }
            curSelSlots.Clear();
        }
    }

    /// <summary>
    /// 当点击面板里面的装备
    /// </summary>
    /// <param name="item"></param>
    public void BtnEquipInPanel(EqptSlot s)
    {
        RemoveEquipSlot(s);
    }

    /// <summary>
    /// 自动添加
    /// </summary>
    public void BtnAutoAddItem()
    {
        List<EqptSlot> bagSlots = EqptCtrl.instance.pnlBag.GetSlots();

        for (int i = 0; i < bagSlots.Count; i++)
        {
            EquipmentItem item = bagSlots[i].GetItem();
            //Debug.Log("----------------------" + item.guid);
            if (item != null)
            {
                if (!item.proptys.IsHighQuality())
                {
                    if (curEquipItems.Contains(item)) continue;
                    //设置一下当前的格子
                    //localSlot = bagSlots[i];
                    if (IsFullForAddSlot(bagSlots[i])) { }
                    else break;
                }
            }
        }

        RefreshMatItem();
    }

    public void BtnSmelting()
    {
        if (curEquipItems.Count == 0) return;

        List<ulong> list = new List<ulong>();
        for (int i = 0; i < curEquipItems.Count; i++)
        {
            list.Add((ulong)curEquipItems[i].guid);
        }
        EqptCtrl.instance.SmeltingEvent(list);
    }

    public void CheckEquipQuality()
    {
        if (curEquipItems.Count == 0) return;

        bool isQuality = false;

        List<EquipmentItem> highItems = new List<EquipmentItem>();
        for (int i = 0; i < curEquipItems.Count; i++)
        {
            if (curEquipItems[i].proptys.IsHighQuality())
            {
                highItems.Add(curEquipItems[i]);
                isQuality = true;
            }
        }

        if (isQuality)
        {
            //提示高品质武器
            pnlTipQuality.SetActive(true);
            foreach (Transform t in grdSmeltSlot.transform)
            {
                Destroy(t.gameObject);
            }

            for (int i = 0; i < highItems.Count; i++)
            {
                EqptSmeltSlot desc = KMTools.AddChild<EqptSmeltSlot>(grdSmeltSlot.gameObject, prbSmeltSlot);
                desc.Replace(highItems[i]);
            }

            InvokeUpateGrid();
            Invoke("InvokeUpateGrid", 0.001f);
        }
        else
        {
            BtnSmelting();
        }

        //grdSmeltSlot.repositionNow = true;
    }

    void InvokeUpateGrid()
    {
        grdSmeltSlot.repositionNow = true;
    }

    public void SmeltingCallBack(List<MaterialItem> items)
    {
        pnlCallBack.SetActive(true);
        int iMax = Mathf.Min(items.Count, mtlSlotsByCallBack.Count);
        foreach (MTLSlot slot in mtlSlotsByCallBack)
        {
            slot.Refresh(null);
        }
        for (int i = 0; i < iMax; i++)
        {
            mtlSlotsByCallBack[i].Refresh(items[i]);
        }

        //remote item in bag
        BagStruct bag = MonoInstancePool.getInstance<BagManager>().getEquipmentBag();

        for (int i = 0; i < curEquipItems.Count; i++)
        {
            bag.removeItem(curEquipItems[i].guid);
        }
        
        EqptPanelEnhance pnlEnhance  = EqptPanelEnhance.instance;
        EqptPanelForge pnlForge = EqptPanelForge.instance;
        //检查别的面板 TODO 已注释
        foreach (EqptSlot s in curSelSlots)
        {
            //if (pnlEnhance && pnlEnhance.IsLocalSlot(s)) { pnlEnhance.ReSetLocalSlot(); }
            //if (pnlForge && pnlForge.IsLocalSlot(s)) { pnlForge.ReSetLocalSlot(); }
        }

        //refresh main panel
        isRefresh = false;
        Refresh();
    }

    /// <summary>
    /// 往装备槽里添加装备： 不会重复判断： 返回false的时候，代表 装备已经填满了
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    bool IsFullForAddSlot(EqptSlot s)
    {
        EquipmentItem item = s.GetItem();
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsEmpty())
            {
                slots[i].ShowByTarget(s);
                curSelSlots.Add(s);
                return true;
            }
        }
        return false;
    }

    void RemoveEquipSlot(EqptSlot s)
    {
        if (curSelSlots.Contains(s))
        {
            curSelSlots.Remove(s);
        }
        RefreshMatItem();
    }

    void RefreshMatItem()
    {
        List<int> newIds = new List<int>();
        foreach (EquipmentItem i in curEquipItems)
        {
            foreach (int id in i.infoSmelt.GetMaterialIds())
            {
                if (!newIds.Contains(id)) newIds.Add(id);
            }
        }

        mtlIds.Sort();
        newIds.Sort();

        bool isRefresh = false;
        if (mtlIds.Count != newIds.Count)
        {
            isRefresh = true;
        }
        else
        {
            for (int i = 0; i < mtlIds.Count; i++)
            {
                if (mtlIds[i] != newIds[i]) isRefresh = true;
            }
        }

        if (isRefresh)
        {
            foreach (MTLSlot slot in mtlSlots)
            {
                slot.Refresh(null);
            }
            int iMax = Mathf.Min(mtlSlots.Count, newIds.Count);

            for (int i = 0; i < iMax; i++)
            {
                MaterialItem item = new MaterialItem();
                item.parseData(newIds[i]);
                mtlSlots[i].Refresh(item);
            }
            mtlIds = newIds;
            //Debug.Log("==============Additem" + newIds.Count);
        }
    }

    public void SetRefresh()
    {
        isRefresh = false;
    }
}
