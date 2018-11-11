using UnityEngine;
using UnityEngine.UI;

public class AnswerShowController : MonoBehaviour
{
    [SerializeField] Animator m_anim;
    [SerializeField] Image m_imgCorrent;
    [SerializeField] Image m_imgMistake;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        HideCorrent();
        HideMistake();
    }

    public void Play(bool v_correct)
    {
        if (v_correct)
        {
            m_anim.Play("UI_Yes");
            ShowCorrent();
            HideMistake();
        }
        else
        {
            m_anim.Play("UI_No");
            ShowMistake();
            HideCorrent();
        }
    }

    void HideCorrent()
    {
        m_imgCorrent.enabled = false;
    }

    void HideMistake()
    {
        m_imgMistake.enabled = false;
    }

    void ShowCorrent()
    {
        m_imgCorrent.enabled = true;
    }

    void ShowMistake()
    {
        m_imgMistake.enabled = true;
    }
}
