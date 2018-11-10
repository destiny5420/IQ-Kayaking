using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// public List<LevelBlock> LevelBlocks;
	[SerializeField]
	private List<LevelBlock> m_levelBlocks;
	public float CurrentWaterSurfaceLevel;


	// public LevelBlock GetRandomLevelBlock()
	// {
	// 	var randIndex = Random.Range(0, LevelBlocks.Count - 1);

	// 	if (m_levelBlocks.Count > 0 && m_levelBlocks[m_levelBlocks.Count - 1].name.ToUpper() == "DOWN")
	// 		randIndex = 5;
		
	// 	var levelBlock = LevelBlocks[randIndex];
	// 	m_levelBlocks.Add(levelBlock);

	// 	return levelBlock;
	// }

	public void AdjustWaterSurfaceLevel(float amount)
	{
		CurrentWaterSurfaceLevel += amount; 
	}

	private void Update()
	{
		foreach(var levelBlock in m_levelBlocks)
		{
			levelBlock.GetComponent<BuoyancyEffector2D>().surfaceLevel = CurrentWaterSurfaceLevel;
		}

		// var buoyancyEffectors = GetComponentsInChildren<BuoyancyEffector2D>();
		 
		// foreach(var buoyancyEffector in buoyancyEffectors)
		// {
		// 	buoyancyEffector.surfaceLevel = CurrentWaterSurfaceLevel;
		// }
	}
}
