using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour {

	public Camera guiCamera;
	public GameObject damageLabel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addDamageLabel(int num, GameObject target)
	{
		GameObject child = (GameObject)Instantiate(damageLabel);
		child.transform.parent = this.transform;
		child.transform.localPosition = new Vector3(0, 0, 0);   //设置position、scale和rotation  
		child.transform.localScale = new Vector3(1, 1, 1);  
		child.transform.localRotation = Quaternion.Euler(0, 0, 0);  

		Damege com = child.GetComponentInChildren<Damege> ();
		if (com) {
			com.setInitPosition(guiCamera, target, num);
		}

	}

}
