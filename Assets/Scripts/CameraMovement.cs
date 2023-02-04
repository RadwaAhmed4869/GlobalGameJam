using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset = new Vector3(3, 1.2f, -10);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            player.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }

    //private void Update()
    //{

    //    transform.position = new Vector3(player.position.x + 3, player.position.y + 1, transform.position.z);
    //}
}
