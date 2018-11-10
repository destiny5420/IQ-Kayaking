using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour 
{
    static GameLogic instance;
    public GameLogic GetInstance() { return instance; }

    [SerializeField] QuestionController m_clsQuestionController;

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
}
