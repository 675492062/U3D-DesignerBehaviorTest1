using UnityEngine;
using System.Collections;

public class Sword_Extreme : MonoBehaviour {
	
	float delay = 0;
	bool efOn = false;
	Transform mytransform;
	Transform cha1;
	Collider mycollider;
	Vector3 startPos;
	
	void Awake()
	{
		mytransform = transform;
		cha1=GameObject.FindWithTag("Player").transform;
		mycollider = GetComponent<Collider>();
	}
	
	void OnEnable()
	{
		delay = 1.5f;
		efOn = false;
		gameObject.layer = 16;
		mycollider.enabled = true;	
		startPos = mytransform.position;
	}
	
	public void SetPower(int _amount)
	{
		GetComponent<Rigidbody>().mass =  (float)(_amount *0.4f);
	}
	
	void ColliderOn()
	{
		mycollider.enabled = false;	
		mycollider.enabled = true;	
	}
	
	void Update () 
	{
		delay -= Time.deltaTime;
		if (delay<-1.5)
		{
			//mycollider.enabled = false;
			GetComponent<ParticleSystem>().Clear();
			gameObject.active = false;	
		}
		else if (delay<-1.0f)
		{
			CancelInvoke();
		}
		else if (delay<0)
		{
			mytransform.position = Vector3.Lerp(mytransform.position, cha1.position + Vector3.up*0.2f, Time.deltaTime*3.5f);
			if (!efOn)
			{
				mytransform.position = startPos;
				gameObject.layer = 17;
				InvokeRepeating ("ColliderOn",0.01f,0.1f);
				//mytransform.position = cha1.position - cha1.forward*0.1f + Vector3.up*0.2f ;
				efOn = true;
				GetComponent<ParticleSystem>().Play();
			}
		}
		else
			mytransform.position = cha1.position;
	}
}
