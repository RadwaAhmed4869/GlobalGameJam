using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    #region Controlling jump height
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
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    #endregion

    #region My Test
    //private Rigidbody2D rb2D;
    //[SerializeField] private float jumpHeight;

    ////[SerializeField] private float jumpForce;

    ////[SerializeField] private float gravityScale;
    ////[SerializeField] private float fallGravityScale;

    ////public Vector3 force = new Vector3(0, 0.02f, 0);

    //private void Start()
    //{
    //    rb2D = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    #region Jump with physics
    //    if (Input.GetAxis("Vertical") > 0)
    //    {
    //        Debug.Log("Gravity = " + Physics2D.gravity.y);
    //        float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb2D.gravityScale) * -2) * rb2D.mass;
    //        Debug.Log("jump force = " + jumpForce);
    //        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    //        //rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //    }

    //    //// Jump to specific height


    //    //if(rb2D.velocity.y > 0)
    //    //{
    //    //    rb2D.gravityScale = gravityScale;
    //    //}
    //    //else
    //    //{
    //    //    rb2D.gravityScale = fallGravityScale;
    //    //}
    //    #endregion

    //}


    ////void Update()
    ////{
    ////    ////continous movement 
    ////    //transform.Translate(Vector3.right * speed * Time.deltaTime);

    ////    //if(Input.GetButtonDown("Jump"))
    ////    //{
    ////    //    transform.position += new Vector3(0, 2, 0);
    ////    //    Debug.Log("Jump!");
    ////    //}

    ////    if (Input.GetAxis("Vertical") > 0)
    ////    {
    ////        rd2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    ////    }

    ////    //y = Input.GetAxis("Vertical");

    ////    if(Input.GetAxis("Horizontal") != 0)
    ////    {
    ////        x = Input.GetAxis("Horizontal");
    ////        Vector3 movement = new Vector3(x, 0, 0);
    ////        transform.Translate(movement * speed * Time.deltaTime);
    ////    }
    ////} 
    #endregion


}
