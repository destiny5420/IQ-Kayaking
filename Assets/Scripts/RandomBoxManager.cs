using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxManager : MonoBehaviour 
{
    Vector3[] m_v3ArrayPos = new Vector3[5];

    float m_fDelayMoveNextPointClock;
    const float m_fDelayMoveNextPointTime = 5.0f;

    int iCurIndex;

    void Start()
    {
        CreatePosData();

        Init();
    }

    void Init()
    {
        iCurIndex = 0;

        Move();
    }

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
        if (iCurIndex == m_v3ArrayPos.Length)
            return;

        transform.position = m_v3ArrayPos[iCurIndex];
        iCurIndex++;
    }

    void CreatePosData()
    {
        m_v3ArrayPos[0] = new Vector3(90.0f, 0.0f, 0.0f);
        m_v3ArrayPos[1] = new Vector3(180.0f, 0.0f, 0.0f);
        m_v3ArrayPos[2] = new Vector3(270.0f, 0.0f, 0.0f);
        m_v3ArrayPos[3] = new Vector3(360.0f, 0.0f, 0.0f);
        m_v3ArrayPos[4] = new Vector3(450.0f, 0.0f, 0.0f);
    }
}
