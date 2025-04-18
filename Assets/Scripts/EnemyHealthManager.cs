using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth = 20;
    public int maxHealth = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
