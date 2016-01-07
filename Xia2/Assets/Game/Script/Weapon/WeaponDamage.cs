using UnityEngine;
using System.Collections;

public class WeaponDamage : MonoBehaviour {
	
	Transform mytransform;
	//Transform cha1;
	//Transform general;
	public int damage;
	public bool impactDestroy = false;
	public float destroytime = 0;
	public float colliderofftime = 0;
	float currenttime = 0;
	Collider mycollider;
	
	void Awake()
	{
		mytransform = transform;
		mycollider = GetComponent<Collider>();
		currenttime =0;
	}
	
	void OnEnable()
	{
		currenttime =0;
	}
	
	void OnTriggerEnter(Collider other)
	{
//		if (other.gameObject.layer == 15)
//		{
//			Vector3 forceVector = mytransform.forward;
//			forceVector[1] = 0;
//			other.transform.SendMessage("OnDamaged", mytransform.forward + Vector3.up*damage );
//			if (impactDestroy)
//			{
//				gameObject.active = false;
//				mytransform.position = Vector3.one*5;
//			}
//		}
	}
	
	public void PressDamage(int a)
	{
		damage = a;
	}
	
	void Update()
	{
		if (destroytime>0)
		{
			currenttime += Time.deltaTime;
			if (colliderofftime>0)
			{
				if (currenttime >= colliderofftime)
				{
					mycollider.enabled = false;
				}
			}
			
			if (currenttime >= destroytime)
			{
				currenttime = 0;
				gameObject.active = false;
				mytransform.position = Vector3.one*5;
				mycollider.enabled = true;
			}
		}
	}
	
	

	
}
