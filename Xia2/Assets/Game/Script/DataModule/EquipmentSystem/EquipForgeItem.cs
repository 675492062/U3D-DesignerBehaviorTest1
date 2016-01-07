/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-22   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 装备锻造表
/// </summary>
public class EquipForgeItem : BaseItem
{

    public EquipForgeItem(int formerid) { templateID = formerid; }

    public void Init(int formerid) { templateID = formerid; }

    private StaticEquip_forge_formula datas { get { return StaticEquip_forge_formula.Instance(); } }

    public int productid { get { return datas.getInt(templateID, "productid"); } }
    public int materialid1 { get { return datas.getInt(templateID, "materialid1"); } }
    public int num1 { get { return datas.getInt(templateID, "num1"); } }
    public int materialid2 { get { return datas.getInt(templateID, "materialid2"); } }
    public int num2 { get { return datas.getInt(templateID, "num2"); } }
    //public int materialid3 { get { return datas.getInt(templateID, "materialid3"); } }
    //public int num3 { get { return datas.getInt(templateID, "num3"); } }
    //public int materialid4 { get { return datas.getInt(templateID, "materialid4"); } }
    //public int num4 { get { return datas.getInt(templateID, "num4"); } }
    public int price { get { return datas.getInt(templateID, "price"); } }
    public int moneytype { get { return datas.getInt(templateID, "moneytype"); } }
    public int describe { get { return datas.getInt(templateID, "describe"); } }
    public int intensify_lost { get { return datas.getInt(templateID, "intensify_lost"); } }

    public int priceExtra { get { return datas.getInt(templateID, "price1"); } }
    public int moneytypeExtra { get { return datas.getInt(templateID, "moneytype1"); } }

    /// <summary>
    /// 取新装战斗力：TODO：
    /// </summary>
    /// <returns></returns>
    public int GetFC()
    {
        return 100;
    }

    /// <summary>
    /// 装备是否可以铸造
    /// </summary>
    /// <returns></returns>
    public bool CanForge()
    {
        //Debug.Log("---------------------   this forge item id is " + productid +  "   this tem id is : " + templateID);
        return productid > 0;
    }

    /// <summary>
    /// 普通锻造满足条件
    /// </summary>
    /// <returns></returns>
    public bool CanNormalForge()
    {
        bool has = false;
        if (moneytype == 1)
            has = DataTools.HasMoney(GlobalDef.MoneyType.MONEY_GOLD, price);
        else
            has = DataTools.HasMoney(GlobalDef.MoneyType.MONEY_DIAMOND, price);
        // mat count
        has = HasCountOfMats();

        return has;
    }

    private bool HasCountOfMats()
    {
        foreach (MaterialItem needMat in GetMaterials())
        {
            if (MonoInstancePool.getInstance<BagManager>().getBagByType((int)GlobalDef.BagType.B_MATERIAL).getItemNumbyTempID(needMat.templateID) >= needMat.number)
            {

            }
            else return false;
        }
        return true;
    }

    /// <summary>
    /// 高级强化满足条件
    /// </summary>
    /// <returns></returns>
    public bool CanHighForge()
    {
        bool has = CanNormalForge();
        if (moneytypeExtra == 1)
            has = DataTools.HasMoney(GlobalDef.MoneyType.MONEY_GOLD, priceExtra);
        else
            has = DataTools.HasMoney(GlobalDef.MoneyType.MONEY_DIAMOND, priceExtra);
        return has;
    }

    public List<MaterialItem> GetMaterials()
    {
        List<MaterialItem> items = new List<MaterialItem>();
        if (materialid1 > 0 && num1 > 0)
        {
            items.Add(new MaterialItem(materialid1, num1));
        }
        if (materialid2 > 0 && num2 > 0)
        {
            items.Add(new MaterialItem(materialid2, num2));
        }
        //if (materialid3 > 0 && num3 > 0)
        //{
        //    items.Add(new MaterialItem(materialid3, num3));
        //}
        //if (materialid4 > 0 && num4 > 0)
        //{
        //    items.Add(new MaterialItem(materialid4, num4));
        //}
        return items;
    }

    public int NeedLvByEquip()
    {
        if (productid > 0)
        {
            return StaticEquipment.Instance().getInt(productid, "needlv");
        }
        return 0;
    }

    /// <summary>
    /// 玩家是否可以穿上新装备
    /// </summary>
    /// <param name="heroLevel"></param>
    /// <returns></returns>
    public bool CanPutOnEquip(int heroLevel)
    {
        return heroLevel > NeedLvByEquip();
    }
}
