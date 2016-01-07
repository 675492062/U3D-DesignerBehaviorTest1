using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;
using System.Linq;

public class UIPVESelectBox : MonoBehaviour
{
    public UIGrid m_grid;
    public OnClickGemList m_button;
    public UILabel m_surplus;
    public UIPVEFinishPanel m_BattleCensus { get { return UIPVEFinishPanel.instance; } }
    public UILabel m_times;
    public int times = 10;//界面刷新时间

    private List<OnClickGemList> boxs = new List<OnClickGemList>();


    /// <summary>
    /// 当前点击次数
    /// </summary>
    private int counts = 0;

    private int freeCount = 0;

    /// <summary>
    /// 开箱价格 TODO
    /// </summary>
    private int price = 5;

    /// <summary>
    /// 最大点击次数
    /// </summary>
    const int maxCount = 6;

    private bool isComplete = false;

    public void SendMessageToServer()
    {
        if (isComplete) return;
        isComplete = true;
        m_BattleCensus.SendSuccessEvent();
        gameObject.SetActive(false);
    }

    private void setFreeCount(int cont)
    {
        freeCount = cont;
        m_surplus.text = cont + "/6";
    }

    public void setGemList()
    {
        //TODO:
        bool isTest = true;
        if (isTest)
        {
            randomChild();
            return;
        }

        createGem();
        StartCoroutine(waitForOneSecond());
    }

    private void createGem()
    {

        if (m_grid == null)
            return;
        if (m_button == null)
            return;

        m_button.gameObject.SetActive(true);

        List<DropItem> gemTreasure = MonoInstancePool.getInstance<FightManager>().boxItem;
        //TODO 免费次数
        setFreeCount(1);
        bool isFree = freeCount > 0;


        for (int i = 0; i < gemTreasure.Count; i++)
        {
            OnClickGemList list = KMTools.AddChild<OnClickGemList>(m_grid.gameObject, m_button);
            if (list == null)
                return;
            DropItem item = gemTreasure[i];
            list.index = i;

            list.Init(item, isFree);
            boxs.Add(list);
        }

        m_button.gameObject.SetActive(false);

        if (m_grid != null)
            m_grid.repositionNow = true;

    }

    /// <summary>
    /// 宝箱点击调用函数
    /// </summary>
    /// <param name="boxIndex"></param>
    public void getUpdate(int boxIndex)
    {
        if (isComplete) return;

        counts += 1;
        if (freeCount > 0)
        {
            setFreeCount(freeCount - 1);
        }
        bool isFree = freeCount > 0;
        boxs[boxIndex].Refresh(1, isFree);
        boxs[boxIndex].OpenBox();


        for (int i = 0; i < boxs.Count; i++)
        {
            OnClickGemList list = boxs[i];
            if (i == boxIndex || list.state == 1) continue;
            boxs[i].Refresh(0, isFree, price);
        }

        if (counts >= maxCount)
        {
            SendMessageToServer();
        }
    }

    private void randomChild()
    {
        if (freeCount > 0)
            for (int i = 0; i < boxs.Count; i++)
            {
                OnClickGemList list = boxs[i];

                if (list.state == 1)
                {
                    return;
                }

                list.state = 1;
                m_BattleCensus.AddIndexToList(list.index);
                getUpdate(i);

                setFreeCount(freeCount - 1);
                if (freeCount <= 0) break;
            }
        SendMessageToServer();
    }

    public IEnumerator waitForOneSecond()
    {
        while (times > 0)
        {
            times--;
            yield return new WaitForSeconds(1);
            m_times.text = "倒计时：" + times.ToString() + "秒";
            if (times <= 0)
            {
                if (counts == 0)
                {
                    randomChild();
                }
                else
                {
                    //TODO
                    SendMessageToServer();
                }
            }
        }
    }
}
