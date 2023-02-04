using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemiesHealth : MonoBehaviour
{
	public int health = 10;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage, Collider2D enemy)
	{
		health -= damage;

		if (health <= 0)
		{
			Die(enemy);
		}
	}

	void Die(Collider2D enemy)
	{
		Debug.Log("small enemy die");
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(enemy.gameObject);
	}
}
