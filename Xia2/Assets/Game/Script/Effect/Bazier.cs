using UnityEngine;
using System.Collections;


public class BeizerCurve  {
	public const int CURVE_PT3 = 3;   //三个控制点
	public const int CURVE_PT4 = 4;   //四个控制点
	public const int CURVE_SEGMENT = 40;  //分成多少段 //把起始到终点抛物线分成10断
	public const int CURVE_PTNUM = CURVE_SEGMENT + 1; //共多少个点
	public const int CURVE_MAXPT = 100; 	//最多100个

	public Vector3[]		m_aPtNode = new Vector3[CURVE_PT4];
	Vector3[]		m_aPts = new Vector3[CURVE_MAXPT];
	Vector3			m_curveDir = new Vector3 ();
	Vector3			m_ptStart = new Vector3();

	float		    	m_nSegNum;
	int	  		  		m_nPtNum;
	public int			m_nCurNodeDest;//物体移动的目标点
	
	public Vector3		m_x;

	public void Init( int segNum = CURVE_SEGMENT )
	{
		m_nCurNodeDest = 1;
		
		if( segNum >= CURVE_MAXPT-1 )
		{
			segNum = CURVE_MAXPT-1;
		}

		m_nSegNum	= segNum;
		m_nPtNum	= (int)m_nSegNum + 1;
	}

	public void BezierCurve3()
	{
		if( (int)m_aPtNode[0].x == (int)m_aPtNode[2].x &&
		   (int)m_aPtNode[0].y == (int)m_aPtNode[2].y &&
		   (int)m_aPtNode[0].z == (int)m_aPtNode[2].z )
			return;
		
		
		int index = 0;   
		//double percent = 1.0/CURVE_SEGMENT;
		double percent = 1.0f/m_nSegNum;
		//for (double t = index * percent; t < 1; t+= percent)    
		for (double t = 0; t < 1; t+= percent)    
		{   
			double t2 = t*t,   t_2 = (1-t)*(1-t);    
			double t3 = t2*t,  t_3 = (1-t)*t_2;   
			
			m_aPts[index].x =(float)(t_3 * m_aPtNode[0].x + 3*t*t_2 * m_aPtNode[1].x + 3*t2*(1-t)*m_aPtNode[2].x + t3*m_aPtNode[2].x);     
			m_aPts[index].y =(float)(t_3 * m_aPtNode[0].y + 3*t*t_2 * m_aPtNode[1].y + 3*t2*(1-t)*m_aPtNode[2].y + t3*m_aPtNode[2].y);     
			m_aPts[index].z =(float)(t_3 * m_aPtNode[0].z + 3*t*t_2 * m_aPtNode[1].z + 3*t2*(1-t)*m_aPtNode[2].z + t3*m_aPtNode[2].z);
			
			index++;   
		}   
		
		//int endPt = CURVE_PTNUM-1;
		int endPt = m_nPtNum-1;
		m_aPts[endPt].x = m_aPtNode[2].x;
		m_aPts[endPt].z = m_aPtNode[2].z;   
		m_aPts[endPt].y = m_aPtNode[2].y; 
	}

	public void SetNodePt( Vector3 ptStart, Vector3 ptEnd, bool bReset /*= false*/ )
	{
		if( bReset )
		{
			Init();
			m_ptStart = ptStart;
		}

		m_aPtNode[0] = ptStart;
		m_aPtNode[2] = ptEnd;
		
		//calc middle pt
		CalcDir();
	}

	public void SetDestNodePt( Vector3 ptEnd )
	{
		m_aPtNode[2] = ptEnd;
		CalcDir();
	}

	public bool DestIsLastNode()
	{ 
		return m_nPtNum-1 == m_nCurNodeDest; 
	}

	public int GetCurNode()
	{ 
		return m_nCurNodeDest; 
	}
	
	public void CalcDir()
	{
		m_curveDir = m_aPtNode[2] - m_ptStart;
		m_curveDir.Normalize();
		//calc middle pt
		m_aPtNode[1] = ( m_ptStart + m_aPtNode[2] ) / 2.0f;
		//m_aPtNode3[1].m_fY += 150.0f;
		
		float dis = Vector3.Distance (m_aPtNode [2], m_ptStart);
		//m_aPtNode [1] += GameObject.FindGameObjectWithTag("Player").transform.right * 1;// dis * 100.1f;
		m_aPtNode [1] += m_x * 0.3f;// dis * 100.1f;
	//	Debug.LogError ("-----" + dis);
		//m_aPtNode[1].x += dis * m_angle;
		//m_aPtNode[1].y += dis * 0.05f;
		//Vector3 cro = Vector3.Cross (m_aPtNode [2], m_ptStart);
		//cro.Normalize ();
		//m_aPtNode [1] += cro * 10;

	}

	public Vector3 GetCurDestPt()
	{
		return m_aPts[m_nCurNodeDest];
	}

}
