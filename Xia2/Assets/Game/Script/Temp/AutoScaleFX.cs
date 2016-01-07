using UnityEngine;
using System.Collections;

public class AutoScaleFX : MonoBehaviour {
	public float scale = 2f;
	ParticleSystem []system;
	float []startSize;
	// Use this for initialization
	void Start () 
	{
		system = GetComponentsInChildren<ParticleSystem> ();
		int len = system.Length;
		startSize = new float[len];
		
		for(int i = 0; i < system.Length; i++)
		{
			if(startSize[i] == 0)
			{
				startSize[i] = system[i].startSize;
			}
		}
		UpdateScale();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	[ContextMenu("Update Scale")]
	public void UpdateScale () 
	{
		for(int i = 0; i < system.Length; i++)
		{
			system[i].startSize = startSize[i]* scale;
		}
	}

}
