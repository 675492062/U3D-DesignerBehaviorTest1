using UnityEngine;
using System.Collections;

public class Screen_effect : MonoBehaviour {
	
	Transform mytransform;
	
	void Awake () 
	{
		mytransform = transform;
	}
	
	void OnEnable()
	{
		mytransform.localScale = Vector3.one *6.5f;
	}
	
	void Update () 
	{
		if (mytransform.localScale.x< 10)
			mytransform.localScale+= Vector3.one * Time.deltaTime *6;
		else
			gameObject.active = false;
	}
}
