using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonBullets : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject shield;
    private Vector2 moveDirection;

    private string PLAYER_TAG = "Player";
    //private string SHIELD_TAG = "Shield";

    private int counterToDestroy = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(PLAYER_TAG);
        //shield = GameObject.FindWithTag(SHIELD_TAG);

        if(player!= null)
        {
            moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, 5f);

        }
    }
    
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //    if (collision.CompareTag(PLAYER_TAG))
    //    {
    //        if (!PlayerSHield.shielded)
    //        {
    //            Destroy(collision.gameObject);
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            counterToDestroy++;
    //            Debug.Log(counterToDestroy);
    //            if(counterToDestroy == 5)
    //            {
    //                shield.SetActive(false);
    //            }
    //            else
    //            {
    //                Destroy(gameObject);
    //            }

    //        }
    //    }
    //}
}
