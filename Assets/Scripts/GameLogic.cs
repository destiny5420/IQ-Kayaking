using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour 
{
    static GameLogic instance;
    public static GameLogic GetInstance() { return instance; }

    [SerializeField] QuestionController m_clsQuestionController;

    [SerializeField] List<LevelBlock> m_lisLevelBlocks;

    void Awake()
    {
        instance = this;
    }

    void Start () 
    {
        
	}
	
	void Update () 
    {
		
	}

    public void ChangeQuestion()
    {
        m_clsQuestionController.SettingQuestionContent();
    }

    public void SettingAnserImage(int v_index, Sprite[] r_spriteAry)
    {
        m_lisLevelBlocks[v_index].SettingAnserImage(r_spriteAry);
    }
}
