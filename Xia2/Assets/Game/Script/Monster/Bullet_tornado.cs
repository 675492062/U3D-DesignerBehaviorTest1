using UnityEngine;
using System.Collections;

public class Bullet_tornado : Ef_base {

	bool movestart = false;
	int rnddir = 0;
	private bool monmovestat = false;
	Vector3 targetpod;
	public Enemy script_mon;
	Transform mytransform;
	Transform myparent;
	Vector3 originscale;
	float sintime =0;
	float movedelay = 0;
	
	void Awake()
	{
		base.Awake ();
		mytransform = transform;
		myparent= mytransform.parent;
		originscale = mytransform.localScale;
	}
	
	void Start()
	{
		GetComponent<Animation>()["tornado"].speed = 0.3f;
		//Debug.Log("aa");
//		script_mon = mytransform.GetComponent<Enemy>();
		
	}
	
	void OnEnable () 
	{
		rnddir = Random.Range(0,2);
		rnddir = rnddir*2 -1;
		
		mytransform.localScale = originscale;
		targetpod = Vector3.zero;
		movestart = false;
		movedelay = 0;
		sintime =0;
		mytransform.parent =myparent;
		mytransform.position = mytransform.position + Vector3.up * 0.1f;
	}

	void Update () 
	{
		if(null == script_mon)
			return;
		movedelay += Time.deltaTime;

		if (!movestart)
		{
			monmovestat = script_mon.isDead();
			if (movedelay <1.2f)
			{
				if (monmovestat)
				{
					Disappear();
				}
				mytransform.localScale += Vector3.one*0.5f * Time.deltaTime;
			}
			else
			{
				mytransform.parent = null;
				movestart = true;
				mytransform.localScale = Vector3.one*2;
			}
		}
		else
		{
			sintime += Time.deltaTime;
			targetpod = mytransform.forward * 0.8f + (mytransform.right * 0.1f* Mathf.Cos( sintime*8) *rnddir) ;
			mytransform.rotation = Quaternion.LookRotation (targetpod);
			mytransform.position += targetpod * Time.deltaTime;
				
			if (mytransform.localScale.y >2.2f)
			{
				mytransform.localScale += (Vector3.right*(-1) + Vector3.forward*(-1))*Time.deltaTime;
				if (mytransform.localScale.x<1)
				{
					Disappear();
				}	
			}
			else
				mytransform.localScale +=Vector3.up * 0.2f;
		}
	}
	
	public void Disappear()
	{
		gameObject.active = false;
		mytransform.position = Vector3.one*5;
	}
}
