using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    [Header("Consumable")] // data scpecific to consumable class
    public float healthAdded;

    public override ConsumableClass GetConsumable() { return this; }

    public override void Use(PlayerController caller)
{
    HealthManager healthManager = caller.GetComponent<HealthManager>();

    if (healthManager != null)
    {
        healthManager.HealPlayer((int)healthAdded);
        Debug.Log($"{itemName} used. Restored {healthAdded} health.");

        InventoryManager.Instance.Remove(this);
    }
}

}
