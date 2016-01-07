using UnityEngine;
using System.Collections;

public class Bullet_spear : Ef_base{

	Transform mytransform;
	Vector3 originscale;
	public float tune;
	
	void Awake()
	{
		base.Awake ();
		mytransform = transform;
		originscale = mytransform.localScale;
		m_posType = 2;
	}

	void Start()
	{

	}
	
	void OnEnable()
	{
		mytransform.position += mytransform.forward*tune;
	}

	void Update () 
	{
		mytransform.position += mytransform.forward * Time.deltaTime * (0.2f + tune);
		mytransform.localScale -= Vector3.right *0.6f * Time.deltaTime;
		if (mytransform.localScale.x <0)
		{
			gameObject.active = false;
			 mytransform.localScale =originscale;
		}
	}
}
