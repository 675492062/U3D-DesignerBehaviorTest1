/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-14   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 锻造介面
/// </summary>
public class EqptPanelForge : EqptPanel
{
    const string GOLD = "hb_24";
    const string DIAMAGE = "hb_25";

    public EqptForgeSlot curSlotInPnl;

    public EqptForgeSlot newSlotInPnl;

    public List<MTLSlotInForge> mtlSlots = new List<MTLSlotInForge>();

    public UILabel labNeedCost;
    public UISprite sprNeedMoney;

    public UILabel labExtraCost;
    public UISprite sprExtraMoney;

    /// <summary>
    /// 战斗力
    /// </summary>
    public UILabel labFightingCapacity;

    public UILabel labNeedLevel;

    private EquipForgeItem infoForge { get { return currentEquip.infoForge; } }

    public GameObject goNoFull;
    public GameObject goFull;

    public EquipItemUI uiEquipItem;

    public static EqptPanelForge instance;

    void Awake() { instance = this; }

    void SetFightingCapacity(int fightingCapacity)
    {
        labFightingCapacity.text = AllStrings.fightingCapacity + ":" + fightingCapacity;
    }

    //public override void OnEquipClick(EqptSlot s, ulong hero_guid = 0)
    //{
    //    if (s == localSlot || s.GetItem() == null) return;
    //    localSlot = s;

    //    this.hero_guid = hero_guid;

    //    Refresh();

    //}

    public override void Refresh()
    {
        if (currentEquip == null)
        {
            curSlotInPnl.Refresh(null);
            Debug.LogError("null");
        }
        else
        {
            curSlotInPnl.Refresh(currentEquip);

            if (infoForge.CanForge())
            {
                goNoFull.SetActive(true);
                goFull.SetActive(false);


                //new item
                EquipmentItem newItem = new EquipmentItem();
                newItem.templateID = infoForge.productid;
                newSlotInPnl.Refresh(newItem);

                labNeedCost.text = infoForge.price.ToString();
                if (infoForge.moneytype == 1) //gold
                {
                    sprNeedMoney.spriteName = GOLD;
                }
                else
                {
                    sprNeedMoney.spriteName = DIAMAGE;
                }


                labExtraCost.text = infoForge.priceExtra.ToString();
                if (infoForge.moneytypeExtra == 1)
                {
                    sprExtraMoney.spriteName = GOLD;
                }
                else
                {
                    sprExtraMoney.spriteName = DIAMAGE;
                }
                labFightingCapacity.text = AllStrings.fightingCapacity + " : " + infoForge.GetFC();
                labNeedLevel.text = AllStrings.needLevel + "Lv." + infoForge.NeedLvByEquip();

                List<MaterialItem> items = infoForge.GetMaterials();
                int iMax = Mathf.Min(mtlSlots.Count, items.Count);
                for (int i = 0; i < iMax; i++)
                {
                    mtlSlots[i].Refresh(items[i]);
                }
            }
            else
            {
                goNoFull.SetActive(false);
                goFull.SetActive(true);

                for (int i = 0; i < mtlSlots.Count; i++)
                {
                    mtlSlots[i].Refresh(null);
                }

                newSlotInPnl.Refresh(null);
            }
        }
    }

    public void BtnForge()
    {
        if (goFull.activeSelf) return;

        long hero_guid = lastSlot.GetHeroGuid();

        if (infoForge.CanNormalForge())
        {
            if (hero_guid != 0)
            {
                //Debug.Log("------------------------------------------" + hero_guid);
                int heroLv = MonoInstancePool.getInstance<HeroManager>().getHero(hero_guid).level;
                if (currentEquip.infoForge.CanPutOnEquip(heroLv))
                    EqptCtrl.instance.ForgingEvent(currentEquip, (ulong)hero_guid, false);
                else
                    Debug.Log("TODO: levels tip");
            }
            else
            {
                EqptCtrl.instance.ForgingEvent(currentEquip, (ulong)hero_guid, false);
            }
        }
        else
        {
            Debug.Log("TODO　money empty");
        }
    }

    public void BtnExtraForge()
    {
        if (goFull.activeSelf) return;

        long hero_guid = lastSlot.GetHeroGuid();

        if (infoForge.CanHighForge())
        {
            if (hero_guid != 0)
            {
                //TODO
                if (currentEquip.infoForge.CanPutOnEquip(MonoInstancePool.getInstance<HeroManager>().getHero(hero_guid).level))
                    EqptCtrl.instance.ForgingEvent(currentEquip, (ulong)hero_guid, false);
                else
                    Debug.Log("TODO: levels tip");
            }
            else
            {
                EqptCtrl.instance.ForgingEvent(currentEquip, (ulong)hero_guid, false);
            }
        }
        else
        {
            Debug.Log("TODO　money empty");
        }
    }

    public void CallBack(EquipmentItem item)
    {
        //清空：
        uiEquipItem.gameObject.SetActive(true);
        uiEquipItem.UpdateInfo(item);
        //currentEquip = item;
        Refresh();
    }


}
