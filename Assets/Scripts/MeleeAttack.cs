using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject handAttack;

    private string FlyingEnemy = "FlyingEnemy";
    private string MINIBOSS = "MiniBoss";
    private string BIGBOSS = "BigBoss";
    [SerializeField] private SmallEnemiesHealth smallHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (collision.CompareTag(FlyingEnemy))
        {
            smallHealth.TakeDamage(5);
        }
    }
}
