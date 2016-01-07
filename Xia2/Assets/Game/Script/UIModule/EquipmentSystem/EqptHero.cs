/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-16   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 角色
/// </summary>
public class EqptHero : MonoBehaviour
{
    /// <summary>
    /// 英雄数据
    /// </summary>
    private HeroData data;
    const string starGrayName = "hb_21";
    const string starLightName = "hb_20";

    /// <summary>
    /// 角色装备
    /// </summary>
    public List<EqptSlot> slotList = new List<EqptSlot>();

    public UISprite heroIcon;

    public UILabel labName;
    public UILabel labLevel;

    public List<UISprite> sprStars = new List<UISprite>();

    public UIPlayTween playTwn;

    public UISprite sprCollapse;
    private bool isCollapse = true;

    public void Init(HeroData d)
    {
        data = d;
        InitEquipment();
        //SetCollapse(true);
        Refresh();
    }

    public void ToggleCollapse()
    {
        SetCollapse(isCollapse);
    }

    /// <summary>
    /// 设置折叠
    /// </summary>
    private void SetCollapse(bool isCollapse)
    {
        if (isCollapse)
        {
            //Debug.Log("open");
            EqptPnlHero.instance.CollapseHeros(this);
        }
        playTwn.Play(isCollapse);
        this.isCollapse = !isCollapse;
        SetCollapseSpr(this.isCollapse);
    }

    public void Collapse()
    {
        playTwn.Play(false);
        isCollapse = true;
        SetCollapseSpr(this.isCollapse);
    }

    void SetCollapseSpr(bool isCollapse)
    {
        sprCollapse.transform.localEulerAngles = new Vector3(0, 0, isCollapse ? 90 : -90);
    }

    public void RefreshBag()
    {
        EquipmentList list = data.equipmentList;
        for (int i = 1; i < 7; i++)
        {
            if (list.hasThisType(i))
            {
                slotList[i - 1].Refresh(list.getItemByType(i), data);
                //Debug.Log("-----------has equip the id is " + list.getItemByType(i).equitype + " this tp is " + i);
            }
            else slotList[i - 1].Refresh(null, data);
        }
    }

    void InitEquipment()
    {
        RefreshBag();
    }

    void Refresh()
    {
        if (data != null)
        {
            labName.text = data.name;
            labLevel.text = "Lv." + data.level;
            heroIcon.spriteName = data.icon;
            SetStars(data.starLevel);
        }
    }

    void SetStars(int count)
    {
        for (int i = 0; i < sprStars.Count; i++)
        {
            sprStars[i].spriteName = count > i ? starLightName : starGrayName;
        }
    }

    public HeroData GetHero() { return data; }
}
