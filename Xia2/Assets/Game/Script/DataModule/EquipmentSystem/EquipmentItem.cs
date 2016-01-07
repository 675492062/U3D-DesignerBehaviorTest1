/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-??-??   ??      Initial version
 * 2014-10      WP      Update Params ,Added methods
 *      12-25   WP      改为只有一种强化方式
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EquipmentItem : BaseItem
{
    public EquipmentItem() { }

    public virtual void parseData(Property.Equip data)
    {
        guid = (long)data.guid;
        templateID = (int)data.templateid;
        haveNum = 1;
        //equipExp = (int)data.intensifyExp;
        equiplev = (int)data.intensifyLevel;
        changeStar = (int)data.star;

        proptys = new EquipProperty(this);
        isDirty = true;
        proptys.Refresh(equiplev);
    }

    public void Refresh()
    {
        if (isDirty)
        {
            proptys.Refresh(equiplev);
            isDirty = false;
        }
    }



    public int equiplev { get; set; }       //装备强化等级
    //public int equipExp { get; set; }       //装备强化所需经验
    public int changeStar { get; set; }

    /// <summary>
    /// 属性值
    /// </summary>
    public EquipProperty proptys;
    /// <summary>
    /// 宝石列表
    /// </summary>
    public Dictionary<long, DiamondItem> gemList = new Dictionary<long, DiamondItem>();//

    public void addDiamonItem(long guid, DiamondItem item)
    {
        if (gemList.ContainsKey(guid))
        {
            Debug.LogError("already has this key! guid: " + guid);
            return;
        }
        gemList.Add(guid, item);
    }

    public string getItemType()
    {
        int type = equitype;
        string str = "";
        switch (type)
        {
            case (int)GlobalDef.EquipmentTpye.E_WEAPON:
                str = "武器";
                break;
            case (int)GlobalDef.EquipmentTpye.E_BODY:
                str = "胸甲";
                break;
            case (int)GlobalDef.EquipmentTpye.E_LEG:
                str = "护腿";
                break;
            case (int)GlobalDef.EquipmentTpye.E_HAND:
                str = "手套";
                break;
            case (int)GlobalDef.EquipmentTpye.E_BOOT:
                str = "长靴";
                break;
            case (int)GlobalDef.EquipmentTpye.E_CLOTHES:
                str = "时装";
                break;
        }
        return str;
    }
    public string getItemQuality()
    {
        int q = quality;
        string str = "";
        switch (q)
        {
            case (int)GlobalDef.EquipQuality.Q_NORMAL://普通
                str = "普通";
                break;
            case (int)GlobalDef.EquipQuality.Q_EXCELLENCE://优秀
                str = "优秀";
                break;
            case (int)GlobalDef.EquipQuality.Q_EXCELLENT://精良
                str = "精良";
                break;
            case (int)GlobalDef.EquipQuality.Q_EPIC://史诗
                str = "史诗";
                break;
            case (int)GlobalDef.EquipQuality.Q_STORY://传说
                str = "传说";
                break;
            case (int)GlobalDef.EquipQuality.Q_IMMORTAL://不朽
                str = "不朽";
                break;
            case (int)GlobalDef.EquipQuality.Q_ARTIFACT://神器
                str = "神器";
                break;
            case (int)GlobalDef.EquipQuality.Q_GOD://逆天
                str = "逆天";
                break;
        }
        return str;
    }

    /// <summary>
    /// 取武器类型
    /// </summary>
    /// <returns></returns>
    public string getRoleLimit()
    {
        int subType = needrole;
        string str = "";
        switch (subType)
        {
            case (int)GlobalDef.EquipNeedRoleType.E_KNIFE:       //刀类
                str = "刀";
                break;
            case (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE:    //双刀类
                str = "双刀";
                break;
            case (int)GlobalDef.EquipNeedRoleType.E_LONGKNIFE:   //长柄利器类
                str = "长柄利器";
                break;
            case (int)GlobalDef.EquipNeedRoleType.E_LONGWEAPON:  //长柄类
                str = "长柄";
                break;
            case (int)GlobalDef.EquipNeedRoleType.E_LONGDISTANCE://远程类
                str = "远程";
                break;
            case (int)GlobalDef.EquipNeedRoleType.E_MAGE:        //法师类
                str = "法师";
                break;
        }
        return str;
    }
	/// <summary>
	/// 获取品质边框的图片名字
	/// </summary>
	public string getQualityBoundImgName()
	{
		string icon_img = "";
		switch (quality)
		{
		case (int)GlobalDef.EquipQuality.Q_NORMAL://普通
			icon_img = "common_21";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENCE://优秀
			icon_img = "common_22";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENT://精良
			icon_img = "common_23";
			break;
		case (int)GlobalDef.EquipQuality.Q_EPIC://史诗
			icon_img = "common_24";
			break;
		case (int)GlobalDef.EquipQuality.Q_STORY://传说
			icon_img = "common_25";
			break;
		case (int)GlobalDef.EquipQuality.Q_IMMORTAL://不朽
			icon_img = "common_25";
			break;
		case (int)GlobalDef.EquipQuality.Q_ARTIFACT://神器
			icon_img = "common_25";
			break;
		case (int)GlobalDef.EquipQuality.Q_GOD://逆天
			icon_img = "common_25";
			break;
		}
		return icon_img;
	}
	/// <summary>
	/// 获取品质图标的图片名字
	/// </summary>
	public string getQualityIconImgName()
	{
		string icon_img = "";
		switch (quality)
		{
		case (int)GlobalDef.EquipQuality.Q_NORMAL://普通
			icon_img = "common_21_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENCE://优秀
			icon_img = "common_22_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENT://精良
			icon_img = "common_23_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_EPIC://史诗
			icon_img = "common_24_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_STORY://传说
			icon_img = "common_25_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_IMMORTAL://不朽
			icon_img = "common_25_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_ARTIFACT://神器
			icon_img = "common_25_0";
			break;
		case (int)GlobalDef.EquipQuality.Q_GOD://逆天
			icon_img = "common_25_0";
			break;
		}
		return icon_img;
	}

    #region enhance info

    //强化金币
    public int GetMoneyEnhance()
    {
        return StaticEquip_intensify.Instance().getInt(1, "price");
    }

    /// <summary>
    /// 强化
    /// </summary>
    /// <returns>升级时返回True</returns>
    public bool EnhanceEquip()
    {
        if (DataTools.HasMoney(GlobalDef.MoneyType.MONEY_GOLD, GetMoneyEnhance()))
        {
            DataTools.SubMoney(GlobalDef.MoneyType.MONEY_GOLD, GetMoneyEnhance());
            equiplev++;
            isDirty = true;
            Refresh();
            return true;
        }
        return false;
    }

    #endregion

    public bool IsMaxLevel()
    {
        //TODO:
        return equiplev >= 80;
    }

    /// <summary>
    /// 获得离装备升级的EXP百分比
    /// </summary>
    /// <returns></returns>
    //public float GetPercentExp()
    //{
    //    float percent = 0;
    //    percent = equipExp * 1.0f / infoExp.exp;
    //    return percent;
    //}

    /// <summary>
    /// 根据品质返回品质框的Sprite Name
    /// </summary>
    /// <returns></returns>
    public string GetSprNameByQuality()
    {
        string sprN = "common_2"+ quality;
        //switch (quality)
        //{ 
        //    case 1:
        //        break;

        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    case 5:
        //        break;
        //}
        return sprN;
    }

    /// <summary>
    /// 取品质图标名字
    /// </summary>
    /// <returns></returns>
    public string GetQualitySprName()
    {
        return GetSprNameByQuality() + "_0";
    }

    #region table param

    private StaticEquipment datas { get { return StaticEquipment.Instance(); } }

    public string icon { get { return datas.getStr(templateID, "icon"); } }
    public int type { get { return datas.getInt(templateID, "type"); } }
    public string name { get { return datas.getStr(templateID, "name"); } }
    public string resname { get { return datas.getStr(templateID, "resname"); } }
    /// <summary>
    /// 部件id 1=武器 2=胸甲 3=护腿 4=手套  5=靴子 6=视频
    /// </summary>
    public int equitype { get { return datas.getInt(templateID, "equitype"); } }
    public int needrole { get { return datas.getInt(templateID, "needrole"); } }
    public int needlv { get { return datas.getInt(templateID, "needlv"); } }
    /// <summary>
    /// 装备品质 ："装备品质1=白色  2=绿色  3=蓝色  4=紫色  5=橙色"
    /// </summary>
    public int quality { get { return datas.getInt(templateID, "quality"); } }
    public int maxcount { get { return datas.getInt(templateID, "maxcount"); } }
    public int mindamage { get { return datas.getInt(templateID, "mindamage"); } }
    public int maxdamage { get { return datas.getInt(templateID, "maxdamage"); } }
    public int atkspeed { get { return datas.getInt(templateID, "atkspeed"); } }
    public int gholecolor1 { get { return datas.getInt(templateID, "gholecolor1"); } }
    public int gholestar1 { get { return datas.getInt(templateID, "gholestar1"); } }
    public int gholecolor2 { get { return datas.getInt(templateID, "gholecolor2"); } }
    public int gholestar2 { get { return datas.getInt(templateID, "gholestar2"); } }
    public int gattributeid { get { return datas.getInt(templateID, "gattributeid"); } }
    public int gattribute { get { return datas.getInt(templateID, "gattribute"); } }
    public int legendstar { get { return datas.getInt(templateID, "legendstar"); } }
    public int skillid { get { return datas.getInt(templateID, "skillid"); } }
    public int skillstar { get { return datas.getInt(templateID, "skillstar"); } }
    public int skilltarget { get { return datas.getInt(templateID, "skilltarget"); } }
    public int skilldelta { get { return datas.getInt(templateID, "skilldelta"); } }
    public int sellprice1 { get { return datas.getInt(templateID, "sellprice1"); } }
    public int sellprice2 { get { return datas.getInt(templateID, "sellprice2"); } }
    public string description { get { return datas.getStr(templateID, "description"); } }

    /// <summary>
    /// 非武器基础属性类型
    /// </summary>
    public int base_attribute_type { get { return datas.getInt(templateID, "base_attribute_type"); } }
    public int base_attribute_int { get { return datas.getInt(templateID, "base_attribute_int"); } }

    public int quality_attribute_id1 { get { return datas.getInt(templateID, "quality_attribute_id1"); } }
    public int quality_attribute_id2 { get { return datas.getInt(templateID, "quality_attribute_id2"); } }
    public int quality_attribute_id3 { get { return datas.getInt(templateID, "quality_attribute_id3"); } }
    public int quality_attribute_id4 { get { return datas.getInt(templateID, "quality_attribute_id4"); } }

    public int formerid { get { return datas.getInt(templateID, "formerid"); } }
    public int smeltid { get { return datas.getInt(templateID, "smeltid"); } }

    private EquipIEItem mEquipIEItem;
    /// <summary>
    /// 强化所exp记录
    /// </summary>
    public EquipIEItem infoExp
    {
        get
        {
            if (mEquipIEItem == null) mEquipIEItem = new EquipIEItem();
            mEquipIEItem.parseData(equiplev);
            return mEquipIEItem;
        }
    }

    private EquipSmeltItem mEquipSmeltItem;
    public EquipSmeltItem infoSmelt
    {
        get
        {
            if (mEquipSmeltItem == null) mEquipSmeltItem = new EquipSmeltItem(smeltid);
            if (mEquipSmeltItem.templateID != smeltid) mEquipSmeltItem.Init(smeltid);
            return mEquipSmeltItem;
        }
    }

    private EquipForgeItem mEquipForgeItem;
    public EquipForgeItem infoForge
    {
        get
        {
            if (mEquipForgeItem == null) mEquipForgeItem = new EquipForgeItem(formerid);
            if (mEquipForgeItem.templateID != formerid) mEquipForgeItem.Init(formerid);
            return mEquipForgeItem;
        }
    }

    #endregion

}