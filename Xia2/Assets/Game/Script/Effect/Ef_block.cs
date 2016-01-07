using UnityEngine;
using System.Collections;

public class Ef_block : MonoBehaviour {
	
	Transform mytransform;
	void Awake()
	{
		mytransform = transform;
	}
	
	void Update()
	{
		if (mytransform.localScale.x <1.4f)
		{
			mytransform.localScale +=Vector3.one * 2*Time.deltaTime;
		}
		else
		{
			gameObject.active = false;
			mytransform.localScale = Vector3.one;
		}
	}

}
