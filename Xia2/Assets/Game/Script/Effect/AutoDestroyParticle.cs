using UnityEngine;
using System.Collections;

public class AutoDestroyParticle : MonoBehaviour {
	private ParticleSystem []system;
	private float delTime;
	public float maxLifeTime = 2.5f;
	// Use this for initialization
	void Start () {
		system = GetComponentsInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		delTime += Time.deltaTime;
		if (delTime >= maxLifeTime) 
		{
			Destroy(this.gameObject);		
		}
	}
}
