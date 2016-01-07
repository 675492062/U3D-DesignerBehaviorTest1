using UnityEngine;
using System.Collections;

public class DamageNum : MonoBehaviour {
	
	Transform mytransform;
	float finishdelay = 1;
	//float g_force = -1;
	TextMesh text_mesh;
	Vector3 dir;
	
	void Awake () 
	{
		mytransform = transform;
		text_mesh = GetComponent<TextMesh>();
		gameObject.active = false;
	}
	
	public void TextOn(Vector3 _pos, short _damage, Vector3 _dir)
	{
		//Debug.Log( "    dir : " +_dir);
		//"pos : "+_pos + "    DMG: "+_damage,
		text_mesh.text = _damage.ToString();
		mytransform.position = _pos+ Vector3.up*0.2f;
		dir = _dir;
		gameObject.active = true;
	}
	
	void Update () 
	{
		//g_force -= Time.deltaTime;
		finishdelay -= Time.deltaTime*2;
		if (finishdelay < 0)
		{
			finishdelay = 1;
			gameObject.active = false;
		}
		mytransform.position += (Vector3.up +dir)*finishdelay* Time.deltaTime *0.3f;
	}
}
