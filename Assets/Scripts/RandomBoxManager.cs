using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxManager : MonoBehaviour 
{
    float m_fDelayMoveNextPointClock;
    const float m_fDelayMoveNextPointTime = 5.0f;

    void Update()
    {
        if (m_fDelayMoveNextPointClock > 0)
        {
            m_fDelayMoveNextPointClock -= Time.deltaTime;
            if (m_fDelayMoveNextPointClock <= 0)
            {
                Move();
            }
        }
    }

    public void MoveNextPoint()
    {
        m_fDelayMoveNextPointClock = m_fDelayMoveNextPointTime;
    }

    void Move()
    {
        
    }
}
