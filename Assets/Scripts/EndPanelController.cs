using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelController : MonoBehaviour 
{
    [SerializeField] Animator m_anim;
    [SerializeField] Image m_imgBG;
    [SerializeField] Image m_imgButton;
    [SerializeField] Button m_btnReturn;
    [SerializeField] Text m_txtScore;

	void Start () 
    {
        Init();
	}
	
    void Init()
    {
        m_anim.enabled = false;

        m_imgBG.enabled = false;
        m_imgButton.enabled = false;
        m_txtScore.enabled = false;
        m_btnReturn.interactable = false;

    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Init();
            Play();
        }
    }

    public void Play()
    {
        m_anim.enabled = true;

        m_imgBG.enabled = true;
        m_imgButton.enabled = true;
        m_txtScore.enabled = true;

        m_btnReturn.interactable = true;
        m_txtScore.text = DataManager.GetInstance().GetValueIQ().ToString();

        DataManager.GetInstance().ResetData();

    }

    public void OnReturnButton()
    {
        Debug.Log("Press");
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
