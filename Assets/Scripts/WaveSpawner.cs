using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab; 
	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public static int waveIndex =0;
	public Text countDownText;

	void Update()
	{
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown=timeBetweenWaves;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		countDownText.text = string.Format ("{0:0.00}",countdown);
	}

	IEnumerator SpawnWave ()
	{
		if (!GameManager.gameEnded) 
		{
			waveIndex++;
			for (int i = 0; i < waveIndex * 2; i++) {
				SpawnEnemy ();
				yield return new WaitForSeconds (0.5f);
			}
		}
	}

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
	}






}
