using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWithEnemy : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private int ShieldShotNum;
    private int counterShield = 0;

    private string SHIELD_TAG = "Shield";

    private void Update()
    {
        if (counterShield == ShieldShotNum)
        {
            shield.SetActive(false);
            counterShield = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(SHIELD_TAG))
        {
            counterShield++;
        }
    }

}
