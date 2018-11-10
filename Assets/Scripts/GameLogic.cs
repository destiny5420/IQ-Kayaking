using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour 
{
    static GameLogic instance;
    public static GameLogic GetInstance() { return instance; }

    [SerializeField] QuestionController m_clsQuestionController;

    [SerializeField] List<LevelBlock> m_lisLevelBlocks;
    int m_iCurIndex;

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
}
