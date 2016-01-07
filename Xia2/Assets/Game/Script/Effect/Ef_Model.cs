/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-10   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 用于粒子发射
/// </summary>
public class Ef_Model : MonoBehaviour
{
	Animator m_ani;
    float timeParam;

    public float delay = 0.5f;

    void Awake()
    {
		m_ani = GetComponent<Animator> ();
		m_ani.Play (0);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        timeParam = 0;
		m_ani.Play (0);
    }

    void OnDisable()
    {
		m_ani.StopPlayback ();
    }

    void Update()
    {
        timeParam += Time.deltaTime;
        if (timeParam >= delay)
        {
            //Debug.Log("OnDisable");
            gameObject.SetActive(false);
        }
    }
}
