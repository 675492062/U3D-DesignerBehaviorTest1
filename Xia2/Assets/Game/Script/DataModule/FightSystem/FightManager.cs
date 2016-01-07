using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;
using System.Linq;

public class FightManager : MonoBehaviour
{
    public List<DropItem>[] normalMonItem;
    public Dictionary<int, int>[] monToDropItem;

    public List<DropItem> bossItem = new List<DropItem>();
    public List<DropItem> dropItems = new List<DropItem>();
    public List<DropItem> boxItem = new List<DropItem>();

    /// <summary>
    /// 用于记录每个英雄击杀的敌人，游戏成功之后会上传到服务器的一数组
    /// </summary>
    private List<Skada> skadas = new List<Skada>();
    int m_monMaxNum = 0;
    int m_curMonCount = 0;

    public int playerExp = 0;
    public int heroExp = 0;
    public int money = 0;
    public List<DropItem> temp_items;

    public FightManager()
    {
        init();
    }
    public List<Skada> getKillerList()
    {
        return skadas;
    }
    public void init()
    {
        int max = (int)GlobalDef.ItemType.ITEM_MAX;
        temp_items = new List<DropItem>();
        normalMonItem = new List<DropItem>[max];
        monToDropItem = new Dictionary<int, int>[max];

        for (int i = 0; i < max; i++)
        {
            normalMonItem[i] = new List<DropItem>();
            monToDropItem[i] = new Dictionary<int, int>();
        }
    }

    public void reset(int monMaxNum)
    {
        m_monMaxNum = monMaxNum;

        int max = (int)GlobalDef.ItemType.ITEM_MAX;
        for (int i = 1; i < max; i++)
        {
            for (int j = 0; j < normalMonItem[i].Count; j++)
            {
                while (true)
                {
                    if (monToDropItem[i].Count >= monMaxNum)
                        break;
                    int rand = Random.Range(0, m_monMaxNum);
                    bool b = monToDropItem[i].ContainsKey(rand);
                    if (b)
                        continue;
                    monToDropItem[i].Add(rand, j);
                    break;
                }
            }
        }
    }

    public DropItem getItem()
    {
        //		temp_items.Clear ();
        //		int max = (int)GlobalDef.ItemType.ITEM_MAX;
        //		for (int i = 1; i < max; i++) {
        //			for( int j = 0; j < monToDropItem[i].Count; j++ ){
        //
        //				bool b = monToDropItem[i].ContainsKey(m_curMonCount);
        //				if(b)
        //				{
        //					int idx = monToDropItem[i][m_curMonCount];
        //					temp_items.Add( normalMonItem[i][idx] );	
        //					break;
        //				}
        //			}
        //		}
        m_curMonCount = Random.Range(0, dropItems.Count - 1);
        DropItem item = dropItems.ElementAt(m_curMonCount);
        if (item != null)
        {
            dropItems.Remove(item);
            return item;
        }
        return null;
    }

    public void clear()
    {
        for (int i = 0; i < normalMonItem.Length; i++)
        {
            normalMonItem[i].Clear();
            monToDropItem[i].Clear();
        }
        bossItem.Clear();
        boxItem.Clear();
        temp_items.Clear();
        dropItems.Clear();
        m_monMaxNum = 0;
        m_curMonCount = 0;
        playerExp = 0;
        heroExp = 0;
        money = 0;
        skadas.Clear();
    }

    public void killEnemyEvent(int enemyId, long heroGUID)
    {
        int heroIndex = -1;

        Killer killer;

        Killer k = new Killer();

        for (int i = 0; i < skadas.Count; i++)
        {
            if (skadas[i].id == heroGUID)
            {
                heroIndex = i;
                for (int j = 0; j < skadas[i].killer.Count; j++)
                {
                    killer = skadas[i].killer[j];
                    if (killer.id == enemyId) // has enemy
                    {
                        //操作完毕返回
                        killer.number++;
                        return;
                    }
                }

                //无此敌人 直接添加
                k.id = enemyId;
                k.number = 1;

                skadas[i].killer.Add(k);
                return;
            }
        }


        Skada newData = new Skada();
        newData.id = heroGUID;

        k.id = enemyId;
        k.number = 1;

        newData.killer.Add(k);

        skadas.Add(newData);

    }
}
