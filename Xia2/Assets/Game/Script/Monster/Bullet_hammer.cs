using UnityEngine;
using System.Collections;

public class Bullet_hammer : Ef_base {
	
	Transform mytransform;
	public float postune =0;
	Vector3 originScale = new Vector3 (1,8,1);
	Vector3 growVector = new Vector3 (0.8f,-2,0.8f);
	Color currentColor;
	Color transColor;
	Color targetColor = new Color (0.5f,0.5f,0.5f,0);
	Renderer myrenderer;
	Collider mycollider;
	
	
	void Awake()
	{
		base.Awake ();
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
		mycollider = GetComponent<Collider>();
	}
	
	void OnEnable()
	{
		mytransform.localScale = originScale;
		mytransform.position += mytransform.forward*postune;
		myrenderer.material.SetColor("_TintColor",Color.gray);
		mycollider.enabled = true;
	}

	void Update()
	{
		mytransform.localScale += growVector*Time.deltaTime*7;
		
		if ( mytransform.localScale.y <1)
		{
			gameObject.active = false;
			mytransform.position = Vector3.one*4;
			//mytransform.localScale = Vector3.one;
		}
		else if (mytransform.localScale.y <4)
			mycollider.enabled = false;
		
		currentColor = myrenderer.material.GetColor ("_TintColor");
		transColor = Color.Lerp (currentColor, targetColor, Time.deltaTime*5);
		myrenderer.material.SetColor("_TintColor",transColor);
	}
}
