/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-06   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;


public class Ef_AutoPlay : MonoBehaviour
{
    ParticleSystem mEmitter;

    void Awake()
    {
        mEmitter = GetComponent<ParticleSystem>();
        if (mEmitter == null) Destroy(this.gameObject);
    }

    void OnEnable()
    {
        mEmitter.Play();
    }

    void OnDisable()
    {
        mEmitter.Stop();
    }
}
