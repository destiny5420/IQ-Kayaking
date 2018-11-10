using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxController : MonoBehaviour 
{
    RandomBoxManager m_clsRandomBoxManager;
    [SerializeField] SpriteRenderer m_spriteModel;

	void Start () 
    {
        m_clsRandomBoxManager = transform.parent.GetComponent<RandomBoxManager>();
        Init();
	}

    void Init()
    {
        m_spriteModel.enabled = true;
    }

    public void Hide()
    {
        m_spriteModel.enabled = false;
        m_clsRandomBoxManager.MoveNextPoint();
    }

    public void Show()
    {
        m_spriteModel.enabled = true;
    }
}
