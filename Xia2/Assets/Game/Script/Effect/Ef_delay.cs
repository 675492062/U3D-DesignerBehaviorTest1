using UnityEngine;
using System.Collections;

public class Ef_delay :MonoBehaviour {

	Transform 	   m_transform;
	float 		m_delay;
	public  float start;
	public 	float end;
	bool b = false;
	void Awake()
	{
		m_transform = transform;
	}
	
	void Start () 
	{
		gameObject.SetActiveRecursively(false);
		Invoke("DelayFunc", start);
	}
	
	void Update () 
	{
		if (b == false)
			return;
		m_delay += Time.deltaTime;
		if (m_delay >= end)
				Destroy (gameObject);
	}

	
	void DelayFunc()
	{
		gameObject.SetActiveRecursively(true);
		b = true;
	}
}
