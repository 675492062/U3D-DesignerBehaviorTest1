/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-17   WP      Initial version
 * 2014-12-25   WP      系统改版： 与背包合并     
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 英雄面板
/// </summary>
public class EqptPnlHero : MonoBehaviour
{
    public EqptHero prbHero;
    public UITable tblHero;

    private bool isInit = false;
    private List<EqptHero> heros = new List<EqptHero>();

    /// <summary>
    /// 当前英雄身上的装备槽
    /// </summary>
    private EqptSlot currentEqptSlot;

    private bool isRefresh = false;

    public static EqptPnlHero instance;

    void Awake() { instance = this; }

    void Init()
    {
        if (isInit) return;
        isInit = true; isRefresh = true;
        foreach (Transform t in tblHero.transform)
        {
            Destroy(t.gameObject);
        }

        Dictionary<long, HeroData> mHeroDict = MonoInstancePool.getInstance<HeroManager>().getHeroDict();
        if (mHeroDict.Count == 0)
        {
            Debug.LogError("No hero ！！！");
        }
        for (int i = 0; i < mHeroDict.Count; i++)
        {
            HeroData data = mHeroDict.ElementAt(i).Value;
            EqptHero hero = KMTools.AddChild<EqptHero>(tblHero.gameObject, prbHero);
            hero.Init(data);
            heros.Add(hero);
        }

        InvokeUpdateGrid();
        Invoke("InvokeUpdateGrid", 0.001f);
    }

    void InvokeUpdateGrid()
    {
        tblHero.repositionNow = true;
    }

    void OnEnable()
    {
        if (!isInit) Init();
        else if (!isRefresh)
        {
            isRefresh = true;
            foreach (EqptHero h in heros) { h.RefreshBag(); }
        }
        tblHero.repositionNow = true;
    }

    public void CollapseHeros(EqptHero curHero)
    {
        foreach (EqptHero h in heros)
        {
            if (curHero != h) { h.Collapse(); }
        }
    }

    public void RefreshCurrentSlot(EquipmentItem it)
    {
        if (currentEqptSlot != null)
        {
            currentEqptSlot.Replace(it);
        }
    }

    public void SetCurrentEquip(EqptSlot slot)
    {
        currentEqptSlot = slot;
    }

    public void SetRefresh()
    {
        isRefresh = false;
    }

    public List<EqptHero> GetHeros() { if (!isInit) Init(); return heros; }
}
