using UnityEngine;
using System;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public static event Action OnPlayerDied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            OnPlayerDied.Invoke();
        }
    }

    public void HealPlayer(int amountToHeal)
    {
        currentHealth += amountToHeal;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

    }
}
