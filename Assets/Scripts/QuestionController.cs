using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionController : MonoBehaviour 
{
    [SerializeField] Text m_txtQuestionContent;

    List<string> m_lisTempData;
    bool m_bStartRandom;

    const float m_fRandomInteral = 0.035f;
    float m_fRandomClock;

    float m_fCD_Clock;
    const float m_fCD_Time = 1.5f;

	void Start () 
    {
        
	}
	
    public void Init()
    {
        m_txtQuestionContent.text = "";
    }

	void Update () 
    {
        if (m_bStartRandom == true)
        {
            if (m_fRandomClock > 0.0f)
            {
                m_fRandomClock -= Time.deltaTime;
                if (m_fRandomClock <= 0.0f)
                {
                    m_fRandomClock = m_fRandomInteral;
                    int iIndex = Random.Range(0, m_lisTempData.Count);
                    m_txtQuestionContent.text = m_lisTempData[iIndex];
                }
            }
        }

        if (m_fCD_Clock > 0.0f)
        {
            m_fCD_Clock -= Time.deltaTime;
            if (m_fCD_Clock <= 0.0f)
            {
                OnCDComplete();

            }
        }
    }

    public void SettingQuestionContent()
    {
        m_lisTempData = DataManager.GetInstance().GetStringData();
        m_bStartRandom = true;
        m_fRandomClock = m_fRandomInteral;
        m_fCD_Clock = m_fCD_Time;
    }

    void OnCDComplete()
    {
        m_bStartRandom = false;
        string sQuestion = DataManager.GetInstance().GetQuestion();
        m_txtQuestionContent.text = sQuestion;
    }
}
