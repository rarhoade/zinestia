using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;

    EnemySight enemySight;
    NavMeshAgent nav;
    Transform player;
    LastPlayerSighting lastPlayerSighting;
    float chaseTimer;
    float patrolTimer;
    [SerializeField] int wayPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        enemySight = GetComponent<EnemySight>();
        nav = GetComponent<NavMeshAgent>();
        //navmesh2d setup
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerSighting = GameObject.FindWithTag("GameController").GetComponent<LastPlayerSighting>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        if ( enemySight.playerInSight ) {
            Attacking();
        } else if ( enemySight.personalLastSighting != lastPlayerSighting.resetPosition) {
            Chasing();
        } else {
            Patrolling();
        }
    }

    void UpdateRotation() {
        if ( nav.destination != null ) {
            Vector3 directionVector = nav.destination - transform.position;
            float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.fixedDeltaTime * 10f);
        }
    }

    void Attacking() {
        nav.isStopped = true;
    }       

    void Chasing() {
        Vector3 sightingDeltaPos = enemySight.personalLastSighting - transform.position;
        if (sightingDeltaPos.sqrMagnitude > 4f) {
            nav.destination = enemySight.personalLastSighting;
        }

        nav.speed = chaseSpeed;

        if (nav.remainingDistance < nav.stoppingDistance) {
            chaseTimer += Time.deltaTime;

            if (chaseTimer > chaseWaitTime) {
                lastPlayerSighting.position = lastPlayerSighting.resetPosition;
                enemySight.personalLastSighting = lastPlayerSighting.resetPosition;
                chaseTimer = 0;
            }
        } else {
            chaseTimer = 0f;
        }
    }

    void Patrolling() {
        if ( nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance <= nav.stoppingDistance) {
            patrolTimer += Time.deltaTime;

            if ( patrolTimer > patrolWaitTime) {
                if ( wayPointIndex == patrolWayPoints.Length - 1 ) {
                    wayPointIndex = 0;
                } else {
                    wayPointIndex++;
                }
                patrolTimer = 0f;
            }
        } else {
            patrolTimer = 0f;
        }

        nav.destination = patrolWayPoints[wayPointIndex].position;
    }
}
