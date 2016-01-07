using UnityEngine;
using System.Collections;

public class Ef_blood : MonoBehaviour {

	int index = 0;
	int oldindex = -1;
	float starttime =0;
	Renderer myrenderer;
	Transform mytransform;
	Vector2 size;
	Vector2 offset;
	float uIndex = 0;
	int vIndex = 0;
	
	void Awake()
	{
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
		size = Vector2.one * 0.25f;
		gameObject.active = false;
	}

	void Update()
	{
		if (mytransform.position.y<1)
		{
			starttime += Time.deltaTime;
			index = (int)(starttime * 22);

			uIndex = index % 4;
			vIndex = index / 4;

			offset = new Vector2 (uIndex * size.x, 1.0f - size.y - vIndex * size.y);

			if (index != oldindex)
			{
				if ( index >= 16)
				{
					mytransform.position = Vector3.one*3;
					starttime = 0;
					index = 0;
					gameObject.active = false;
				}
				myrenderer.material.mainTextureOffset  = offset;
				myrenderer.material.mainTextureScale = size;
				oldindex = index;
			}
		}

	}

}
