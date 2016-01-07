/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-20   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 当前出场英雄
/// </summary>
public class BTLCurHero : BTLHeroInfo
{
    const float maxEXPValue = 0.75f;
    private int m_oldCount = 5;

    private List<UIBtnBattleSkill> uiSkills;

    /// <summary>
    /// 行动点
    /// </summary>
    public UISprite[] sprsEnery;

    public UISprite sprExp;

    public UILabel labHP;

    public UISlider[] sldMP; //魔法值条

    /// <summary>
    /// 硬直
    /// </summary>
    public UISlider sldHS;

    void OnClick()
    {

    }

    public override void Refresh(HeroData data)
    {
        base.Refresh(data);
        if (data != null)
        {
            //TODO：圆形图标
            //if (icon) icon.spriteName = data.icon;

            for (int i = 0; i < sprsEnery.Length; i++)
            {
                sprsEnery[i].gameObject.SetActive(i < data.getMaxEnergy());
            }
        }
    }
    public void SetSkills(List<UIBtnBattleSkill> skills)
    {
        this.uiSkills = skills;
    }

    public List<UIBtnBattleSkill> GetSkills()
    {
        return uiSkills;
    }

    public override void SetHP()
    {
        if (labHP) labHP.text = hero.getCurPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) + "/" + hero.getMaxHP();
        base.SetHP();
    }

    public void SetEXP()
    {
        if (sprExp == null) return;
        float percent = hero.getPercentByEXP();
        percent *= maxEXPValue;
        sprExp.fillAmount = percent;
    }

    public void SetHardStraight()
    {
        if (sldHS != null) sldHS.value = hero.getPercentByHardStraight();
    }

    protected override void SetLevel(int lv)
    {
        if (level) level.text = lv.ToString();
    }

    protected override void SetOther(HeroData data)
    {
        SetEnergy();
        SetEXP();
        SetMP();
        SetHardStraight();
    }

    //设置主角翻滚点数
    public void SetEnergy()
    {
        int count = (int)hero.getCurPro((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER) - 1;
        //Debug.Log(count);
        if (count > sprsEnery.Length)
            count = sprsEnery.Length;

        for (int i = 0; i < sprsEnery.Length; i++)
        {
            if (i <= count)
            {
                //sprsEnery[i].enabled = true;
                sprsEnery[i].spriteName = "bs-07-1";
                if (i == count && count >= m_oldCount)
                {
                    TweenScale sl = sprsEnery[i].gameObject.AddComponent<TweenScale>();
                    sl.duration = 0.2f;
                    sl.style = UITweener.Style.PingPong;
                    sl.to = new Vector3(1.25f, 1.25f, 1.25f);
                    StartCoroutine(WaitFor(sl));
                }
            }
            else
            {
                //sprsEnery[i].enabled = false;
                sprsEnery[i].spriteName = "bs-07-2";
            }
        }

        m_oldCount = count;
    }

    public void SetMP()
    {
        float percent = hero.getPercentByMP();
        if (percent > 0.66f)
        {
            percent -= 0.66f;
            percent *= 3;
            sldMP[2].value = percent;
            sldMP[1].value = 1;
            sldMP[0].value = 1;
        }
        else if (percent > 0.33f)
        {
            percent -= 0.33f;
            percent *= 3;
            sldMP[2].value = 0;
            sldMP[1].value = percent;
            sldMP[0].value = 1;
        }
        else
        {
            percent *= 3;
            sldMP[2].value = 0;
            sldMP[1].value = 0;
            sldMP[0].value = percent;
        }

        if (uiSkills != null)
            foreach (UIBtnBattleSkill btn in uiSkills)
            {
                btn.EnableMPListener();
            }
        //else Debug.Log("ui skill   is null---------", gameObject);
    }

    private IEnumerator WaitFor(TweenScale sl)
    {
        yield return new WaitForSeconds(1);
        sl.transform.localScale = new Vector3(1, 1, 1);

        Destroy(sl);
    }
}
