using UnityEngine;

public class Bullet : MonoBehaviour
{

	protected Transform target;

	public float speed = 70f;

	public float damage = 50;

	public GameObject impactEffect;

	public virtual void Seek(Transform _target)
	{
		target = _target;
	}
	// Update is called once per frame
	void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	public void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);
		Damage(target);
		Destroy(gameObject);
	}

	public virtual void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}
}