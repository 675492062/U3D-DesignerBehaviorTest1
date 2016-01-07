using UnityEngine;
using System.Collections;

public class Ef_dropItem : MonoBehaviour {
	
	bool pton = false;
	float s_delay=0;
	ParticleEmitter myparticle;
	void Start ()
	{
		myparticle = GetComponent<ParticleEmitter>();
		myparticle.emit = false;
	}
	
	public void ParticleOn()
	{
		myparticle.emit = true;
		pton = true;
	}
	
	void Update () 
	{
		if (pton)
		{
			if (s_delay>0.1f)
			{
				myparticle.emit = false;
				pton = false;
				s_delay = 0;
			}
			else
				s_delay += Time.deltaTime;
		}
	}
}
