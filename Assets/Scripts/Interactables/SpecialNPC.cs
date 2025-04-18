using UnityEngine;
using System.Collections;


public class SpecialNPC : NPC
{
    public string completionDialogue = "You have it. Thank you! I can finally finish my work!";

    public ItemClass houseKeyItem;

    public override void Interact()
    {
        if (InventoryManager.Instance.selectedItem != null && InventoryManager.Instance.selectedItem.itemName == houseKeyItem.itemName)
        {
            DialogueManager.Instance.ShowMessage(completionDialogue, 4f, npcID, 100);
            EndGameSequence();
        }
        else
        {
            base.Interact(); // fallback to regular dialogue
        }
    }

    private void EndGameSequence()
    {
        Debug.Log("Ending the game...");
        StartCoroutine(DelayedEnd());


    }
    private IEnumerator DelayedEnd()
    {
        yield return new WaitForSeconds(4f);

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
