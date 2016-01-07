using UnityEngine;
using System.Collections;

public class ClickCloseMailContentWindow : MonoBehaviour {
    //public GameObject MailContentWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var manager = (MailRewardUIManager)FindObjectOfType<MailRewardUIManager>();
        manager.hideMailContentWindow();
    }
}
