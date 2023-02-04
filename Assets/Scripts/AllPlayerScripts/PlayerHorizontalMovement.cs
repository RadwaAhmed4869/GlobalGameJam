using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float x, y;
    [SerializeField] private float speed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if(rb2D.bodyType == RigidbodyType2D.Dynamic)
            rb2D.velocity = new Vector2(x * speed, rb2D.velocity.y);
        
        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    //Debug.Log("speed: " + speed);
        //    x = Input.GetAxis("Horizontal");
        //    Vector3 movement = new Vector3(x, 0, 0);
        //    transform.Translate(movement * speed * Time.deltaTime);
        //}
    }
    
}
