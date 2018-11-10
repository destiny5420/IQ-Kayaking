using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxManager : MonoBehaviour 
{
    Vector3[] m_v3ArrayPos = new Vector3[8];
    [SerializeField] RandomBoxController[] m_clsAryRandomBoxControllers;

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

        for (int i = 0; i < m_clsAryRandomBoxControllers.Length; i++)
            m_clsAryRandomBoxControllers[i].Show();

        transform.position = m_v3ArrayPos[iCurIndex];
        iCurIndex++;
    }

    void CreatePosData()
    {
        m_v3ArrayPos[0] = new Vector3(90.0f, 0.0f, 0.0f);
        m_v3ArrayPos[1] = new Vector3(220.0f, 0.0f, 0.0f);
        m_v3ArrayPos[2] = new Vector3(340.0f, 0.0f, 0.0f);
        m_v3ArrayPos[3] = new Vector3(420.0f, 0.0f, 0.0f);
        m_v3ArrayPos[4] = new Vector3(520.0f, 0.0f, 0.0f);
        m_v3ArrayPos[5] = new Vector3(678.0f, 0.0f, 0.0f);
        m_v3ArrayPos[6] = new Vector3(777.0f, 0.0f, 0.0f);
        m_v3ArrayPos[7] = new Vector3(930.0f, 0.0f, 0.0f);
    }
}
