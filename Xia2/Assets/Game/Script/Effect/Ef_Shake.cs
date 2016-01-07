
using UnityEngine;
using System.Collections;

public class Ef_Shake : MonoBehaviour {
	bool 			m_shakeOnlyOne = false;
	float 		 	m_delay = 0;
	
	public float m_startShake = 0;

	public int	   numberOfShakes = 2;
	public Vector3 shakeAmount;
	public Vector3 rotationAmount;
	public float   distance = 0.1f;
	public float   speed = 50;
	public float   decay = 0.2f;
	public float   guiShakeModifier = 1;
	public bool    multiplyByTimeScale = true;

	void Awake()
	{

	}
	
	void Start () 
	{

	}

	void Update()
	{
		ProcessSkillShake ();
	}

	public void ProcessSkillShake()
	{
		m_delay += Time.deltaTime;

		if ( m_startShake != -1 && !m_shakeOnlyOne && m_delay >= m_startShake ) {
			m_shakeOnlyOne = true;
			ThinksquirrelSoftware.Utilities.CameraShake.Shake(numberOfShakes,shakeAmount,rotationAmount,distance,speed,decay,guiShakeModifier,multiplyByTimeScale);
		}
	}
}
