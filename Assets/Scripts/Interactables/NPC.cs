using UnityEngine;

public class NPC : InteractableBase, IInteractable
{
    
    [TextArea]
    public string dialogueText = "Hello, traveler!";

    public string npcID = "npc_default";

    public virtual void Interact()
    {
       
        DialogueManager.Instance.ShowMessage(dialogueText, 3f, npcID, 100);
    }

   
    protected override void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= interactionRange)
        {
            if (cueInstance == null && interactionCuePrefab != null)
            {
                cueInstance = Instantiate(interactionCuePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity, transform);
            }
            else if (cueInstance != null)
            {
                cueInstance.SetActive(true);
            }
        }
        else
        {
            if (cueInstance != null)
                cueInstance.SetActive(false);
        }
    }
}
