using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemiesHealth : MonoBehaviour
{
	public int health = 50;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("small enemy die");
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
