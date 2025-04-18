using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public Camera mainCamera;
    public float interactionRange = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right click
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && Vector2.Distance(hit.transform.position, transform.position) <= interactionRange)
            {
                IInteractable interactable = hit.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
