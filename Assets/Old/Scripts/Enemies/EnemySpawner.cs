using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Transform xRangeLeft, xRangeRight,yRangeUp, yRangeDown;

	public GameObject[] enemies;

	[SerializeField, Range(0,25f)] private float timeSpawn;
	[SerializeField, Range(0,25f)] private float repeatSpawn;

	private void Awake()
	{
		
	}
	private void Start()
	{
		
	}
	private void Update()
	{
		
	}
	public void SpawnEnemies()
	{
		Vector3 spawnPos = new Vector3(0, 0, 0);

		spawnPos = new Vector3(Random.Range(xRangeLeft.position.x,xRangeRight.position.x),(Random.Range(yRangeDown.position.y, yRangeUp.position.y)));

		int arrayPos = Random.Range(0,enemies.Length);
		GameObject enemy = Instantiate(enemies[arrayPos], spawnPos, gameObject.transform.rotation);



	}

}
