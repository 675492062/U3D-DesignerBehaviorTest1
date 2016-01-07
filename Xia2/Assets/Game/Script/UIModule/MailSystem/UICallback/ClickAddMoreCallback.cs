using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickAddMoreCallback : MonoBehaviour {
    public UILabel Label;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        int nextPage = MonoInstancePool.getInstance<MailManager>().currentPage + 1;
        if (nextPage <= MonoInstancePool.getInstance<MailManager>().mailCount)
        {
//			MonoInstancePool.getInstance<SendMailSystemHander>().SendGetMailList(nextPage);
        }
    }
}
