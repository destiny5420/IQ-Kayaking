using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour {

	public Image m_image;
	public Text m_text;
	public int RUDDER_FORCE;
	public Transform m_topRudder;
	public Transform m_botRudder;
	public GameObject m_topArrow;
	public GameObject m_botArrow;
	public LevelManager m_levelManager;
    [SerializeField] float m_fSpeed = 20.0f;
    bool m_bTrigger;

    float m_fDelayOpenTriggerClock;
    float m_fDelayOpenTriggerTime = 3.0f;

	private Rigidbody2D m_rigidbody2d
	{
		get
		{
			return GetComponent<Rigidbody2D>();
		}
	}

	private Vector2 m_faceDirection
	{
		get
		{
			return transform.right;
		}
	}

	private void Update()
    {
        if (m_fDelayOpenTriggerClock > 0)
        {
            m_fDelayOpenTriggerClock -= Time.deltaTime;

            if (m_fDelayOpenTriggerClock <= 0.0f)
                OnDelayOpenTriggerComplete();
        }

        // if (transform.eulerAngles.z < 90 && transform.eulerAngles.z > 0)
		// 	m_rigidbody2d.AddForceAtPosition(m_faceDirection * RUDDER_FORCE * Time.deltaTime, m_topRudder.position);
			
		// if (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 270)
		// 	m_rigidbody2d.AddForceAtPosition(m_faceDirection * RUDDER_FORCE * Time.deltaTime, m_botRudder.position);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //print("left shift was pressed");
			m_rigidbody2d.AddForceAtPosition(m_faceDirection * RUDDER_FORCE, m_topRudder.position);
			m_rigidbody2d.AddForceAtPosition(new Vector3(0, -1, 0) * RUDDER_FORCE / 2, m_topRudder.position);
			StartCoroutine(DisplayArrow(m_botArrow));

			m_levelManager.AdjustWaterSurfaceLevel(-1f);
        }

		if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //print("right shift was pressed");
			m_rigidbody2d.AddForceAtPosition(m_faceDirection * RUDDER_FORCE, m_botRudder.position);
			m_rigidbody2d.AddForceAtPosition(new Vector3(0, 1, 0) * RUDDER_FORCE / 2, m_topRudder.position);
			StartCoroutine(DisplayArrow(m_topArrow));

			m_levelManager.AdjustWaterSurfaceLevel(1f);
        }

        if (m_rigidbody2d.velocity.x > m_fSpeed)
            m_rigidbody2d.velocity = new Vector3(m_fSpeed, m_rigidbody2d.velocity.y);

		// speed
		// m_image.fillAmount = m_rigidbody2d.velocity.x / 20.0f;
		// m_text.text = m_rigidbody2d.velocity.x.ToString();
    }

	private IEnumerator DisplayArrow(GameObject obj)
	{
		obj.SetActive(true);

		yield return new WaitForSeconds(0.2f);

		obj.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "col")
        {
            if (m_bTrigger == true)
                return;

            m_bTrigger = true;

            RandomBoxController clsRandomBox = collision.transform.parent.parent.GetComponent<RandomBoxController>();
            clsRandomBox.Hide();

            m_fDelayOpenTriggerClock = m_fDelayOpenTriggerTime;
        }
    }

    void OnDelayOpenTriggerComplete()
    {
        m_bTrigger = false;
    }
}
