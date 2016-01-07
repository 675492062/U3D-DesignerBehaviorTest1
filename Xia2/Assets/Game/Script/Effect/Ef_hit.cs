using UnityEngine;
using System.Collections;

public class Ef_hit : MonoBehaviour {
	
	Transform mytransform;
	float showdelay = 0;
	Vector3 originscale;
	Vector3 growVector = new Vector3(-3,0,10);
	
	void Awake()
	{
		mytransform = transform;
	}
	
	void Start () 
	{
		originscale = mytransform.localScale;
		//gameObject.active = false;
		GetComponent<Renderer>().sharedMaterial.renderQueue = 4051;
	}
	
	void Update () 
	{
		if (showdelay < 0.25f)
		{
			mytransform.localScale += growVector *Time.deltaTime;
			showdelay += Time.deltaTime;
		}
		else
		{
			showdelay =0;
			mytransform.position = Vector3.one*3;
			mytransform.localScale = originscale;
			gameObject.active = false;
		}
	}
}
