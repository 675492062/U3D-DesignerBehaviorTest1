using UnityEngine;
using FightMessage;
using System.Collections;

public class OnClickGemList : MonoBehaviour
{

    public UISprite sprBoxClose;
    public UISprite sprBoxOpen;

    public UISprite sprMoneyType;
    public UILabel labPrice;
    public int index;
    public int state;
    public UIPVEFinishPanel m_BattleCensus { get { return UIPVEFinishPanel.instance; } }


    public CommonSlot itemSlot;

    public GameObject goFree; //免费
    public GameObject goPay; //收费

    public GameObject goPrice;

    private DropItem item;

    void OnClick()
    {
        if (state == 0)
        {
            state = 1;
            m_BattleCensus.pnlSelectBox.getUpdate(index);
            GetComponent<Collider>().enabled = false;
        }
    }

    public void Init(DropItem item, bool isFree)
    {
        this.item = item;
        Debug.Log("------------------the item id is " + item.id);
        Refresh(0, isFree);
    }

    /// <summary>
    /// 0 为 没开 1为开
    /// </summary>
    /// <param name="state"></param>
    public void Refresh(int state, bool isFree, int price = 0)
    {
        this.state = state;
        SetFree(isFree);

        if (state == 0)
        {
            labPrice.text = "" + price;
        }
        else
        {
            goPrice.SetActive(false);
            sprBoxOpen.gameObject.SetActive(true);
            sprBoxClose.gameObject.SetActive(false);
        }
    }

    public void OpenBox()
    {
        itemSlot.gameObject.SetActive(true);
        //TODO 其它非表格物品加入:
        if (item.id == 0 || item.id < 100)
        {
            itemSlot.SetIcon(AllStrings.sprGold);
            itemSlot.SetNum(item.number.ToString());
        }
        else
        {
            itemSlot.SetIcon(ConfigManager.getInstance().getData(item.id, "icon"));
        }
    }

    private void SetFree(bool isFree)
    {
        goFree.SetActive(isFree);
        goPay.SetActive(!isFree);
    }

}
