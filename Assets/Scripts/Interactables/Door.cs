using UnityEngine;

public class Door : InteractableBase, IInteractable
{
    public GameObject gateWallObject; // Assign your combined wall+gate object here

    public bool hasKey = false; // Starts false by default

    public void Interact()
    {
        if (hasInteracted)
            return;

        if (!hasKey)
        {
            Debug.Log("The door is locked. You need a key.");
            return;
        }

        if (gateWallObject != null)
            gateWallObject.SetActive(false);

        Debug.Log("The gate opens!");
        hasInteracted = true;
    }
}
