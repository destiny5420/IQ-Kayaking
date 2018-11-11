using UnityEngine;
using UnityEngine.UI;
using System;

public class Answer : MonoBehaviour 
{
    SpriteRenderer m_spriteRenderModel;
    [SerializeField] Image m_img_iq_bar;
    [SerializeField] Text m_txtScoreIQ;

	public bool Correct;

    void Start()
    {
        m_spriteRenderModel = GetComponent<SpriteRenderer>();
        Init();
    }

    public void Init()
    {
        Correct = false;
        UpdateInfo();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name == "Group_Potato")
        {
            m_spriteRenderModel.enabled = false;

            if (Correct)
                HandleCorrect();
            else
                HandleMistake();

            GameLogic.GetInstance().PlayAnswerAnimation(Correct);
        }
	}

    void HandleCorrect()
    {
        DataManager.GetInstance().IncreaseIQ(10);
        UpdateInfo();
    }

    void HandleMistake()
    {
        DataManager.GetInstance().DecreaseIQ(10);
        UpdateInfo();
    }

    void UpdateInfo()
    {
        int iValueIQ = DataManager.GetInstance().GetValueIQ();
        m_txtScoreIQ.text = string.Format(iValueIQ.ToString());
        float fPrecent = iValueIQ / 180.0f;
        m_img_iq_bar.fillAmount = fPrecent;
    }

    public void SetImage(Sprite r_sprite, bool v_corrent)
    {
        m_spriteRenderModel.sprite = r_sprite;

        if (v_corrent)
            Correct = true;
    }
}
