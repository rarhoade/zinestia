using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float Health;
    Animator animator;
    float _pendingFreezeDuration = 0f;
    bool _isFrozen = false;
    public float duration = 1f;
    CinemachineImpulseSource source;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerWeapon") {
            Health -= other.gameObject.GetComponent<Weapon>().GetDamage();
            if( Health <= 0 ) {
                animator.SetTrigger( "Death" );
                GetComponent<BoxCollider2D>().enabled = false;
            } else {
                animator.SetTrigger("Hit");
            }
            source.GenerateImpulse();
            StartCoroutine("DoFreeze");
        }
    }

    IEnumerator DoFreeze() {
        var original = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = original;
    }

}
