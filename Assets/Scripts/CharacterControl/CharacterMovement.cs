﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject Hand;
    [SerializeField] float horizontal, vertical, angle;
    Rigidbody2D m_Rigidbody2D;
    public GameObject Legs;
    public GameObject Torso;
    Animator legAnimator;
    [SerializeField] float rotationSpeed;

    enum State 
    {
        Rooted,
        Walking,
        Running,
    };

    public float runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 1.5f;
        legAnimator = Legs.GetComponentInChildren<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Vector3 startDir = Input.mousePosition - Camera.main.WorldToScreenPoint(Hand.transform.position);
        angle = Mathf.Atan2(startDir.y, startDir.x) * Mathf.Rad2Deg;
    }

    void UpdateDirectionInput(){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 0 && vertical == 0){
            legAnimator.SetBool("Walking", false);
        } else {
            legAnimator.SetBool("Walking", true);
            float legAngle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            float forwardAngle = Mathf.Atan2(Legs.transform.right.y, Legs.transform.right.x) * Mathf.Rad2Deg;
            float angleLerp = Mathf.LerpAngle(forwardAngle, legAngle, Time.smoothDeltaTime * rotationSpeed);
            Legs.transform.eulerAngles = new Vector3(0, 0, angleLerp);
        }
    }

    void UpdateDirectionInput(float x, float y){
        horizontal = x;
        vertical = y;
        if (x == 0 && y == 0){
            legAnimator.SetBool("Walking", false);
        } else {
            legAnimator.SetBool("Walking", true);
        }

        float legAngle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
        float forwardAngle = Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        float angleLerp = Mathf.LerpAngle(forwardAngle, legAngle, Time.smoothDeltaTime * rotationSpeed);
        Legs.transform.eulerAngles = new Vector3(0, 0, angleLerp);
    } 

    public void UpdateRotation(Vector3 dir){
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float forwardAngle = Mathf.Atan2(Torso.transform.right.y, Torso.transform.right.x) * Mathf.Rad2Deg;
        float angleLerp = Mathf.LerpAngle(forwardAngle, angle, Time.smoothDeltaTime * rotationSpeed);
        Torso.transform.eulerAngles = new Vector3(0, 0, angleLerp);
    } 

    void FixedUpdate(){
        //direction to mouse
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(Hand.transform.position); 
        //Move freely
        UpdateDirectionInput();
        UpdateRotation(dir);
        if (horizontal != 0 || vertical != 0)
            m_Rigidbody2D.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        else
            m_Rigidbody2D.velocity = Vector2.zero;
    }
}
