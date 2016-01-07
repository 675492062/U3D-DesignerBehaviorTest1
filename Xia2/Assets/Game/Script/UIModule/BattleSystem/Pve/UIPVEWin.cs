using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;
using System.Linq;

/// <summary>
/// PVE战斗胜利统计
/// 
/// Maintaince Logs: 
/// 2014-11-26   WP      Initial version.
/// </summary>
public class UIPVEWin : MonoBehaviour
{
    public UIPVEFinishPanel m_BattleCensus { get { return UIPVEFinishPanel.instance; } }

    public UISprite[] m_statBox; //星级
    public UILabel m_scoreLabel;//评分

    public CommonSlot playerSlot;
    public CommonSlot m_heroButton;//副将
    public UIButton m_itemButton;//物品
    public UIButton[] m_scoreButton;//评分奖励

    public UIGrid grdHero;
    public UIGrid m_itemgrid;

    private List<CommonSlot> heroSlots = new List<CommonSlot>();
    private List<BattleStartHeroData> hisHeroData = new List<BattleStartHeroData>();
    private BattleStartPlayerData hisPlayerData;

    private float timePlayer = 0;
    private float timeHero = 0;

    private FightManager FM { get { return MonoInstancePool.getInstance<FightManager>(); } }
    private UserData UD { get { return MonoInstancePool.getInstance<UserData>(); } }

    private delegate void UpdateEvent();

    private UpdateEvent updateEvent;

    void Update()
    {
        if (updateEvent != null)
            foreach (UpdateEvent e in updateEvent.GetInvocationList())
            {
                e();
            }
    }

    public void Init()
    {
        SetPlayerExp();//设置统领经验条
        //TODO:
        SetStar(2);//设置星级
        SetLieutenant();//设置副将
        SetRewards();//设置物品掉落
    }


    //设置评分奖励
    public void SetScoreItem()
    {
        List<DropItem> award = MonoInstancePool.getInstance<FightManager>().boxItem;

        if (award.Count > m_scoreButton.Length)
            return;

        for (int i = 0; i < award.Count; i++)
        {
            m_scoreButton[i].gameObject.SetActive(true);
            OnClickSuccessList list = m_scoreButton[i].GetComponent<OnClickSuccessList>();
            DropItem item = award[i];
            string icon = ConfigManager.getInstance().getData(item.id, "icon");
            list.m_icon.spriteName = icon;
            list.m_mask.spriteName = "battcensus44";
        }
    }

    //设置物品奖励
    public void SetRewards()
    {
        List<DropItem> nomal = MonoInstancePool.getInstance<FightManager>().dropItems;

        for (int i = 0; i < nomal.Count; i++)
        {
            GameObject gos = NGUITools.AddChild(m_itemgrid.gameObject, m_itemButton.gameObject);
            OnClickSuccessList list = gos.GetComponent<OnClickSuccessList>();
            DropItem item = nomal[i];
            //TODO：其它物品的设定
            if (item.id == 1)
            {
                list.m_icon.spriteName = "battcensus45";
                list.m_mask.gameObject.SetActive(false);
                continue;
            }
            string icon = ConfigManager.getInstance().getData(item.id, "icon");

            list.m_icon.spriteName = icon;
            //list.m_mask.spriteName = "battcensus34";
            list.m_mask.gameObject.SetActive(false);
        }

        if (m_itemgrid != null)
            m_itemgrid.repositionNow = true;

        m_itemButton.gameObject.SetActive(false);
    }

    //设置副将经验
    public void SetLieutenant()
    {
        hisHeroData = UIBattleManager.instance.pnlPVE.historyDatas;
        for (int i = 0; i < hisHeroData.Count; i++)
        {
            CommonSlot slot = KMTools.AddChild<CommonSlot>(grdHero.gameObject, m_heroButton);
            slot.name += "i";
            slot.SetNormal(null, null, hisHeroData[i].heroData.icon_middle, "Lv." + hisHeroData[i].level);
            slot.SetOther("EXP+" + FM.heroExp, hisHeroData[i].GetPercentByEXP());
            heroSlots.Add(slot);
        }

        m_heroButton.gameObject.SetActive(false);
        grdHero.repositionNow = true;


        updateEvent += UpdateLieutenantExp;
    }

    void UpdateLieutenantExp()
    {
        timeHero += Time.deltaTime;
        BattleStartHeroData hisHero;
        for (int i = 0; i < hisHeroData.Count; i++)
        {
            hisHero = hisHeroData[i];
            if (hisHero.level < hisHero.heroData.level)
            {
                hisHero.exp = (int)Mathf.Lerp(hisHero.exp, hisHero.expByNextLv, timeHero);
                m_heroButton.SetSldOther(hisHero.GetPercentByEXP());
                if (timeHero >= 0)
                {
                    hisHero.level++;
                    timeHero = 0;
                    m_heroButton.SetLevel("Lv." + hisHero.level);
                }
            }
            else if (hisHero.exp < hisHero.heroData.exp)
            {
                hisHero.exp = (int)Mathf.Lerp(hisHero.exp, hisHero.heroData.exp, timeHero);
                m_heroButton.SetSldOther(hisHero.GetPercentByEXP());
            }
            else
            {
                updateEvent -= UpdateLieutenantExp;
            }
        }
    }

    //设置统领经验条
    public void SetPlayerExp()
    {
        hisPlayerData = UIBattleManager.instance.pnlPVE.hisPlayerData;

        playerSlot.SetOther("EXP+[03ff06]" + FM.playerExp + "[-]", hisPlayerData.GetPercentByEXP());
        playerSlot.SetLevel("Lv." + hisPlayerData.level);

        
        updateEvent += UpdatePlayerExp;
    }

    void UpdatePlayerExp()
    {
        timePlayer += Time.deltaTime;
        if (hisPlayerData.level < UD.level)
        {
            hisPlayerData.exp = (int)Mathf.Lerp(hisPlayerData.exp, hisPlayerData.expByNextLv, timePlayer);
            playerSlot.SetSldOther(hisPlayerData.GetPercentByEXP());
            if (timePlayer >= 0)
            {
                hisPlayerData.level++;
                timePlayer = 0;
                playerSlot.SetLevel("Lv." + hisPlayerData.level);
            }
        }
        else if (hisPlayerData.exp < UD.exp)
        {
            hisPlayerData.exp = (int)Mathf.Lerp(hisPlayerData.exp, UD.exp, timePlayer);
            playerSlot.SetSldOther(hisPlayerData.GetPercentByEXP());
        }
        else
        {
            updateEvent -= UpdatePlayerExp;
        }
    }

    //设置胜利评星
    public void SetStar(int count)
    {
        for (int i = 0; i < count; i++)
        {
            m_statBox[i].gameObject.SetActive(true);
            m_statBox[i].GetComponent<UISprite>().spriteName = "win_02";
        }
    }

    //设置评分
    public void SetScoreLabel(int scroe)
    {
        m_scoreLabel.text = "评分：" + scroe.ToString();
    }
}
