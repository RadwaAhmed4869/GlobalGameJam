using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemiesHealth : MonoBehaviour
{
	public int health = 10;

	[SerializeField] private GameObject deathEffect;
	[SerializeField] private GameObject Drop;

	[SerializeField] private float dropChance = 0.4f;


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
		//Debug.Log("small enemy die");
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Debug.Log(enemy.gameObject.name);
		GameObject effect = Instantiate(deathEffect, enemy.transform.position, enemy.transform.rotation);
		Destroy(effect, 1.5f);
		//effect.transform.localPosition = Vector3.zero;

		if (Random.Range(0f, 1f) <= dropChance)
		{
			Instantiate(Drop, enemy.transform.position, enemy.transform.rotation);
		}

		Destroy(enemy.gameObject);
	}
}
