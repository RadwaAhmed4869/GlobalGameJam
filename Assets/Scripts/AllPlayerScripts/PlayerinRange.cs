using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerinRange : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent onPlayerinRange;
    [SerializeField] GameEvent onPlayerinRangeTwo;


    [SerializeField] GameObject MiniBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Range"))
        {
            //  subscribe to path finding
            onPlayerinRange.Raise();
        }

        if (collision.CompareTag("Range2"))
        {
            //  subscribe to path finding
            onPlayerinRangeTwo.Raise();
        }

        if (collision.CompareTag("MiniBossRange"))
        {
            //Debug.Log("MiniBossRange");
            if (MiniBoss != null)
            {
                MiniBoss.SetActive(true);

            }
        }
    }
}
