/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-14   WP      Initial version
 * 2014-12-25   WP      新版本取消强化进度条，取消高级强化与低级强化
 *                      装备详情改在主面板显示
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

//public enum EnhanceType
//{
//    HighEnhance, //高级强化
//    LowerEnhance
//}

/// <summary>
/// 强化面板
/// </summary>
public class EqptPanelEnhance : EqptPanel
{
    #region public GameObject

    public EqptSlot slot;

    /// <summary>
    ///  装备名称 +4
    /// </summary>
    public UILabel labNameAndLevel;
    public Color clrLevel = Color.green;

    /// <summary>
    /// 战斗力
    /// </summary>
    public UILabel labFightingCapacity;

    /// <summary>
    /// 装备品质
    /// </summary>
    //public UILabel labEquipQuality;

    public UILabel labCurrentLevel;

    public UILabel labNextLevel;

    /// <summary>
    /// 装备非满级显示对象
    /// </summary>
    public GameObject goNotFull;
    /// <summary>
    /// 装备满级显示对象
    /// </summary>
    public GameObject goFull;

    //public UIGrid grdPreE;

    //public UIGrid grdBrfE;

    //public UIKeyNValue pfbPreEnhance;

    //public UIKeyNValue pfbBrfEnhance;

    public UILabel labPropsDesc;

    /// <summary>
    /// 强化消费钱
    /// </summary>
    public UILabel labMonery;

    #endregion

    /// <summary>
    /// 是否是角色装备的ID
    /// </summary>
    //private ulong hero_guid = 0;

    public static EqptPanelEnhance instance;

    void Awake() { instance = this; }

    void OnEnable()
    {
        //InitLocalSlot();
        Refresh();

        //delUpdateSlider = null;
        if (currentEquip.isDirty)
        {
            currentEquip.Refresh();
            RefreshPanel(currentEquip);
        }
    }

    //public override void OnEquipClick(EqptSlot s, ulong hero_guid = 0)
    //{
    //    if (s == localSlot || s.GetItem() == null) return;
    //    localSlot = s;

    //    this.hero_guid = hero_guid;

    //    if (currentEquip.isDirty)
    //    {
    //        currentEquip.Refresh();
    //    }
    //    RefreshPanel(currentEquip);
    //}

    public override void Refresh()
    {
        RefreshPanel(currentEquip);
    }

    public void BtnEnhanceEvent()
    {
        if (currentEquip.EnhanceEquip())
        {
            EqptCtrl.instance.EnhanceEvent();
        }
        else NotMoney(GlobalDef.MoneyType.MONEY_GOLD);
    }

    void NotMoney(GlobalDef.MoneyType tp)
    {
        Debug.Log("not money type is : " + tp.ToString());
    }

    #region update state

    void RefreshPanel(EquipmentItem item, bool ChangeSlider = true)
    {
        //foreach (Transform t in grdBrfE.transform) Destroy(t.gameObject);
        //foreach (Transform t in grdPreE.transform) Destroy(t.gameObject);

        Debug.Log("Refresh this");
        slot.Refresh(item);

        if (item != null)
        {
            //Debug.Log(item.icon);
            SetNameAndLevel(item.name, item.equiplev);
            SetFightingCapacity(item.proptys.fightingCapacity);

            bool isFullLevel = item.IsMaxLevel();
            goNotFull.SetActive(!isFullLevel);
            goFull.SetActive(isFullLevel);

            if (!isFullLevel)
            {
                List<string> names = new List<string>();
                List<int> values = new List<int>();
                List<int> incts = new List<int>();
                item.proptys.GetCountByInct(out names, out values, out incts);

                //SetPropertysInGrid(names, values, incts);
                labPropsDesc.text = lastSlot.GetItem().proptys.GetInctByProps();

                SetEnhanceMoney(item.GetMoneyEnhance());

            }
        }
        else
        {
            labNameAndLevel.text = "";
            labCurrentLevel.text = "";
            labNextLevel.text = "";
            labFightingCapacity.text = "";
            labMonery.text = "";
        }
    }

    void SetNameAndLevel(string name, int level)
    {
        labNameAndLevel.text = name + UITools.AddColorToText(clrLevel, " +" + level);
        labCurrentLevel.text = level.ToString();
        labNextLevel.text = "+" + (level + 1) + "";
    }

    void SetFightingCapacity(int fightingCapacity)
    {
        labFightingCapacity.text = AllStrings.fightingCapacity + ":" + fightingCapacity;
    }

    //void SetPropertysInGrid(List<string> names, List<int> defaults, List<int> incts)
    //{
    //    for (int i = 0; i < names.Count; i++)
    //    {
    //        //UIKeyNValue cur = KMTools.AddChild<UIKeyNValue>(grdPreE.gameObject, pfbPreEnhance);
    //        //cur.key.text = names[i];
    //        //cur.value.text = defaults[i] + "";

    //        UIKeyNValue next = KMTools.AddChild<UIKeyNValue>(grdBrfE.gameObject, pfbBrfEnhance);
    //        next.key.text = names[i];
    //        next.value.text = defaults[i] + "";
    //        next.value.text += UITools.AddColorToText(Color.green, " +" + incts[i]);
    //    }

    //}


    void SetEnhanceMoney(int Money)
    {
        labMonery.text = "" + Money;
    }

    #endregion
}
