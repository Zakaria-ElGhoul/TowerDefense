using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float startHealth = 100;
	private float health;
	public GameObject deathEffect;
	public Image healthBar;

	private bool isDead = false;

	void Start()
	{
		health = startHealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;
		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		Destroy(gameObject);
	}

}