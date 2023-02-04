using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private void Start()
    {
        offset = new Vector3(4f, 3.3f, -10);
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                player.position + offset,
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
