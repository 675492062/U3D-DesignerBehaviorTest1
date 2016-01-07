using UnityEngine;
using System.Collections;

public class SellSelectItem : MonoBehaviour {

	public UIPanel configSellInfo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if(configSellInfo != null)
		{
			configSellInfo.gameObject.SetActive(false);
		}

        //BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
        //int curIdx = manager.curSelectIdx;
        //int curBag = manager.curOpenBag;
        //BaseItem item = MonoInstancePool.getInstance<BagManager>().getBagByType(curBag).getItemByIdx(curIdx);
        //long []guid = {item.guid};
        //int []num = {1};
        //SendItemSystemMsgHander.getInstance().sendSellItemReq(guid, num,type);

		this.transform.parent.gameObject.SetActive(false);
	}
}
