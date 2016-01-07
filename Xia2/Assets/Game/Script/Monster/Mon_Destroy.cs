using UnityEngine;
using System.Collections;

public class Mon_Destroy : MonoBehaviour {
	
	//GameObject obj;
	//public bool falldown = false;
	//Vector3 falldowndir;
	public Transform headbone;
	Transform mytransform;
	float delay_finish = 0;
	float downaccel = 1;
	
	void Awake () 
	{
		//obj = GameObject.Find("stage");
		GetComponent<Animation>()["dt1"].speed = 0.3f;
		//Destroy (gameObject,2.0f);
		mytransform = transform;
		gameObject.active = false;
	}
	
	public void FinishNow()
	{
		delay_finish = 5;
	}
	

	public void TextureChange(Texture a,Vector3 _scale,int _kind)
	{
		GetComponent<Animation>().Stop();
		GetComponent<Animation>().Play("dt1");
		delay_finish =0;
		downaccel = 0;
		
		if (_kind ==2)
		{
			mytransform.Find("p1").GetComponent<Renderer>().material.SetTexture("_MainTex", a);
			mytransform.Find("p2").GetComponent<Renderer>().material.SetTexture("_MainTex", a);
			if (_scale.x>1)
			{
				mytransform.localScale = _scale *1.2f;
				headbone.localScale = Vector3.one*0.7f;
			}
			else
			{
				mytransform.localScale = Vector3.one * 1.2f;
				headbone.localScale = Vector3.one;
			}
		}
		else
			GetComponent<Animation>()["dt1"].speed = 0.55f;
		//falldowndir = attackdir;
	}

	void Update () 
	{
		if (delay_finish>3)
		{
			gameObject.active = false;
			mytransform.position = Vector3.one*6;
			delay_finish =0;
			
		}
		else
			delay_finish += Time.deltaTime;
		
		if (mytransform.position.y >0)
		{
			downaccel += Time.deltaTime*5;
			mytransform.position -= Vector3.up * Time.deltaTime* downaccel;
		}
		else
		{
			mytransform.position = new Vector3(mytransform.position.x,0, mytransform.position.z);
		}
		/*if (falldown)
		{
			mytransform.position -= Vector3.up*0.5f * Time.deltaTime;
		}*/
	}
}
