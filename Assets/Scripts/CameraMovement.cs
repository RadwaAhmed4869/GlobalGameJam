using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody2D rb2D;
    private Vector3 offsetRight = new Vector3(4f, 2.8f, -10);
    private Vector3 offsetLeft = new Vector3(-4f, 2.8f, -10);
    private Vector3 currentOffset;
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private void Start()
    {
        rb2D = player.GetComponent<Rigidbody2D>();
        currentOffset = offsetRight;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            if (rb2D.velocity.x > 0)
            {
                currentOffset = Vector3.Lerp(currentOffset, offsetRight, 1f);
            }
            else if(rb2D.velocity.x < 0)
            {
                currentOffset = Vector3.Lerp(currentOffset, offsetLeft, 1f);
            }
            transform.position = Vector3.SmoothDamp(
                transform.position,
                player.position + currentOffset,
                ref currentVelocity,
                smoothTime
                );
        }
    }

    //private void Update()
    //{

    //    transform.position = new Vector3(player.position.x + 3, player.position.y + 1, transform.position.z);
    //}
}
