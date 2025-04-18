using UnityEngine;

public class Chest : InteractableBase, IInteractable
{
    public Sprite openedSprite;

    [TextArea]
    public string rewardMessage = "You got a key!";

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (hasInteracted) return;

        sr.sprite = openedSprite;

        DialogueManager.Instance.ShowMessage(rewardMessage, 2f);

        hasInteracted = true;
    }
}
