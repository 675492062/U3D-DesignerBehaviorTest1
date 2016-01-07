using UnityEngine;
using System.Collections;

public class ClickMailRewardCallback : MonoBehaviour {
    public UILabel UIMailRewardContent;
    public UISprite Sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Debug.Log("click the reward button!");
        var manager = (MailRewardUIManager)FindObjectOfType<MailRewardUIManager>();
        if (manager.RewardWindow.gameObject.activeSelf)
        {
            manager.hideRewardWindow();
        }
        else
        {
            manager.showRewardWindow();
            manager.setRewardInfo2(UIMailRewardContent.text); 
        }
    }
}
