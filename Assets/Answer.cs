using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Answer : MonoBehaviour {

	public bool Correct;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var Image = GameObject.Find("UI/Group_IQ/Image_Fill").GetComponent<Image>();
		var Text = GameObject.Find("UI/Group_IQ/Text").GetComponent<Text>();

		if (Correct)
		{
			Image.fillAmount += 0.1f;
			var iq = Int32.Parse(Text.text) + 10;
			Text.text = iq.ToString();
		}
		else
		{
			Image.fillAmount = Image.fillAmount -= 0.1f;
			var iq = Int32.Parse(Text.text) - 10;
			Text.text = iq.ToString();
		}

		if (other.name == "Group_Potato")
			Destroy(gameObject);
	}
}
