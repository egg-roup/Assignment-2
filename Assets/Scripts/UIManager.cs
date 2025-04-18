using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthMan;
    public Slider healthBar;
    public TMPro.TextMeshProUGUI hpText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthMan = FindFirstObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
