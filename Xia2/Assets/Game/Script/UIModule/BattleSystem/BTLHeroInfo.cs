/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-20   WP      Initial version
 * 2014-11-26   WP      防御式编程
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 战斗场景基本英雄UI
/// </summary>
public class BTLHeroInfo : MonoBehaviour
{
    protected HeroData hero;

    public UISprite icon;
    public UISlider sldHP;
    public UISprite sprHP;
    public UILabel level;
    public UISprite sprDead;


    public virtual void Refresh(HeroData data)
    {
        if (data != null)
        {
            //Debug.Log("init hero ava" + data.templateID);
            hero = data;

            bool isDead = data.getCurPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) == 0;
            //TODO:
            if (icon)
            {
                icon.spriteName = data.icon_middle;
                if (isDead)
                {
                    //set gray
                    icon.color = new Color(0, 0, 0);
                }
                else
                {
                    icon.color = new Color(255, 255, 255);
                }
            }
            //Debug.Log(data.icon_middle);

            if (sprDead)
                if (!isDead)
                {
                    sprDead.enabled = false;
                }
                else SetDead();

            SetHP();
            SetLevel(data.level);
            SetOther(data);
        }
        else RefreshNull();

    }

    public virtual void SetHP()
    {
        if (sldHP) sldHP.value = hero.getPercentByHP();
        if (sprHP) sprHP.fillAmount = hero.getPercentByHP();
        if (hero.getCurPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) <= 0) SetDead();
    }

    public virtual void SetDead()
    {
        if (sprDead) sprDead.enabled = true;
    }

    protected virtual void SetLevel(int lv)
    {
        if (level) level.text = "lv" + lv;
    }

    protected virtual void SetOther(HeroData data) { }

    void RefreshNull()
    {
        //Debug.Log("null hero ava", gameObject);
        gameObject.SetActive(false);
    }

    void OnClick()
    {
        ObjectManager.instance.myPlayer.OnChangeChar(hero, false);
    }

    /// <summary>
    /// 是否为同一个英雄
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool IsHero(HeroData data)
    {
        return data == hero;
    }
}
