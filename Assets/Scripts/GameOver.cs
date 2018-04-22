using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public string turretTag = "Turret";
	public string enemyTag = "Enemy";


	public void Retry()
	{
		GameManager.gameEnded=false;
		PlayerStats.Money = PlayerStats.StartMoney;
		PlayerStats.lives = PlayerStats.startLives;
		WaveSpawner.waveIndex = 0;


		GameObject[] turrets = null;

		turrets = GameObject.FindGameObjectsWithTag(turretTag);

		foreach(GameObject turret in turrets)
		{
			Destroy (turret);
		}

		GameObject[] enemys = null;
		enemys = GameObject.FindGameObjectsWithTag (enemyTag);

		foreach(GameObject enemy in enemys)
		{
			Destroy (enemy);
		}

	}


	void menu()
	{
		Debug.Log ("GameOver -> menu() TODO:Menu");
	}
	 
		

}
