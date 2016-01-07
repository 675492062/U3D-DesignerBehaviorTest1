using UnityEngine;
using System.Collections;

public class DelSelectItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		var manager = (BagUIManager)FindObjectOfType (typeof(BagUIManager));
		int curIdx = manager.curSelectIdx;
		int curBag = manager.curBagType;
		BaseItem item = MonoInstancePool.getInstance<BagManager>().getBagByType(curBag).getItemByIdx (curIdx);
		if(item != null)
		{
			MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendDelItemReq(curBag, item.guid, 1);
		}
		else 
		{
			Debug.Log("have not item to use! idx: " + curIdx);
		}
	}
}
