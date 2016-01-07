using UnityEngine;
using System.Collections;

public class Ef_splash : Ef_atkBase {
	
	public Transform rising_fire;
	Transform cha1;
	Transform mytransform;
	Collider mycollider;
	Renderer myrenderer;
	
	float showtime = 1.5f;
	float dis = 0;
	Color originTintcolor;
	bool collidsionOn = false;
	bool showon = false;
	
	Color tintcolor;
	Color transColor;

	void Awake()
	{
		mytransform = transform;
		mycollider = GetComponent<Collider>();
		myrenderer = GetComponent<Renderer>();
	}
	void Start () 
	{
		cha1 = GameObject.FindWithTag("Player").transform;
		myrenderer.enabled =  false;
		mycollider.enabled = false;
		originTintcolor = myrenderer.material.GetColor("_TintColor");
		gameObject.active = false;
	}

	public void SplashOn(bool col, float _dis, float _delay)
	{
		collidsionOn = col;
		showtime = 1.5f;
		myrenderer.material.SetColor("_TintColor",originTintcolor);
		
		dis = _dis;
		Invoke("ShowOn",_delay);
	}
	
	public void SplashOff()
	{
		if (mycollider.enabled)
		{
			mycollider.enabled = false;
		}
		gameObject.active = false;
		CancelInvoke("ShowOn");
	}
	
	public void ShowOn()
	{
		gameObject.active = true;
		rising_fire.gameObject.active = true;
		myrenderer.enabled = true;
		if (collidsionOn)
		{
			mycollider.enabled = true;
		}
		mytransform.rotation = cha1.rotation;
		mytransform.position = cha1.position+ Vector3.up*0.02f + cha1.forward*dis;
		mytransform.localRotation = Quaternion.identity;
		showon = true;
	}
	
	void Update()
	{
		if (showon)
		{
			showtime -= Time.deltaTime;
			
			if ( showtime >1.3f) return;
			
			else if ( showtime >0.5f) 
			{
				if (mycollider.enabled)
				{
					mycollider.enabled = false;
				}
			}
			else if (showtime>0)
			{
				if (mycollider.enabled)
				{
					mycollider.enabled = false;
				}
				tintcolor = myrenderer.material.GetColor ("_TintColor");
				transColor = Color.Lerp (tintcolor, Color.clear, Time.deltaTime*14);
				myrenderer.material.SetColor("_TintColor",transColor);
			}
			else
			{
				gameObject.active = false;
				mytransform.position = Vector3.one *14;
			}
		}
	}
}
