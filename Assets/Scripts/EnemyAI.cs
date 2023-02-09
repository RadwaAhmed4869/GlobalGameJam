using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

using PathCreation;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool isFollowing;

    [SerializeField] private Transform target;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float nextWayPointDistance = 3f;

    private GameObject player;
    private string PLAYER_TAG = "Player";

    [SerializeField] private Transform enemyGFX;

    private Path pathToPlayer;
    private int currentWaypoint = 0;
    private bool reachedEndofPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    //private Animator anim;

    public PathCreator pathCreator;

    public EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float partolingSpeed = 4;
    float distanceTravelled;

    bool isPlayerInRange = false;

    private float enemyScale;

    [SerializeField] private GameObject bullet;

    private float fireRate;
    private float nextFire;

    void Start()
    {
        enemyScale = transform.localScale.x;
        fireRate = 2f;
        nextFire = Time.time;
        player = GameObject.FindWithTag(PLAYER_TAG);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        isPlayerInRange = false;
    }

    public void PlayerInRange()
    {
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        isPlayerInRange = true;
    }

    public void PlayerInRangeTwo()
    {
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        isPlayerInRange = true;
    }

    void UpdatePath()
    {
        if(seeker.IsDone() && player != null)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            pathToPlayer = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (player != null && isPlayerInRange) { CheckIfTimeToFire(); }

        if (!isPlayerInRange || !isFollowing)
        {
            //Vector3 dir = new Vector3(enemyPosition.x - transform.position.x, enemyPosition.y - transform.position.y, 0.0f);

            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (pathCreator != null)
            {
                distanceTravelled += partolingSpeed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //enemyPosition = transform.position;
                //transform.rotation = Quaternion.Euler(0, angle, 0);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate() 
    {
        if (isPlayerInRange && isFollowing)
        {
            if (pathToPlayer == null)
                return;
            if (currentWaypoint >= pathToPlayer.vectorPath.Count)
            {
                reachedEndofPath = true;
                return;
            }
            else
            {
                reachedEndofPath = false;
            }

            Vector2 direction = ((Vector2)pathToPlayer.vectorPath[currentWaypoint] - rb.position).normalized;

            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, pathToPlayer.vectorPath[currentWaypoint]);

            if (distance < nextWayPointDistance)
            {
                currentWaypoint++;
            }

            if (force.x >= 0.01f)
            {
                enemyGFX.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
            }
            else if (force.x <= -0.01f)
            {
                enemyGFX.localScale = new Vector3(-enemyScale, enemyScale, enemyScale);
            }
        }
    }
}
