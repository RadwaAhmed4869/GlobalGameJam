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
    [SerializeField] private Transform shield;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    bool rootAttack = false;
    bool basicAttack = false;
    bool Jumpeffect = false;
    private void Update()
    {
        if (rootAttack)
        {
            anim.SetBool("IsRootAttacking", false);
        }
        if (basicAttack)
        {
            anim.SetBool("IsBasicAttacking", false);
        }

        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("IsBasicAttacking", true);
            basicAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("IsRootAttacking", true);
            rootAttack = true;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
            meleeAttack.localPosition = new Vector2(0.2f, meleeAttack.localPosition.y);
            shield.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,transform.localScale.z);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
            meleeAttack.localPosition = new Vector2(-0.2f, meleeAttack.localPosition.y);
            shield.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
