using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour 
{
    [SerializeField] Text m_txtQuestionContent;

	void Start () 
    {
        
	}
	
    public void Init()
    {
        m_txtQuestionContent.text = "";
    }

	void Update () 
    {

    }

    public void SettingQuestionContent()
    {
        string sQuestion = DataManager.GetInstance().GetQuestion();
        m_txtQuestionContent.text = sQuestion;
    }
}
