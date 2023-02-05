using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHealth : MonoBehaviour
{
	public int health;

	[SerializeField] private GameObject deathEffect;

	private string MINIBOSS = "MiniBoss";
	private string BIGBOSS = "BigBoss";


	private void Start()
    {
		if (this.CompareTag(MINIBOSS))
		{
			health = 500;
		}
		//if (this.CompareTag(BIGBOSS))
		//{
		//	health = 500;
		//}
	}
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
		GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
		effect.transform.localPosition = Vector3.zero;
		Debug.Log(enemy.gameObject.name + " game object destroyed");
		//Destroy(enemy.gameObject);
	}
}
