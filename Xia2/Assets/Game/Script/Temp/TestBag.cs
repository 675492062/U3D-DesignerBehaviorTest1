using UnityEngine;
using System.Collections;

public class TestBag : MonoBehaviour {

	// Use this for initialization
	void Start () {

        


	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
		BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
		if(manager != null)
		{
			manager.changeFightPower(100, 200);
		}
//        BagStruct equip = MonoInstancePool.getInstance<BagManager>().getEquipmentBag();
//        for (int i = 0; i < equip.GetDict().Count; i++)
//        {
//            BaseItem item = equip.getItemByIdx(i);
//            if (item != null)
//            {
//                Debug.Log("0000000000000 " + item.guid);
//            }
//        }
//        Debug.Log("equip " + MonoInstancePool.getInstance<BagManager>().getEquipmentBag().GetDict().Count);
//        Debug.Log("equip " + MonoInstancePool.getInstance<BagManager>().getMaterialBag().GetDict().Count);
//        Debug.Log("equip " + MonoInstancePool.getInstance<BagManager>().getDiamondBag().GetDict().Count);
//        Debug.Log("equip " + MonoInstancePool.getInstance<BagManager>().getPotionBag().GetDict().Count);
    }
}
