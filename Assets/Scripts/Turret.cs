using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Enemy targerEnemy;
	public Transform target; 



	[Header("Attributes")]
	public float range = 15f; 

	[Header("Use Bullets")]
	public GameObject bulletPreFab;
	public float fireRate = 1f;
	private float fireCountDown = 0f;

	[Header("Laser")]
	public bool useLaser = false;
	public LineRenderer lineReander;
	public ParticleSystem impactEffectLaser;
	public int damageOverTime = 30;
	public float slowPct = 0.5f;



	public void Upgrade()
	{
		this.fireRate = this.fireRate + 1;
	}

	public void Destroy()
	{
		Destroy (gameObject);

	}





	[Header("Unity Setup Field")]

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnspeed = 50f;

	//Shooting
	public Transform firePoint;



	void Start()
	{
		InvokeRepeating("UpradeTarget", 0f, 0.1f);
	}

	void UpradeTarget()
	{

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		GameObject nearestEnemies = null;

		float shortestDistance = Mathf.Infinity;

		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

			if (shortestDistance > distanceToEnemy) 
			{
				shortestDistance = distanceToEnemy;
				nearestEnemies = enemy;
			}
		}


		if (nearestEnemies != null && shortestDistance <= range) {
			
			target = nearestEnemies.transform;
			targerEnemy = nearestEnemies.GetComponent<Enemy>();

		} else {
			target = null;
		}

	}


	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;

		Quaternion lookRotation = Quaternion.LookRotation(dir);
		//Vector3 rotation = lookRotation.eulerAngles;
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}

	void Update()
	{
		if (target == null)
		{
			if (useLaser)
			{
				if (lineReander.enabled) 
				{
					lineReander.enabled = false;
					impactEffectLaser.Stop();

				}
			}

			return;
		}
			

		LockOnTarget ();

		if (useLaser)
		{
			Laser ();
		} 
		else 
		{
			Bullet();
		}


	}

	void Laser()
	{

		targerEnemy.Slow(slowPct);

		targerEnemy.TakeDamage (damageOverTime * Time.deltaTime);

		if (!lineReander.enabled) 
		{
			lineReander.enabled = true;
			impactEffectLaser.Play(impactEffectLaser);
		}
			
			
		lineReander.SetPosition (0, firePoint.position);
		lineReander.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffectLaser.transform.position = target.position+dir.normalized;
		impactEffectLaser.transform.rotation = Quaternion.LookRotation (dir);
	}

	void Bullet()
	{
		if (fireCountDown <= 0f) {

			Shoot ();
			fireCountDown = 1f/fireRate;
		}
		fireCountDown -= Time.deltaTime;
	}

	void Shoot()
	{
		GameObject bulletGO = (GameObject) Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);

		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null)
		{
			bullet.Seek(target);
		}
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}


}
