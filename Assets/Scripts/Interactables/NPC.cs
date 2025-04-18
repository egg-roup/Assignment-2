using UnityEngine;

public class NPC : InteractableBase, IInteractable
{
    public string dialogueText = "Hello, traveler!";

    public void Interact()
    {
        if (hasInteracted) return;

        Debug.Log($"NPC says: {dialogueText}");
        // Later: Trigger ScriptableObject-based dialogue
        hasInteracted = true;
    }
}
