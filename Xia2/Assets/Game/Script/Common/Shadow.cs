using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {
	
	Transform pickparent;
	private Transform mytransform;
	Vector3 shadowpos;
	
	void Awake()
	{
		mytransform = transform;
	 	GetComponent<Renderer>().sharedMaterial.renderQueue = 2001;
	}
	
	public void Pickparent(Transform pick, float shadowscale)
	{
		pickparent = pick;
		if (shadowscale>1)
			mytransform.localScale = Vector3.one * shadowscale;
	}
	
	public void Finish()
	{
		mytransform.position = Vector3.one *3;
		gameObject.active = false;
		pickparent = null;
	}

	void Update () 
	{
		if (pickparent != null)
		{
			shadowpos = pickparent.position;
			shadowpos[1] = 0;
			mytransform.position = shadowpos ;
			mytransform.position += Vector3.up * 0.002f;
		}
		else
			Finish();
		
		//mytransform.position = Vector3.right*pickparent.position.x + Vector3.forward* pickparent.position.z ;
	}
		
}
