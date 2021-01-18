using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Singleton;
    public static PlayerHealth playerHealth;
    
    void Awake() {
        if (playerHealth != null) {
            Debug.LogWarning("More than one Player Health");
            return;
        }
        playerHealth = this;
        canTakeDamage = true;
    }

    #endregion
    
    [SerializeField]
    int healthPoints;
    bool canTakeDamage;

    public void TakeDamage( int damage ) {
        if(canTakeDamage){
            healthPoints -= damage;
            StartCoroutine("HealthCoolDown", 3f);
            if(healthPoints <= 0){
                Debug.Log("DED");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {
            TakeDamage(1);
        }
    }

    IEnumerator HealthCoolDown(float time){
        canTakeDamage = false;
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }
}
