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
    private Vector3 previousSighting;

    void Awake() {
    }

}
