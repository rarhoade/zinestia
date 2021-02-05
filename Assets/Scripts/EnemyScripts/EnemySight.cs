using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//much of the ideas from this were taken from this tutorial
//https://www.youtube.com/watch?v=mBGUY7EUxXQ&list=PLX2vGYjWbI0QGyfO8PKY1pC8xcRb0X-nP&index=20  
public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private NavMeshAgent nav;
    private CircleCollider2D col;
    private LastPlayerSighting lastPlayerSighting;
    private GameObject player;
    //may need reference to animator of player to determine if they're running/making noise
    [SerializeField] private Vector3 previousSighting;

    void Awake() {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<CircleCollider2D>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");

        personalLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }

    void Update() {
        if (lastPlayerSighting.position != previousSighting) {
            personalLastSighting = lastPlayerSighting.position;
        }
        previousSighting = lastPlayerSighting.position;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if ( other.gameObject == player ) {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.right);
            if (angle < fieldOfViewAngle * 0.5f) {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, col.radius, LayerMask.GetMask("Player"));
                if (hit.collider != null && hit.collider.gameObject == player) {
                    playerInSight = true;
                    lastPlayerSighting.position = player.transform.position;
                }
            }
        } else if ( other.gameObject.tag == "EnemyAISound" ) {
            playerInSight = false;
            if ( CalculatePathLength(other.transform.position) < 10f ) {
                personalLastSighting = other.gameObject.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == player) {
            playerInSight = false;
        }
    }

    float CalculatePathLength(Vector3 targetPosition) {
        NavMeshPath path = new NavMeshPath();
        if ( nav.enabled ) {
            nav.CalculatePath(targetPosition, path);
        }

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length-1] = targetPosition;

        for ( int i = 0; i < path.corners.Length; i++ ) {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;

        for ( int i=0; i < allWayPoints.Length - 1; i++ ) {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }
}
