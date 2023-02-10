using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject handAttack;

    private string FLYINGENEMY = "FlyingEnemy";
    [SerializeField] private int flyingEnemyDamage = 5;
    [SerializeField] private SmallEnemiesHealth smallHealth;

    //private string MINIBOSS = "MiniBoss";
    //[SerializeField] private int miniEnemyDamage = 50;
    //[SerializeField] private MiniBossHealth miniHealth;

    //private string BIGBOSS = "BigBoss";
    //[SerializeField] private int bigEnemyDamage = 50;
    //[SerializeField] private MiniBossHealth bigHealth;

    public float speed = 20f;
    public int damage = 40;
    //public GameObject impactEffect;

    void Update()
    {
        MeleeAttackFun();
    }
    void MeleeAttackFun()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            handAttack.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetMouseButtonUp(0))
        {
            handAttack.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(FLYINGENEMY))
        {
            smallHealth.TakeDamage(flyingEnemyDamage, collision);
        }

        BossHealth enemy = collision.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

    }
}
