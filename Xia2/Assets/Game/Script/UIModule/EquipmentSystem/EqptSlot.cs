/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-14   WP      Initial version
 *      12-25   WP      取消类型判断，添加英雄图标、等级、品质
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 装备槽
/// </summary>
public class EqptSlot : MonoBehaviour
{
    //取消类型判断
    //public enum EqptSlotType
    //{
    //    E_WEAPON = 1,//武器
    //    E_BODY = 2,  //胸甲
    //    E_LEG = 3,  //护腿
    //    E_HAND = 4,  //手套
    //    E_BOOT = 5,  //长靴
    //    E_CLOTHES = 6,//饰品
    //    E_All,//代表可以容纳所有类型
    //}

    /// <summary>
    /// 装备属性
    /// </summary>
    protected EquipmentItem item = null;

    protected HeroData heroData;

    //public EqptSlotType slotType = EqptSlotType.E_All;

    public UISprite icon;

    public UILabel labName;

    public UILabel labLevel;

    /// <summary>
    /// 外边框
    /// </summary>
    public UISprite frame;

    public UISprite sprHeroIcon;

    public UISprite sprQuality;

    public UILabel labPropsDesc;

    /// <summary>
    /// 更新当前的装备：若装备有变化的时候可以调用此函数
    /// </summary>
    public void Refresh()
    {
        Refresh(item, heroData);
    }

    /// <summary>
    /// 实例一个装备在上面
    /// </summary>
    /// <param name="data">可以是空</param>
    public virtual void Refresh(EquipmentItem data, HeroData hero = null)
    {
        heroData = hero;
        if (heroData != null)
        {
            if (sprHeroIcon) sprHeroIcon.spriteName = heroData.icon_middle;
        }
        Replace(data);
        //Debug.Log("Refresh this");
    }

    /// <summary>
    /// 换装
    /// </summary>
    /// <param name="data"></param>
    public virtual void Replace(EquipmentItem data)
    {
        item = data;
        //Debug.Log("Refresh this  item is null ? " + item == null);
        if (item != null)
        {

            if (icon)
            {
                icon.enabled = true;
                icon.spriteName = item.icon;
            }

            if (frame != null)
            {
                frame.spriteName = data.GetSprNameByQuality();
                frame.enabled = true;
            }

            if (labName != null) labName.text = item.name;
            if (labLevel != null) labLevel.text = item.equiplev + "级";

            //品质图标
            if (sprQuality) sprQuality.spriteName = data.GetQualitySprName();

        }
        else
        {
            if (icon) icon.enabled = false;
            if (frame != null)
            {
                frame.enabled = false;
            }
        }
    }

    void OnClick()
    {
        if (item != null)
        {

            //是否装备
            EqptCtrl.instance.BtnEquip(this);

            //英雄身上的装备 ----已取消
            //if (slotType != EqptSlotType.E_All && EqptPnlHero.instance && EqptPnlHero.instance.enabled)
            //{
            //    EqptPnlHero.instance.SetCurrentEquip(this);
            //}
        }
    }

    public EquipmentItem GetItem() { return item; }

    public long GetHeroGuid() { return heroData == null ? 0 : heroData.guid; }

    //public void SetPropsDesc(string desc)
    //{
    //    if (labPropsDesc)
    //    {
    //        labPropsDesc.text = desc;
    //    }
    //}

    /// <summary>
    /// 取属性名 例：  +3700 生命值
    /// </summary>
    public void SetPropsDesc()
    {
        if (labPropsDesc && item!= null)
        {
            labPropsDesc.text = item.proptys.GetDetailsByProps();
        }
    }
}