using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField][Range(0, 100)] public int HP = 100;
    private static Player instance = null;
    [SerializeField] private Vector2 respawnPoint;
    [SerializeField] bool isDead = false;

    public static Player Instance       //Property
    { 
        get => instance; 
        private set => instance = value; 
    }

    public Vector2 RespawnPoint 
    { 
        get => respawnPoint; 
        set => respawnPoint = value; 
    }

    private void Awake()
    {
        instance ??= this;
    }

    private void Start()
    {
        respawnPoint = transform.position;
    }
    private void Update()
    {
        if(HP <= 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            transform.position = respawnPoint;
            HP = 100;
            isDead = false;
        }
    }

}
