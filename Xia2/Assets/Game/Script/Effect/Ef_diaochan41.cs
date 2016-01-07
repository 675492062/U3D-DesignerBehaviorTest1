using UnityEngine;
using System.Collections;

//< 貂蝉技能2 回旋扇
public class Ef_diaochan41: Ef_base {

	BeizerCurve m_beizer = new BeizerCurve();

	public Vector3    m_targetPos = new Vector3();
	public float	  m_speed = 300;
	public float 	  m_angle;
		
	public int m_stat = 1;

	Vector3	m_oldPos = new Vector3();
	Vector3	m_curPos = new Vector3();

	public void Awake()
	{
		base.Awake ();
	}

		
	void Start () {
		m_transform = transform;
		m_collider = GetComponent<Collider>();

		if (m_angle == 1)
			m_beizer.m_x = m_user.right;
		else
			m_beizer.m_x = -m_user.right;

		Reset (m_transform.position + m_user.forward * 2);
	}

	void Reset( Vector3 targetPos )
	{
		m_beizer.Init ();
		m_curPos = m_transform.position;
		m_targetPos = targetPos;
		m_beizer.SetNodePt ( m_transform.position,m_targetPos,false );
		m_oldPos.x = m_transform.position.x;
		m_oldPos.y = m_transform.position.y;
		m_oldPos.z = m_transform.position.z;
		m_beizer.SetDestNodePt( m_targetPos );
		m_beizer.BezierCurve3();
	}

	void Update () {
		switch (m_stat) {
		case 1:
			if (CurveFollowTargetFxUpdate ()) {
				Reset( m_user.position );	
				m_stat = 2;
			}
			break;
		case 2:
			if( BackUpdate() )
			{
				m_stat = 3;
			}
			break;
		case 3:
			{
			if( BackLineUpdate() )
				{
					Destroy(gameObject);
				}
			}
			break;
		}

	}

	//返回 1成功 返回0 false 返回 -1错误的
	public bool	CurveFollowTargetFxUpdate( )
	{
		Vector3 vdir;

		m_curPos =  m_transform.position;

		Vector3	dest = m_beizer.GetCurDestPt();
		
		vdir = dest - m_transform.position;
		vdir.Normalize();

		m_transform.position += vdir * Time.deltaTime * 1.5f;
		m_transform.rotation = Quaternion.LookRotation (vdir);

		float nLength2 = Vector3.Distance (m_transform.position, m_oldPos);
		float nLength1 = Vector3.Distance (dest, m_oldPos);
		bool bActive = false;
	
		if (nLength2 >= nLength1)
			bActive = true;

		if( bActive )
		{
			if(  m_beizer.DestIsLastNode() )
			{
				return true;
			}
			else
			{
				m_beizer.m_nCurNodeDest++;
				m_oldPos = dest;
				dest = m_beizer.GetCurDestPt();
			}
		}
		return false;
	}

	//返回 1成功 返回0 false 返回 -1错误的
	public bool	BackUpdate( )
	{
		Vector3 vdir;
		
		m_curPos =  m_transform.position;
		
		Vector3	dest = m_beizer.GetCurDestPt();
		
		vdir = dest - m_transform.position;
		vdir.Normalize();
		
		m_transform.position += vdir * Time.deltaTime * 1.5f;
		m_transform.rotation = Quaternion.LookRotation (vdir);
		
		float nLength2 = Vector3.Distance (m_transform.position, m_oldPos);
		float nLength1 = Vector3.Distance (dest, m_oldPos);
		bool bActive = false;
		
		if (nLength2 >= nLength1)
			bActive = true;
		
		if( bActive )
		{
			if(  m_beizer.GetCurNode() - 5 > 0 )
			{
				return true;
			}
			else
			{
				m_beizer.m_nCurNodeDest++;
				m_oldPos = dest;
				dest = m_beizer.GetCurDestPt();
			}
		}
		return false;
	}

	public bool BackLineUpdate()
	{
		Vector3 vdir;
		
		m_curPos =  m_transform.position;
		
		vdir = m_user.position - m_transform.position;
		vdir.Normalize();
		m_transform.rotation = Quaternion.LookRotation (vdir);
		m_transform.position += vdir * Time.deltaTime * 1.5f;

		float len = Vector3.Distance (m_transform.position, m_user.position);
		if (len <= 0.1f) {
			return true;		
		}
		return false;
	}
}
