using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

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
            
        }
    }

    public void HealPlayer(int amountToHeal)
    {
        currentHealth += amountToHeal;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

    }
}
