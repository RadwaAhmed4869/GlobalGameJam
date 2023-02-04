using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerinRange : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent onPlayerinRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Range"))
        {
            //  subscribe to path finding
            onPlayerinRange.Raise();
        }
    }
}
