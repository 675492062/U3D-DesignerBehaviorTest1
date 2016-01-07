using UnityEngine;
using System.Collections;

public class Bullet_punch : Ef_atkBase {
	
	public Transform pt_thrust;
	Transform mytransform;
	Vector3 originScale = new Vector3 (0.5f,2,0.5f);
	Vector3 growVector = new Vector3 (1,0,1);
	Color currentColor;
	Color transColor;
	Color targetColor = new Color (0.5f,0.5f,0.5f,0);
	Renderer myrenderer;
	Material mymaterial;
	SphereCollider mycollider;
	//Cha_Skill script_cha;
	
	short efon = 0;
	float delay = 0;
	int addforce = 0;
	
	Transform cha1;
	Transform enemy;
	Vector3 directionVector;
	float stepfactor = 1;
	float upangle = 0;
	bool boom = false;
	
	void Awake()
	{
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
		mymaterial = myrenderer.material;
		mycollider = GetComponent<Collider>() as SphereCollider;
		cha1 = GameObject.FindWithTag ("Player").transform;
	//	script_cha = cha1.GetComponent<Cha_Skill>();
		gameObject.active = false;
	}
	
	public void PunchOff()
	{
		delay = 4;
		efon = 0;
		mycollider.enabled = false;
		myrenderer.enabled = false;
		gameObject.active = false;
		mytransform.localScale = originScale;
		pt_thrust.GetComponent<ParticleEmitter>().emit = false;
	}
	
	public void PunchShoot(float _delay, int _addforce, Transform _mon, float _step, float _upangle , float _collidersize, bool _boom)
	{
		gameObject.active = true;
		delay = _delay;
		efon = 1;
		enemy = _mon;
		addforce= _addforce;
		mycollider.enabled = false;
		stepfactor = _step;
		upangle = _upangle;
		mycollider.radius = _collidersize;
		boom = _boom;
	}

	void Update()
	{
		
		if (efon >0)
		{
			if (efon == 1)
			{
				if (enemy != null)
					directionVector = enemy.position - cha1.position;
				else
					directionVector = cha1.forward *0.1f;
				//directionVector = Vector3.Normalize( enemy.position - cha1.position);
				if(directionVector!= Vector3.zero)
					cha1.rotation = Quaternion.LookRotation(directionVector);
				cha1.position += (directionVector*10 + cha1.right* stepfactor )*Time.deltaTime*0.5f;
				if (delay>0)
				{
					delay -= Time.deltaTime;
				}
				else
				{
					if (addforce >0)
						cha1.GetComponent<Rigidbody>().AddForce(cha1.transform.forward *addforce);
					efon = 2;
					mytransform.position = cha1.position + Vector3.up*(0.1f + upangle*0.1f) + cha1.forward *0.15f;
					mytransform.up = -cha1.forward - Vector3.up * upangle;
					mytransform.localScale = originScale;
					myrenderer.enabled = true;
					mycollider.enabled = true;
					mymaterial.SetColor("_TintColor",Color.gray);
					pt_thrust.GetComponent<ParticleEmitter>().emit = true;
	
//					if (boom)
//						script_cha.BoomOn(1,false);
				}
			}
			else if (efon == 2)
			{
				if ( mytransform.localScale.x >3)
				{
					efon = 0;
					myrenderer.enabled = false;
					gameObject.active = false;
					mytransform.position = Vector3.one*4;
				}
				else if (mytransform.localScale.x >1)
				{
					pt_thrust.GetComponent<ParticleEmitter>().emit = false;
					mycollider.enabled = false;
				}
			}
			mytransform.localScale += growVector*Time.deltaTime*6;
			currentColor = mymaterial.GetColor ("_TintColor");
			transColor = Color.Lerp (currentColor, targetColor, Time.deltaTime*5);
			mymaterial.SetColor("_TintColor",transColor);
		}
	}
}
