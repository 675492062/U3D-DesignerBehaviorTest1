/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-17   WP      Initial version
 * 2014-12-25   WP      系统改版：
 *                      1.所有装备将一同显示在面板内
 *                      2.装备面板显示方法出现在更上面的管理者内
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 装备介面的背包
/// </summary>
public class EqptPnlBag : MonoBehaviour
{
    public UIGrid grdBag;
    public EqptSlot prbEquipSlot;

    /// <summary>
    /// 当前物品选择框
    /// </summary>
    public GameObject goSelected
    {
        get
        {
            if (mGoSelected == null)
            {
                mGoSelected = KMTools.AddGameObj(EqptCtrl.instance.GetCurrentSlot().gameObject, prbSelect, true);
            }
            return mGoSelected;
        }
    }

    private GameObject mGoSelected;

    public GameObject prbSelect;

    private bool isInit = false;

    private Dictionary<long, BaseItem> bagDict;

    private Dictionary<long, HeroData> heroDict;

    private List<EqptSlot> slotList = new List<EqptSlot>();

    void Init()
    {
        if (isInit) return;
        isInit = true;

        foreach (Transform t in grdBag.transform)
        {
            Destroy(t.gameObject);
        }

        int index = 0;

        //更新英雄身上的装备
        heroDict = MonoInstancePool.getInstance<HeroManager>().getHeroDict();

        for (int i = 0; i < heroDict.Count; i++)
        {
            HeroData data = heroDict.ElementAt(i).Value;
            EquipmentList list = data.equipmentList;

            for (int j = 1; j < 7; j++)
            {
                if (list.hasThisType(j))
                {
                    EqptSlot slot = KMTools.AddChild<EqptSlot>(grdBag.gameObject, prbEquipSlot);
                    slot.Refresh(list.getItemByType(j), data);
                    slot.gameObject.name = "Slot" + index++;
                    slotList.Add(slot);
                }
            }

        }

        //更新背包里的装备
        bagDict = MonoInstancePool.getInstance<BagManager>().getEquipmentBag().GetDict();

        for (int i = 0; i < bagDict.Count; i++)
        {
            BaseItem item = bagDict.ElementAt(i).Value;
            //Debug.Log("----------------------" + item.guid);
            if (item is EquipmentItem)
            {
                EqptSlot slot = KMTools.AddChild<EqptSlot>(grdBag.gameObject, prbEquipSlot);
                slot.gameObject.name = "Slot" + index++;
                slotList.Add(slot);
                EquipmentItem eItem = item as EquipmentItem;
                slot.Refresh(eItem);
            }
        }

        grdBag.repositionNow = true;

        Debug.Log("-----bag init finished ");
        Invoke("InvokeUpdateTable", .1f);
    }

    void InvokeUpdateTable()
    {
        grdBag.repositionNow = true;
        //SetSelectObj(EqptCtrl.instance.GetCurrentSlot().transform);
    }

    public void Refresh()
    {
        foreach (EqptSlot slot in slotList)
        {
            slot.Refresh();
        }
    }

    void OnEnable()
    {
        Debug.Log("----------OnEnable"); 
        if (!isInit) Init();
    }

    public void SetRefresh()
    {
        isInit = false;
        Debug.Log("----------Set refresh"); 
        //SetSelectObj(EqptCtrl.instance.GetCurrentSlot().transform);
    }

    /// <summary>
    /// 取玩家所有的装备
    /// </summary>
    /// <returns></returns>
    public List<EqptSlot> GetSlots() { if (!isInit) Init(); return slotList; }

    public void SetSelectObj(Transform parent)
    {
        if (goSelected)
        {
            goSelected.transform.parent = parent;
            goSelected.transform.localPosition = Vector3.zero;
            goSelected.transform.localScale = Vector3.one;
        }

        //Debug.Log("set select ", goSelected);
    }
}
