using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemiesHealth : MonoBehaviour
{
	public int health = 10;

	[SerializeField] private GameObject deathEffect;
	[SerializeField] private GameObject Drop;

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
		Debug.Log(enemy.gameObject.name);
		GameObject effect = Instantiate(deathEffect, enemy.transform.position, enemy.transform.rotation);
		//effect.transform.localPosition = Vector3.zero;

		Destroy(enemy.gameObject);

		Instantiate(Drop, transform.position, transform.rotation);
	}
}
