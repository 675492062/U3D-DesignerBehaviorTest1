using UnityEngine;
using System.Collections.Generic;

public class UIPVEStatistics : MonoBehaviour
{
    public UIPVEFinishPanel m_BattleCensus { get { return UIPVEFinishPanel.instance; } }
    public UIGrid m_grid;

    public CommonSlot heroBox1;
    public CommonSlot heroBox2;

	private int maxHarm = 1;

    void OnEnable() { SetPoplist(); }

    void SetPoplist()
    {
        if (m_grid == null)
            return;

        if (heroBox1 == null || heroBox2 == null)
            return;

        List<HeroData> heros = MonoInstancePool.getInstance<HeroManager>().fightHeroList.getHeros();

        //临时数据
        for (int i = 0; i < heros.Count; i++)
        {
            CommonSlot slot;
            if (i % 2 == 0)
            {
                slot = KMTools.AddChild<CommonSlot>(m_grid.gameObject, heroBox1);
            }
            else
            {
                slot = KMTools.AddChild<CommonSlot>(m_grid.gameObject, heroBox2);
            }
			slot.SetNormal(heros[i].name, null, heros[i].icon_middle, null);

            //TODO:
			int harm = Random.Range(10, 9999999);
			maxHarm = Mathf.Max(harm,maxHarm);
			float percent = harm * 1.0f/maxHarm;
			slot.SetOther(harm.ToString(), percent);
        }

        heroBox1.gameObject.SetActive(false);
        heroBox2.gameObject.SetActive(false);

        m_grid.repositionNow = true;

    }
}
