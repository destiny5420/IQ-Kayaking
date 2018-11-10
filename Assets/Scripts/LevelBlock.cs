using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlock : MonoBehaviour {

	public GameObject m_answerA;
	public GameObject m_answerB;

	private LevelManager m_levelManager
	{
		get
		{
			return transform.root.GetComponent<LevelManager>();
		}
	}


	// private void OnBecameVisible() {

	// 	var spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
	// 	var spawnLocation = new Vector3(transform.position.x + spriteWidth, transform.position.y, transform.position.z);

	// 	var randLevelBlock = m_levelManager.GetRandomLevelBlock();

	// 	var levelBlock = Instantiate(randLevelBlock, spawnLocation, transform.rotation);

	// 	levelBlock.transform.parent = m_levelManager.transform;

	// 	levelBlock.GetComponent<BuoyancyEffector2D>().surfaceLevel = m_levelManager.CurrentWaterSurfaceLevel;
	// }

	// private void OnBecameInvisible()
	// {
	// 	Destroy(gameObject);
	// }
}