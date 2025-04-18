using UnityEngine;

public class Chest : InteractableBase, IInteractable
{
    public Sprite openedSprite;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (hasInteracted) return;

        sr.sprite = openedSprite;
        Debug.Log("Player received an item! (Placeholder)");
        hasInteracted = true;
    }
}
