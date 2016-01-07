using UnityEngine;
using System.Collections;

public class Ef_swing1 : Ef_atkBase {

    public int uvSpeed = 20;

	int uvAnimationTileX = 0;
	int uvAnimationTileY = 0;
	int framesPerSecond = 20;
	int index = 0 ;
	int oldindex = -1;
	float starttime;
	int lastframe;
	bool efon = false;
	float delay;
	//int chamovestat = 0;
	int impactframe = 1;
	Rigidbody cha_rigidbody;
	public Transform pt_hit;
	BasePlayer script_cha;
	Vector2 size;
	Vector2 offset;
	float uIndex = 0;
	int vIndex = 0;
	int originlayer = 20;
	public Pt_hit script_pthit;
	
	//bool hitstop = false;
	short layerindex = 0;
	bool layerchange = false;
	bool pton = false;
	short rndefamount = 0;
	
	//bool impactOn = false;
	//float impactdelay = 0;
	
	int addforce;
	Renderer myrenderer;
	Collider mycollider;

	protected Vector3  m_localScale;

	Transform  mytransform;

	void Awake()
	{
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
		mycollider = GetComponent<Collider>();
		originlayer = gameObject.layer;

	}
	
	void Start () 
	{
		m_localScale = mytransform.localScale;
		Transform cha1 = transform.parent;
		script_cha = cha1.GetComponent<BasePlayer>();
//
		//Transform hit =  (Transform) Instantiate (script_cha.ptHit,script_cha.ptHit.position,script_cha.ptHit.localRotation );
		Transform hit = mytransform.Find("pt_hit");
//		hit.parent = mytransform;
		if(hit)
			script_pthit =  hit.GetComponent<Pt_hit> ();


		cha_rigidbody = script_cha.m_rigidbody;
		Physics.IgnoreCollision( script_cha.m_atkCollider,mycollider);
		starttime = 0;
		myrenderer.enabled =  false;
		mycollider.isTrigger = true;
		mycollider.enabled = false;
		delay = 0;
		gameObject.active = false;
	}
	

	
	
	public void SwingOn(float _delay, int cnt_x, int cnt_y , int uvspeed , int impact, int _addforce)
	{
		gameObject.layer = originlayer;
		gameObject.active = true;
		delay = _delay;
		efon = true;
		
		uvAnimationTileX = cnt_x;
		uvAnimationTileY = cnt_y;
		lastframe = uvAnimationTileX * uvAnimationTileY;
		framesPerSecond = uvspeed;

        //Del:
        framesPerSecond = uvSpeed;

		impactframe = impact;
		addforce= _addforce;
		size = new Vector2 (1.0f/ uvAnimationTileX, 1.0f/uvAnimationTileY);
		
		if (layerchange)
		{
			//Debug.Log (rndefamount*5);
			int rndef = Random.Range(0,100);
			if (rndef <rndefamount)
				gameObject.layer = layerindex;
		}
	}
	
	public void SwingOff()
	{
		efon = false;
		gameObject.active = false;
		myrenderer.enabled = false;
		mycollider.enabled = false;
		pton = false;
		oldindex = -1;
		index = 0;
		starttime = 0;
		return;
	}
	
	public void RndEfOn(int _index, int _amount)
	{
		rndefamount = (short)_amount;
		switch(_amount)
		{
		case 2 : 
			rndefamount = 5;
			break;
		case 3:
			rndefamount = 10;
			break;
		case 4 : 
			rndefamount = 20;
			break;
		}
		//Debug.Log(rndefamount);
		
		layerchange = true;
		//layerindex = (short)_index;
		switch (_index)
		{
		case 0:
			layerindex = 20;
			layerchange = false;
			break;
		case 1 : 
			layerindex = 30;
			break;
		case 2:
			layerindex = 31;
			break;
		case 3 : 
			layerindex = 18;
			break;
		case 4:
			layerindex = 19;
			break;
		}
	}
	
	
	void Update()
	{
		if (efon)
		{
			if (delay>0)
			{
				delay -= Time.deltaTime;
			}
			else
			{
				if (addforce >0)
					cha_rigidbody.AddForce(transform.root.forward *addforce);
				myrenderer.enabled = true;
				starttime = 0;
				efon = false;
				script_cha.SwingStart();
			}
		}

		if (myrenderer.enabled)
		{
			//chamovestat = script_cha.chamovestat;
			starttime += Time.deltaTime;
			index = (int)(starttime * framesPerSecond);
			//index = index % (lastframe);

			uIndex = index % uvAnimationTileX;
			vIndex = (int) index / uvAnimationTileX;
			
			if (index != oldindex)
			{
				if ( index >= lastframe)
				{
					myrenderer.enabled = false;
					gameObject.active = false;
					mycollider.enabled = false;
					pton = false;
					oldindex = -1;
				}
				else if (index ==impactframe || index == impactframe+1)
				{
					mytransform.localScale = m_localScale;
					mycollider.enabled = true;
					if (!pton)
					{
						if( script_pthit )
							script_pthit.ParticleOn();
						pton = true;
					}
				}
				else
				{
					mycollider.enabled = false;
				}
				
				offset =  Vector2.right * uIndex * size.x  + Vector2.up * (1.0f - size.y - vIndex * size.y);
				//offset = new Vector2 (uIndex * size.x, 1.0f - size.y - vIndex * size.y);
				myrenderer.material.mainTextureOffset = offset;
				myrenderer.material.mainTextureScale = size;
				oldindex = index;
			}
		}


	}
	

}
