using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

	[Header("Unity Add Obiect")]

	public GameObject dieEffect;

	public float startspeed = 10f;
	[HideInInspector]
	public float speed;
	public int value=50;
	public float health;
	public float startHealth=100;

	public Image healthBar;




	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health/startHealth;


		if (health <= 0)
		{
			Die ();
		}
	}

	public void Slow (float _slow)
	{
		speed = startspeed * _slow;
	}

	void Die()
	{
		GameObject g = (GameObject)Instantiate (dieEffect, transform.position, transform.rotation);
		Destroy (g,3f);
		PlayerStats.Money = PlayerStats.Money + value;
		Destroy (gameObject);
	}


	private Transform target;
	private int wavepointIndex =0;

	void Start()
	{
		speed = startspeed;
		target = WayPoints.points [0];

		health = startHealth;
	}

	void Update()
	{

		Vector3 dir = target.position - transform.position;

		transform.Translate (dir.normalized * speed * Time.deltaTime,Space.World );

		if (Vector3.Distance (target.position, transform.position) < 0.6F) 
		{
			GetNextWaypoint();
		}

		speed = startspeed;
	}

	void EndPath()
	{
		if (!GameManager.gameEnded)
		{
			PlayerStats.lives--;
		}

		Destroy (gameObject);
	}

	void GetNextWaypoint()
	{

		if (wavepointIndex >= WayPoints.points.Length-1) {
			EndPath ();
			return;
		}

		wavepointIndex++;
		target = WayPoints.points[wavepointIndex];
	}



}
