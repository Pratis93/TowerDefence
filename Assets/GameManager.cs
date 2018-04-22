using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool gameEnded = false;
	public GameObject gameOverUI;
	public Text round; 


	// Update is called once per frame
	void Update () {
		
		if (gameEnded) 
		{
			return;
		} else
		{
			gameOverUI.SetActive (gameEnded);
		}

		
		if (PlayerStats.lives <= 0)
		{
			EndGame();
		}



	}

	void Start()
	{
		gameOverUI.SetActive (gameEnded);
	}


	void EndGame()
	{
		gameEnded = true;
		gameOverUI.SetActive (gameEnded);
		round.text = WaveSpawner.waveIndex.ToString ();


		Debug.Log ("GameOver");
	}
}
