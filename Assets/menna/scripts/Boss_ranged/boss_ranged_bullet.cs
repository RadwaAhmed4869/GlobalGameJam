using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_ranged_bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}