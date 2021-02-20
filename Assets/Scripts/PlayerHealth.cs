using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static Action<int> OnDamageReceived;
    public static Action<int, int> OnSceneInitialize;
    public UIPlayerHealthBar uIPlayerHealthBar;
    
    void Awake() {
        canTakeDamage = true;
    }

    void Start() {
        OnSceneInitialize(healthPoints, maxHealth);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.N)) {
            TakeDamage(1);
        }
    }

    [SerializeField]
    int healthPoints;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    bool canTakeDamage;

    public void TakeDamage( int damage ) {
        if (canTakeDamage){
            healthPoints -= damage;
            if (OnDamageReceived != null) {
                OnDamageReceived(healthPoints);
            }
            StartCoroutine("HealthCoolDown", 3f);
            if (healthPoints <= 0){
                Debug.Log("DED");
            }
        }
    }

    IEnumerator HealthCoolDown(float time){
        canTakeDamage = false;
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }
}
