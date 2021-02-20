using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthBar : MonoBehaviour
{
    Slider healthBar;
    void Awake()
    {
        healthBar = GetComponent<Slider>();
        PlayerHealth.OnDamageReceived += UpdateHealthBar;
        PlayerHealth.OnSceneInitialize += SetStartingHealthValues;
    }

    public void UpdateHealthBar(int currentHealth) {
        healthBar.value = currentHealth;
    }

    public void UpdateMaximumHealth(int maxHealth) {
        healthBar.maxValue = maxHealth;
    }

    public void SetStartingHealthValues(int currentHealth, int maxHealth) {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

}
