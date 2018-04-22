using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[Header("Unity Objects to Set")]
	public Text moneyText;
	public Text livesText;

	public static int Money;
	public static int StartMoney=400;


	[Header("Lives")]
	public static int lives;
	public static int startLives = 20;

	void Start()
	{
		Money = StartMoney;
		lives = startLives;
	}

	void Update()
	{
		moneyText.text = "$"+Money.ToString ();
		livesText.text = lives.ToString ()+"LIVES";
	}

}
