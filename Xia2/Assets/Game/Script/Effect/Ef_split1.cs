using UnityEngine;
using System.Collections;

public class Ef_split1 : MonoBehaviour {
	
	float destroydelay = 0;
	float alphadelay = 0;
	
	Mesh mymesh;
	Color p_color = Color.white;
	Transform mytransform;
	Color[] temp = new Color[4];
	
	void Awake()
	{
		mytransform = transform;
		mymesh = GetComponent<MeshFilter>().mesh;
	}
	void Start () 
	{
		gameObject.active = false;
	}

	public void FinishNow()
	{
		destroydelay = 5;
	}
	
	void Update()
	{
		destroydelay += Time.deltaTime;
		if (destroydelay>4)
		{
			mytransform.position = Vector3.one * 3;
			p_color = Color.white;
			destroydelay = 0;
			for (int i = 0; i<4; ++i)
			{
				temp[i] = Color.white;
			}
			mymesh.colors = temp;
			gameObject.active = false;
		}
		else if ( destroydelay> 3.0f) 
		{ 
			p_color = Color.Lerp(p_color, Color.clear, Time.deltaTime*5);
			if (alphadelay>0.1f)
			{
				for (int i = 0; i<4; ++i)
				{
					temp[i] = p_color;
				}
				alphadelay = 0;
				mymesh.colors = temp;
			}
			else
			{
				alphadelay += Time.deltaTime;
			}
		}
	}
}
