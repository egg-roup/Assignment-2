using UnityEngine;

public class SpecialNPC : NPC
{
    public string completionDialogue = "You have it. Thank you! I can finally finish my work!";

    public bool playerHasSpecialItem = false;

    public override void Interact()
    {
        if (playerHasSpecialItem)
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
        // TODO: Load a new scene, fade out, etc.
        // Example: SceneManager.LoadScene("CreditsScene");
    }
}
