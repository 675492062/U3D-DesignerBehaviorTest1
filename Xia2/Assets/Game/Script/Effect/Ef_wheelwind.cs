using UnityEngine;
using System.Collections;

public class Ef_wheelwind : MonoBehaviour {

	int index = 0;
	int oldindex = -1;
	float starttime = 0;
	float finishtime = 1.6f;
	Transform mytransform;
	Renderer myrenderer;
	Vector2 size;
	Vector2 offset;
	
	
	float uIndex = 0;
	int vIndex = 0;
	
	void Awake()
	{
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
	}
	void Start () 
	{
		mytransform.localScale = Vector3.one*0.3f;
		GetComponent<Collider>().isTrigger = true;
		GetComponent<Renderer>().enabled = false;

		size =  Vector2.one*0.5f;
	}

	
	void Update()
	{
		if (mytransform.localScale.x >1.0f)
		{
			GetComponent<Renderer>().enabled = true;
		}
		if (mytransform.localScale.x <1.8f)
		{
			mytransform.localScale += Vector3.one*4*Time.deltaTime ;
		}
		else
			mytransform.localScale = Vector3.one *1.8f;
		
		if (starttime >finishtime)
		{
			GetComponent<Renderer>().enabled = false;
			gameObject.active = false;
			mytransform.localScale = Vector3.one*0.3f;
			starttime =0;
		}
		
		starttime += Time.deltaTime;
		index = (int)(starttime * 16);
		index = (index % (4));
		//var = var - (int) index;

		uIndex = index % 2;
		vIndex = (int) index / 2;
		
		if (index != oldindex)
		{
			if ( index == 0 ||  index == 3)
			{
				GetComponent<Collider>().enabled = true;
			}
			else 
			{
				GetComponent<Collider>().enabled = false;
			}
			offset = new Vector2 (uIndex * size.x, 1.0f - size.y - vIndex * size.y);
			myrenderer.sharedMaterial.SetTextureOffset ("_MainTex",offset);
			myrenderer.sharedMaterial.SetTextureScale ("_MainTex",size);
			oldindex = index;
		}
	}

}
