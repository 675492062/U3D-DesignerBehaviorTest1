/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-04   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 英雄进阶面板管理器
/// </summary>
public class ProgressManager : MonoBehaviour
{

    #region 基础属性
    public UILabel labHP;
    public UILabel labATK;
    public UILabel labDEF;
    /// <summary>
    /// 无双
    /// </summary>
    public UILabel labWuS;
    /// <summary>
    /// 气力
    /// </summary>
    public UILabel labEnerge;

    #endregion

    #region 攻击属性

    public UILabel labATKSpeed;
    public UILabel labCritOdds;
    public UILabel labCritHarm;
    public UILabel labHitOdds;
    public UILabel labTureDamage;

    #endregion

    #region 传奇属性

    /// <summary>
    /// 起始连击
    /// </summary>
    public UILabel labStartHit;
    public UILabel labRevertByHit;
    public UILabel labFilchByHit;
    public UILabel labRevertByFight;

    #endregion

    #region 防御属性

    public UILabel labDodgeOdds;
    public UILabel labTenacityOdds;
    public UILabel labTenacity;
    /// <summary>
    /// 真实减免
    /// </summary>
    public UILabel labTrueDgresist;

    #endregion

    public UISlider sldProgress;
    public UILabel labCount;

    private HeroData curHero;

	void OnEnable()
	{
		Refresh(MonoInstancePool.getInstance<HeroManager>().getCurShowHero());
	}
    public void Refresh(HeroData data)
    {
		curHero = data;
//        if (curHero != null)
//            if (curHero != data || curHero.starLevel != data.starLevel)
//            {
//                curHero = data;
//            }
//            else return;
        HeroProperty pros = data.property;
		SetText(labHP, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT).ToString(), pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_1) > 0 ? pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFEGROWTH_1).ToString() : "");
		SetText(labATK, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACK).ToString(), pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1) > 0 ? pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATTACKGROWTH_1).ToString() : "");
		SetText(labDEF, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR).ToString(), pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_1) > 0 ? pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ARMORGROWTH_1).ToString() : "");
		SetText(labWuS, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT).ToString());
		SetText(labATKSpeed, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_ATKSPD).ToString());
		SetText(labCritOdds, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV).ToString());
		SetText(labCritHarm, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE).ToString());
		SetText(labHitOdds, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_HITLV).ToString());
		SetText(labTureDamage, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE).ToString());
        //TODO:
        SetText(labStartHit, "D");
		SetText(labRevertByHit, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_HITREGEN).ToString());
		SetText(labFilchByHit, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_LIFESTEAK).ToString());
		SetText(labRevertByFight, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_RECOVERY).ToString());
		SetText(labDodgeOdds, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_DODGELV).ToString());
		SetText(labTenacityOdds, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV).ToString());
		SetText(labTenacity, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_TENACITYLV).ToString());
		SetText(labTrueDgresist, pros.getPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST).ToString());

		int debirs = data.debris;
		labCount.text = debirs + "/" + data.infoStar.itemNum;
		sldProgress.value = debirs * 1.0f / data.infoStar.itemNum;
    }

    public void BtnJinJie()
    {
	        if (curHero == null) return;
//        if (curHero.infoStar.CanStarUp())
//        {
//            Debug.Log("TODO: send ..............");
			MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendUpgradeStarlv(curHero.guid);
//        }
//        else
//        {
//            Debug.Log(" don't up =============================");
//        }
    }

    private void SetText(UILabel lab, string text, string add = "")
    {
        lab.text = text;
        if (!string.IsNullOrEmpty(add) && add != "0")
        {
            AddText(lab, add);
        }
    }

    private void AddText(UILabel lab, string add)
    {
        lab.text += " " + AllStrings.colHeroPropAdd + "(" + add + ")" + AllStrings.colEnd;
    }
}
