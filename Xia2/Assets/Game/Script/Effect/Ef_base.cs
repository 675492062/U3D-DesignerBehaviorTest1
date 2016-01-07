using UnityEngine;
using System.Collections;

public class Ef_base : MonoBehaviour {
	
	protected Transform 	m_transform;
	protected float 		m_delay = 0;
	protected bool			m_start = false;
	protected Collider		m_collider;
	protected bool			m_isTrigger = false;
	protected Vector3		m_localScale;
	
	public int		   m_posType;
	public bool		   m_rotationWithTarget;
	public Unit	       m_scriptUser{ set; get;}
	public Transform   m_user{ set; get;}
	public int		   m_skillId{ set; get;}
	public float[] 	   m_param;

	public float m_endDelay = 1;
	public float m_startTrigger = -1;
	public float m_endTrigger = -1;
	public float m_radius = 0.35f;

	public void Awake()
	{
		m_param = new float[4];
	}


	static public void GetPosByType( Transform fx, Transform target,int type,bool isRotation )
	{
		if (!target)
			return;
		
		if (isRotation)
			fx.rotation = target.rotation;
		
		switch( type )
		{
		case 0: //down
		{
			fx.position = target.position; 		
		}
			break;
		case 1: //up
		{
			float h = target.GetComponent<Unit>().GetModeHeight();
			fx.position = target.position + Vector3.up * h; 		
		}
			break;
		case 2: //mid
		{
			float h = target.GetComponent<Unit>().GetModeHeight() / 2;
			fx.position = target.position + Vector3.up * h;
		}
			break;
		case 3: //left
		{
			fx.position = target.GetComponent<Unit>().GetLeftHandPos();
		}
			break;
		case 4: //right
		{
			fx.position = target.GetComponent<Unit>().GetRightHandPos();
			break;
		}
		case 5: //bip up
		{
			Vector3 pos = target.GetComponent<Unit>().GetModPos();
			float h =  target.GetComponent<Unit>().GetModeHeight() / 2;
			fx.position = pos + Vector3.up * h; 		
		}break;
		case 6: //bip down
		{
			Vector3 pos = target.GetComponent<Unit>().GetModPos();
			float h = target.GetComponent<Unit>().GetModeHeight() / 2;
			fx.position = pos - Vector3.up * h; 
			fx.position += Vector3.up * 0.006f;
		}break;
		case 7: //bip mid
		{
			Vector3 pos = target.GetComponent<Unit>().GetModPos();
			fx.position = pos;
		}break;
		default:
		{
			Debug.LogError("======PosType = " + type);
		}break;
		}
	}
}
