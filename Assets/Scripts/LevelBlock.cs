using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelBlock : MonoBehaviour {

	public GameObject m_answerA;
	public GameObject m_answerB;

    [SerializeField] Answer m_clsAnswerA;
    [SerializeField] Answer m_clsAnswerB;

    public void SettingAnserImage(Sprite[] r_spriteAry)
    {
        int iNum = Random.Range(0,2);

        if (iNum % 2 == 0)
        {
            m_clsAnswerA.SetImage(r_spriteAry[0], true);
            m_clsAnswerB.SetImage(r_spriteAry[1], false);
        }
        else
        {
            m_clsAnswerB.SetImage(r_spriteAry[0], true);
            m_clsAnswerA.SetImage(r_spriteAry[1], false);
        }
    }
}