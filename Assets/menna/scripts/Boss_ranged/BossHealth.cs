using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 1000;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	[Header("Events")]
	[SerializeField] GameEvent enemyIsDead;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 500)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		// Raise event to set the emotion free
		enemyIsDead.Raise();
	}

}
