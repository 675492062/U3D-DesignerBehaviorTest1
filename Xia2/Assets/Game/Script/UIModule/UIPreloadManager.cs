using UnityEngine;
using System.Collections;

public class UIPreloadManager : MonoBehaviour {

	string prefab_Bag = "Resources/Prefab/BagSystem/BagUI";
	GameObject bagUI;
	public GameObject getBagUI(){return bagUI;}

	void Start()
	{
	}
	public void preLoad()
	{
		bagUI = Instantiate(Resources.Load(prefab_Bag, typeof(GameObject))) as GameObject;
	}

}
