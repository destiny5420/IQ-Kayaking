using UnityEngine;
using UnityEngine.UI;
using System;

public class Answer : MonoBehaviour 
{

    [SerializeField] Image m_img_iq_bar;
    [SerializeField] Text m_img_iq_score;

	public bool Correct;

    void OnTriggerEnter2D(Collider2D other)
	{
		if (Correct)
		{
            m_img_iq_bar.fillAmount += 0.1f;
            var iq = Int32.Parse(m_img_iq_score.text) + 10;
            m_img_iq_score.text = iq.ToString();
		}
		else
		{
            m_img_iq_bar.fillAmount = m_img_iq_bar.fillAmount -= 0.1f;
            var iq = Int32.Parse(m_img_iq_score.text) - 10;
            m_img_iq_score.text = iq.ToString();
		}

		if (other.name == "Group_Potato")
			Destroy(gameObject);
	}
}
