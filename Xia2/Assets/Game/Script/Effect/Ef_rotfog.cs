using UnityEngine;
using System.Collections;

public class Ef_rotfog : MonoBehaviour {
	
	float fogheight = 0;
	float fogspeed = 0;
	int fogrotation = 0;
	int fogalpha = 0;
	float xyratio = 0;
	Color transColor;
	Color targetColor;
	Color currentColor;
	Vector3 plusV;
	Transform mytransform;
	Material mymaterial;
	void Awake()
	{
		mytransform = transform;
		mymaterial = GetComponent<Renderer>().material;
	}
	
	void Start () 
	{
		mytransform.localScale = Vector3.zero;
		//mymaterial.color = new Color (0,0,0,0.2f);
		targetColor = new Color (0.5f,0.5f,0.5f,0);
	}

	public void RotfogOn(float limit_height, float _scale_speed, int _rot_speed , int _fogalpha , float _xyratio)
	{
		gameObject.active = true;
		mytransform.localScale = Vector3.one *0.3f;
		fogheight = limit_height;
		fogspeed = _scale_speed;
		fogrotation = _rot_speed;
		fogalpha = _fogalpha;
		xyratio =_xyratio;
		mymaterial.SetColor("_TintColor",Color.gray);
		plusV = new Vector3 (fogspeed,fogspeed*xyratio,fogspeed);
	}
	
	void Update()
	{
		currentColor = mymaterial.GetColor ("_TintColor");
		
		if ( mytransform.localScale.y > fogheight)
		{
			gameObject.active = false;
		}
		else if (mytransform.localScale.y >fogheight * 0.5f)
		{
			mytransform.localScale += plusV *Time.deltaTime;
			transColor = Color.Lerp (currentColor, targetColor, Time.deltaTime*fogalpha);
			mymaterial.SetColor("_TintColor",transColor);
		}
		else
		{
			mytransform.localScale += plusV *Time.deltaTime;
			mytransform.eulerAngles += Vector3.up*fogrotation *Time.deltaTime;
		}
	}
}
