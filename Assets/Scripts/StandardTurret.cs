using UnityEngine;
using System.Collections;

public class StandardTurret : MonoBehaviour
{
	public float range = 15f;
	public float fireRate = 1f;
	public float turnSpeed = 10f;
	private Transform target;
	private Enemy targetEnemy;

	[Header("Bullet attributes")]
	public GameObject bulletPrefab;

	private float fireCountdown = 0f;

	[Header("Turret attributes")]
	public Transform partToRotate;
	public GameObject shootParticles;
	public Transform firePoint;

	[Header("Audio")]
	public AudioSource source;
	public AudioClip shootSFX;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (target == null)
		{ 
			return;
		}
			OnTargetSeek();
	}

	void OnTargetSeek()
	{
		if (fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1 / fireRate;
		}
		fireCountdown -= Time.deltaTime;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

	}

	void Shoot()
	{
		GameObject shootVFX = (GameObject)Instantiate(shootParticles, firePoint.position, firePoint.rotation);
		Destroy(shootVFX,1);
		source.PlayOneShot(shootSFX);
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}