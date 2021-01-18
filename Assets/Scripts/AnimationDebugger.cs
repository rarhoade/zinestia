using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDebugger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            animator.SetTrigger("Hit");
        }
        else if(Input.GetKeyDown(KeyCode.Y)){
            animator.SetTrigger("Attack");
        }
        else if(Input.GetKeyDown(KeyCode.H)){
            animator.SetTrigger("Death");
        }
        else if(Input.GetKeyDown(KeyCode.T)){
            animator.SetTrigger("Run");
        }
    }
}
