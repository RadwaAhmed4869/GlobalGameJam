using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ranged : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    private float shootCoolDown;
    public float startShootCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        shootCoolDown = startShootCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;

        if(shootCoolDown <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootCoolDown = startShootCoolDown;
        }
        else
        {
            shootCoolDown -= Time.deltaTime;
        }
    }
}
