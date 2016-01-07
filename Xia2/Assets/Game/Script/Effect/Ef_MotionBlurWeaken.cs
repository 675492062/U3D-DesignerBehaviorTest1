using UnityEngine;
using System.Collections;

public class Ef_MotionBlurWeaken : MonoBehaviour {
	MotionBlur blur;
	// Use this for initialization
	float amount = 0;
	bool  startWeaken = false;
	void Start () {
		blur = Camera.main.GetComponent<MotionBlur> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!startWeaken)
			return;
		amount += Time.deltaTime;
		blur.blurAmount -= amount;
		if (blur.blurAmount <= 0) {
			blur.enabled = false;		
			startWeaken = false;
		}
	}

	public void Stop()
	{
		blur.enabled = true;
		startWeaken = true;
		amount = 0;
	}
}
