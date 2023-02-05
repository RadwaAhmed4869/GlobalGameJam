using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 1000)] public float maxHealth = 100;
    [SerializeField] [Range(0, 1000)] public float currentHealth = 50;
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
        if (currentHealth <= 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            transform.position = respawnPoint;
            currentHealth = 100;
            isDead = false;
        }
    }

}