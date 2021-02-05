using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] bool startRunning = false;
    [SerializeField] float RotationSpeed = 10f;
    [SerializeField] float attackRange = 0.5f;
    enum State { Idle, Run, Attack };
    [SerializeField] State state;
    Vector3 vectorToTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<BoxCollider2D>().enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        /*vectorToTarget = target.position - transform.position;
        switch(state){
            case State.Idle:
                HandleIdle();
                break;
            case State.Attack:
                HandleAttack();
                break;
            case State.Run:
                HandleRun();        
                break;
            default:
                break;
        };*/
    }

    void HandleIdle(){
        if (vectorToTarget.magnitude <= attackRange * 10){
            state = State.Run;
        }
    }

    void HandleAttack(){
        GetComponentInChildren<Animator>().SetTrigger("Attack");
        StartCoroutine("EnableHitBox");
        agent.SetDestination(target.position);
        if (vectorToTarget.magnitude >= attackRange){
            state = State.Run;
        }
    }

    void HandleRun(){
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.fixedDeltaTime * RotationSpeed);
        GetComponentInChildren<Animator>().SetTrigger("Run");
        agent.SetDestination(target.position);
        if (vectorToTarget.magnitude < attackRange){
            state = State.Attack;
        }
    }

    IEnumerator EnableHitBox(){
        yield return new WaitForSeconds(0.2f);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
