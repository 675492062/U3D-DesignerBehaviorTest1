using UnityEngine;
using System.Collections;

public class Ef_fixed : Ef_base
{

    public float m_spaceTrigger = 0;
    public bool m_followMe = false;

    float m_spaceCount = 0;

    void Awake()
    {
        base.Awake();
        m_transform = transform;
        m_collider = GetComponent<Collider>();
    }

    void Start()
    {
        m_localScale = m_transform.localScale;
        if (m_collider)
            m_collider.enabled = false;
        if (m_spaceTrigger > 0)
            m_spaceTrigger = 0.5f;
    }

    void Update()
    {
        m_delay += Time.deltaTime;
        if (m_followMe)
        {
            Ef_base.GetPosByType(m_transform, this.m_user, m_posType, m_rotationWithTarget);
        }
        m_transform.localScale = m_localScale;

        if (m_endDelay != -1 && m_delay >= m_endDelay)
            Destroy(gameObject);

        if (m_delay >= m_endTrigger && m_endTrigger != -1)
        {
            if (m_collider)
                m_collider.enabled = false;
            return;
        }

        if (m_spaceTrigger == 0)
        {
            if (m_collider)
                m_collider.enabled = true;
        }
        else
        {
            m_spaceCount += Time.deltaTime;

            if (m_spaceCount <= m_spaceTrigger - 0.05f)
            {
                m_collider.enabled = true;
            }
            else if (m_spaceCount >= m_spaceTrigger)
            {
                m_collider.enabled = false;
                m_spaceCount = 0;
            }
        }
    }
}
