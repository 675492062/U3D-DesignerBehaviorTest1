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
public class Ef_Particle : MonoBehaviour
{
    ParticleSystem mEmitter;
    float timeParam;

    public float delay = 0.5f;

    void Awake()
    {
//        mEmitter = GetComponent<ParticleSystem>();
		if (GetComponent<ParticleSystem> ())
			mEmitter = GetComponent<ParticleSystem> ();
		else
			mEmitter = gameObject.GetComponentInChildren<ParticleSystem> ();
//
        if (mEmitter == null) {
			Debug.LogError("===========-=-=-");		
			Destroy (this.gameObject);
				}
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        timeParam = 0;
        mEmitter.Play();
    }

    void OnDisable()
    {
        mEmitter.Stop();
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
