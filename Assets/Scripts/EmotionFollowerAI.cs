using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EmotionFollowerAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private void Start()
    {
        offset = new Vector3(-0.7f, 1.05f, 0);
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

    //[SerializeField] private Transform player;
    //[SerializeField] private float speed = 4f;
    //[SerializeField] private float nextWayPointDistance = 3f;

    //[SerializeField] private Transform followerGFX;

    //private Path pathToPlayer;
    //private int currentWaypoint = 0;
    //private bool reachedEndofPath = false;

    //private Seeker seeker;
    //private Rigidbody2D rb;
    ////private Animator anim;

    //float distanceTravelled;

    //private float followerScale;

    //[SerializeField] private GameObject bullet;

    //private float fireRate;
    //private float nextFire;

    //void Start()
    //{
    //    followerScale = transform.localScale.x;
    //    fireRate = 2f;
    //    nextFire = Time.time;

    //    seeker = GetComponent<Seeker>();
    //    rb = GetComponent<Rigidbody2D>();
    //    //anim = GetComponent<Animator>();
    //}

    //public void PlayerInRange()
    //{
    //    InvokeRepeating("UpdatePath", 0f, 0.5f);
    //    //isPlayerInRange = true;
    //}

    //void UpdatePath()
    //{
    //    if (seeker.IsDone() && player != null)
    //        seeker.StartPath(rb.position, player.position, OnPathComplete);
    //}

    //void OnPathComplete(Path p)
    //{
    //    if (!p.error)
    //    {
    //        pathToPlayer = p;
    //        currentWaypoint = 0;
    //    }
    //}

    //private void Update()
    //{
    //    //if (player != null && isPlayerInRange) { CheckIfTimeToFire(); }
    //}

    //void CheckIfTimeToFire()
    //{
    //    if (Time.time > nextFire)
    //    {
    //        Instantiate(bullet, transform.position, Quaternion.identity);
    //        nextFire = Time.time + fireRate;
    //    }
    //}

    //void FixedUpdate()
    //{
    //    if (pathToPlayer == null)
    //        return;
    //    if (currentWaypoint >= pathToPlayer.vectorPath.Count)
    //    {
    //        reachedEndofPath = true;
    //        return;
    //    }
    //    else
    //    {
    //        reachedEndofPath = false;
    //    }

    //    Vector2 direction = ((Vector2)pathToPlayer.vectorPath[currentWaypoint] - rb.position).normalized;

    //    Vector2 force = direction * speed * Time.deltaTime;

    //    rb.AddForce(force);

    //    float distance = Vector2.Distance(rb.position, pathToPlayer.vectorPath[currentWaypoint]);

    //    if (distance < nextWayPointDistance)
    //    {
    //        currentWaypoint++;
    //    }

    //    if (force.x >= 0.01f)
    //    {
    //        followerGFX.localScale = new Vector3(-followerScale, followerScale, followerScale);
    //    }
    //    else if (force.x <= -0.01f)
    //    {
    //        followerGFX.localScale = new Vector3(followerScale, followerScale, followerScale);
    //    }
    //}
}
