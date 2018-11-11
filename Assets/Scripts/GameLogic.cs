using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour 
{
    static GameLogic instance;
    public static GameLogic GetInstance() { return instance; }

    [SerializeField] QuestionController m_clsQuestionController;
    [SerializeField] AnswerShowController m_clsAnswerShowController;
    [SerializeField] EndPanelController m_clsEndPanelController;

    [SerializeField] List<LevelBlock> m_lisLevelBlocks;
    int m_iCurIndex;

    bool m_bTimeScale;

    void Awake()
    {
        instance = this;
    }

    void Start () 
    {
        Init();
	}
	
    void Init()
    {
        m_iCurIndex = 0;
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (m_bTimeScale == false)
            {
                Time.timeScale = 0.0f;
                m_bTimeScale = true;
            }else
            {
                Time.timeScale = 1.0f;
                m_bTimeScale = false;
            }
        }
    }

    public void ChangeQuestion()
    {
        m_clsQuestionController.SettingQuestionContent();
    }

    public void SettingAnserImage(Sprite[] r_spriteAry)
    {
        m_lisLevelBlocks[m_iCurIndex].SettingAnserImage(r_spriteAry);
        m_iCurIndex++;

        if (m_iCurIndex >= m_lisLevelBlocks.Count)
            m_iCurIndex = 0;
    }

    public void PlayAnswerAnimation(bool v_isCorrect)
    {
        m_clsAnswerShowController.Play(v_isCorrect);
    }

    public void ShowEndPanel()
    {
        m_clsEndPanelController.Play();
    }
}
