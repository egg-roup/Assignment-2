using UnityEngine;

public class Door : InteractableBase, IInteractable
{
    public GameObject gateWallObject;
    public bool hasKey = false;

    public string lockedMessage = "The door is locked. You need a key.";
    public string unlockedMessage = "The gate opens!";

    public void Interact()
    {
        if (hasInteracted)
            return;

        if (!hasKey)
        {
            DialogueManager.Instance.ShowMessage(lockedMessage, 2f);
            return;
        }

        if (gateWallObject != null)
            gateWallObject.SetActive(false);

        DialogueManager.Instance.ShowMessage(unlockedMessage, 2f);
        hasInteracted = true;
    }
}
