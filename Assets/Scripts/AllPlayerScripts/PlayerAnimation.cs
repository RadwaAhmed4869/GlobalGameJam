using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private Transform meleeAttack;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
            meleeAttack.localPosition = new Vector2(0.2f, meleeAttack.localPosition.y);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
            meleeAttack.localPosition = new Vector2(-0.2f, meleeAttack.localPosition.y);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (rb2D.velocity.y > .1f)
        {
            anim.SetBool("isJumping", true);
        }
        else if (rb2D.velocity.y < -.1f)
        {
            anim.SetBool("isJumping", false);
        }
    }
}
