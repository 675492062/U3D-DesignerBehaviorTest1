using UnityEngine;
using System.Collections;

public class Bullet_arrow : MonoBehaviour {

	public float bullet_speed;
	Transform mytransform;
	
	void Awake()
	{
		mytransform = transform;
	}
	

	void Update () 
	{
		mytransform.position += mytransform.forward * Time.deltaTime * bullet_speed;
	}
}
