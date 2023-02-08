using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float buttonTime = 0.5f;
    [SerializeField] private float jumpHeight = 4;
    [SerializeField] private float cancelRate = 100;
    private float jumpTime;
    private bool jumping;
    private bool isGrounded;
    private bool jumpCancelled;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
            isGrounded = false;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }
    private void FixedUpdate()
    {
        //if(!isGrounded && !jumping)
        //{
        //    Debug.Log("not grounded");
        //    rb.AddForce(Vector2.down * cancelRate);
        //}
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            //Debug.Log("jumpCancelled");
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("subPlatforms"))
        {
            isGrounded = true;
        }
    }

}
