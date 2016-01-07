
using UnityEngine;
using System.Collections;

public class Ef_MotionBlur : MonoBehaviour {
	bool 			m_shakeOnlyOne = false;
	float 		 	m_delay = 0;
	
	public float m_start = 0;
	public float m_end = 0;
	public float bulrAmount = 0.8f;
	public bool  extraBlur = false;

	MotionBlur blur;

	void Awake()
	{

	}
	
	void Start () 
	{
		blur = Camera.main.GetComponent<MotionBlur> ();
		blur.blurAmount = bulrAmount;
		blur.extraBlur = extraBlur;
	}

	void Update()
	{
		m_delay += Time.deltaTime;

		if (m_delay >= m_end) {
			blur.enabled = false;
			return;
		}

		if ( !m_shakeOnlyOne && m_delay >= m_start ) {
			m_shakeOnlyOne = true;
			blur.enabled = true;
		}
	}

	void OnDestroy()
	{
		if(blur != null)
			blur.enabled = false;
	}
}
