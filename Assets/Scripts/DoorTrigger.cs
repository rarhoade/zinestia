using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool canInteract;
    HingeJoint2D hinge;
    Rigidbody2D rigidbody2D;
    Vector3 startPos, startRot;
    public Transform Door;
    enum State {
        Open,
        Closed
    }
    State state;
    // Start is called before the first frame update
    void Start(){
        hinge = GetComponentInChildren<HingeJoint2D>();
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        startRot = Door.transform.eulerAngles;
        startPos = Door.transform.position;
        state = State.Closed;
        MakeDoorStatic();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            canInteract = false;
        }
    }

    void Update(){
        if(canInteract && Input.GetKeyDown(KeyCode.E)){
            switch(state){
                case State.Open:
                    state = State.Closed;
                    MakeDoorStatic();
                    break;
                case State.Closed:
                    state = State.Open;
                    MakeDoorDynamic();
                    break;
                default:
                    break;
            }
        }
    }

    void MakeDoorStatic(){
        hinge.enabled = false;
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        Door.transform.position = startPos;
        Door.transform.eulerAngles = startRot;
    }

    void MakeDoorDynamic(){
        hinge.enabled = true;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}