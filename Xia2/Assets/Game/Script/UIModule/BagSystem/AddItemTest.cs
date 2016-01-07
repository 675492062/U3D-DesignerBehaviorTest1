using UnityEngine;
using System.Collections;

public class AddItemTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		uint id = (uint)Random.Range(510001,510005);
		MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendAddItemReq((int)GlobalDef.BagType.B_MATERIAL, id);
	}

}
