using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableBase : MonoBehaviour
{
    public float interactionRange = 3f;
    public Transform player;
    public GameObject interactionCuePrefab;

    private GameObject cueInstance;
    protected bool hasInteracted = false;

    protected virtual void Update()
    {
        if (hasInteracted) 
        {
            if (cueInstance != null) cueInstance.SetActive(false);
            return;
        }

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
