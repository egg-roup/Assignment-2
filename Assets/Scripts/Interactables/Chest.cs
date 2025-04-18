using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChestLoot
{
    public ItemClass item;
    public int quantity;
}

public class Chest : InteractableBase, IInteractable
{
    public Sprite openedSprite;

    [TextArea]
    public string rewardMessage = "You got a key!";

    private SpriteRenderer sr;

    [Header("Loot Settings")]
    public List<ChestLoot> loot = new List<ChestLoot>();

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (hasInteracted) return;

        sr.sprite = openedSprite;

        for (int i = 0; i < loot.Count; i++)
        {
            InventoryManager.Instance.Add(loot[i].item, loot[i].quantity);
        }

        DialogueManager.Instance.ShowMessage(rewardMessage, 2f);

        hasInteracted = true;
    }
}
