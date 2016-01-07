using UnityEngine;
using System.Collections;

public class Ef_boom : MonoBehaviour {
	
	Transform mytransform;
	ParticleEmitter myparticle;
	Material mymaterial;
	Collider mycollider;
	//float finish_delay = 0.5f;
	
	public Texture2D[] pttex = new Texture2D[3];
	
	void Awake () 
	{
		mytransform = transform;
		myparticle = GetComponent<ParticleEmitter>();
		mymaterial = GetComponent<Renderer>().sharedMaterial;
		mycollider = GetComponent<Collider>();
	}
	
	public void SetTex(int _index, Vector3 _pos , bool _collider)
	{
		_pos[1] = 0.02f;
		mytransform.position = _pos;
		myparticle.emit = false;
		myparticle.ClearParticles();
		myparticle.emit = true;
		mymaterial.SetTexture("_MainTex",pttex[_index]);
		if (_collider)
			mycollider.enabled = true;
		//finish_delay = 0.5f;
		Invoke ("EmitStop", 0.5f);
	}
		
	
	
	void EmitStop()
	{
		myparticle.emit = false;
		mycollider.enabled = false;
		mytransform.position = Vector3.up*11;
	}
	
	/*void Update () 
	{
		if (finish_delay<0)
		{
			myparticle.emit = false;
		}
		else
			finish_delay -= Time.deltaTime;
	}*/
}
