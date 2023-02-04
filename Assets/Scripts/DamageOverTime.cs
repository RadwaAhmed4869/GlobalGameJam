using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField][Range(0, 10)] int tick = 1;
    [SerializeField] bool EnteredDOTZone = false;
    [SerializeField] float timer = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            EnteredDOTZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            EnteredDOTZone = false;
        }
    }
    private void Update()
    {
        ApplyTickPerSecond(EnteredDOTZone);
    }

    private void ApplyTickPerSecond(bool state)
    {
        if (state == false) return;
        else if(Player.Instance.HP <= 0)
        {
            //Player Die
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 1;
                //Debug.Log("Player HP = " + Player.Instance.HP);
                Player.Instance.HP -= tick;
            }
        }
    }

}
