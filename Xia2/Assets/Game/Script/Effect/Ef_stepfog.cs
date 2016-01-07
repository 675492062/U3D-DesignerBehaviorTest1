using UnityEngine;
using System.Collections;

public class Ef_stepfog : MonoBehaviour {
	
	public float fogheight;
	public float fogspeed;
	//int fogrotation = 0;
	public int fogalpha;
	public float smoothfactor;
	public float xyratio;
	float dt = 0;
	Renderer myrenderer;
	Transform mytransform;
	
	Vector3 growVector;
	Vector3 smoothgrowVector;
	
	Color currentColor;
	Color targetColor;
	Color transColor;
			
	Vector3 originScale;
	
	void Awake()
	{
		mytransform= transform;
		myrenderer= GetComponent<Renderer>();
		//renderer.sharedMaterial.renderQueue = 4005;
	}
	
	void Start () 
	{
		originScale = mytransform.localScale;
		targetColor = new Color (0.5f,0.5f,0.5f,0);
		myrenderer.enabled = false;	
		myrenderer.material.SetColor("_TintColor",Color.gray);

		growVector = new Vector3 (fogspeed,fogspeed*xyratio,fogspeed);
		smoothgrowVector = new Vector3 (fogspeed*smoothfactor,fogspeed*smoothfactor*0.5f,fogspeed*smoothfactor);
		gameObject.active = false;
	}

	
	void Update()
	{
		if (dt <0.1f)
		{
			dt += Time.deltaTime;
		}
		else 
			myrenderer.enabled = true;
		
		if (myrenderer.enabled)
		{
			currentColor = myrenderer.material.GetColor ("_TintColor");
			transColor = Color.Lerp (currentColor, targetColor, Time.deltaTime*fogalpha);
			myrenderer.material.SetColor("_TintColor",transColor);
			
			if ( mytransform.localScale.y > fogheight)
			{
				mytransform.position = Vector3.one*4;
				myrenderer.enabled = false;
				gameObject.active = false;
				dt = 0;
				myrenderer.material.SetColor("_TintColor",Color.gray);
				mytransform.localScale = originScale;
			}
			else if (mytransform.localScale.y >fogheight * 0.8f)
			{
				mytransform.localScale += smoothgrowVector *Time.deltaTime;
			}
			else
			{
				mytransform.localScale += growVector *Time.deltaTime;
			}
		}
	}
}
