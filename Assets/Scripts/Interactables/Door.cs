using UnityEngine;

public class Door : InteractableBase, IInteractable
{
    public GameObject gateWallObject;
    public bool hasKey = false;

    public string lockedMessage = "The door is locked. You need a key.";
    public string unlockedMessage = "The gate opens!";

    [Header("Key Requirements")]
    public MiscClass requiredKey;
    public bool consumeKeyOnUse = true;

    public void Interact()
    {
        if (hasInteracted)
            return;

        var selectedItem = InventoryManager.Instance.selectedItem;
        var miscItem = selectedItem?.GetMisc();

        if (miscItem == null || miscItem != requiredKey)
        {
            DialogueManager.Instance.ShowMessage(lockedMessage, 2f);
            return;
        }

        if (gateWallObject != null)
            gateWallObject.SetActive(false);

        DialogueManager.Instance.ShowMessage(unlockedMessage, 2f);
        hasInteracted = true;

        if (consumeKeyOnUse)
            InventoryManager.Instance.Remove(requiredKey);
    }
}
