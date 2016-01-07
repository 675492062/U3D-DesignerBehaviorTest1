using UnityEngine;
using System.Collections;

public class Pt_hit : MonoBehaviour
{

    bool pton = false;
    float s_delay = 0;
    ParticleEmitter myparticle;

    public ParticleSystem mParticle;
    void Start()
    {
        myparticle = GetComponent<ParticleEmitter>();

        if (myparticle != null) myparticle.emit = false;
    }

    public void ParticleOn()
    {
        gameObject.SetActive(true);
        if (myparticle != null)
        {
            myparticle.emit = true;
        }
        else
        {
            mParticle.Play();
        }
        pton = true;
    }

    void Update()
    {
        if (pton)
        {
            if (s_delay > 0.1f)
            {
                if (myparticle != null)
                {
                    myparticle.emit = false;
                }
                else
                {
                    mParticle.Stop();
                }
                pton = false;
                s_delay = 0;
            }
            else
                s_delay += Time.deltaTime;
        }
    }
}
