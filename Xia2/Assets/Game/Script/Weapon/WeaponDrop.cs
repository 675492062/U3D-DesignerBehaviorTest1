using UnityEngine;
using System.Collections;

public class WeaponDrop : MonoBehaviour {
	
	Transform mytransform;
	float maxy = 1.7f;
	bool drop = false;
	Vector3 rotateaxis;
	void Awake () 
	{
		mytransform = transform;
		rotateaxis = mytransform.right ;
	}
	
	public void DropCancel()
	{
		CancelInvoke ("Disappear");
		drop = false;
	}
	public void Drop(bool _destroy)
	{
		CancelInvoke ("Disappear");
		if (_destroy)
			Destroy(gameObject,2.5f);
		else
			Invoke("Disappear",3.5f);
		drop = true;
		maxy = 1.7f;
		//mytransform.position += Vector3.up*0.05f;
	}
	
	void Disappear()
	{
		mytransform.position = Vector3.one*4;
		gameObject.active = false;
	}

	void Update () 
	{
		if (drop)
		{
			if (mytransform.position.y > 0)
			{
				mytransform.Rotate(rotateaxis * Time.deltaTime*720);
				maxy -= 3.5f * Time.deltaTime;
				mytransform.position += Vector3.up*maxy * Time.deltaTime;
			}
			else
			{
				mytransform.position = Vector3.right*mytransform.position.x+Vector3.forward*mytransform.position.z;
				drop = false;
			}
		}
	}
}
