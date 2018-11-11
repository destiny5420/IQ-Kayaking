using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IQController : MonoBehaviour 
{
    [SerializeField] Text m_txtScore;
	void Start () 
    {
        m_txtScore.text = DataManager.GetInstance().GetValueIQ().ToString();

	}
	
	void Update () 
    {
		
	}
}
