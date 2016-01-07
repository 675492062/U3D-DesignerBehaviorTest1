using UnityEngine;
using System.Collections;

public class MailRewardUIManager : MonoBehaviour {
    public UIPanel RewardWindow;
    public UILabel GoodsLabel;
    public UILabel GoodsNumlabel;
    public UILabel UIMailTitle;
    public UILabel UIMailContent;
    public UILabel UIMailFrom;
    public GameObject OkButton;
    public GameObject DrawButton;
    public GameObject EnclosureWindow;
    public UILabel RewardInfoCount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hideMailContentWindow()
    {
        this.gameObject.SetActive(false);
    }

    //加载附件
    public void showEnclosure()
    {
        for (int i = 0; i < MonoInstancePool.getInstance<MailManager>().currentMail.itemAry.Count; i++)
        {
            loadEnclosure("X" + MonoInstancePool.getInstance<MailManager>().currentMail.itemAry[i].number, i, "Flag-FR");
        }
    }

    void loadEnclosure(string title, int index, string spritName)
    {
        GameObject instance = Instantiate(Resources.Load("Prefab/MailSystem/MailReward", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = EnclosureWindow.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(120 + (index * 70), 0, 0);
        ClickMailRewardCallback s = instance.GetComponent<ClickMailRewardCallback>();
        s.Sprite.name = spritName;
        s.UIMailRewardContent.text = title;
        MonoInstancePool.getInstance<MailManager>().enclosureObject.Add(instance);
    }

    public void showRewardWindow()
    {
        if (RewardWindow)
        {
            RewardWindow.gameObject.SetActive(true);
        }
    }

    public void hideRewardWindow()
    {
        if (RewardWindow)
        {
            RewardWindow.gameObject.SetActive(false);
        }
    }

    public void setRewardInfo(string goodsName, string goodsNum)
    {
        GoodsLabel.text = goodsName;
        GoodsNumlabel.text = goodsNum;
    }

    //显示邮件内容
    public void showMailContent()
    {
        Mail currentMail = MonoInstancePool.getInstance<MailManager>().currentMail;
        this.UIMailTitle.text = currentMail.mailTitle;
        this.UIMailContent.text = currentMail.mailContent;
        this.UIMailFrom.text = currentMail.from;
        if (currentMail.itemAry.Count > 0)
        {
            this.OkButton.gameObject.SetActive(false);
            this.DrawButton.gameObject.SetActive(true);
        }
        else
        {
            this.OkButton.gameObject.SetActive(true);
            this.DrawButton.gameObject.SetActive(false);
        }
    }

    public void setRewardInfo2(string count)
    {
        RewardInfoCount.text = count;
    }
}
