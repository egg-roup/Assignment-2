using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarController : MonoBehaviour
{
    [SerializeField] private GameObject hotbarSlotHolder;
    [SerializeField] private GameObject hotbarSelector;

    private InventoryManager inventoryManager => InventoryManager.Instance;

    private GameObject[] hotbarSlots;
    private int selectedSlotIndex = 0;

    private void Start()
    {
        int slotCount = hotbarSlotHolder.transform.childCount;
        hotbarSlots = new GameObject[slotCount];

        for (int i = 0; i < slotCount; i++)
        {
            hotbarSlots[i] = hotbarSlotHolder.transform.GetChild(i).gameObject;
        }

        RefreshHotbar();
        UpdateSelectorPosition();
    }

    private void Update()
    {
        HandleScrollInput();
    }

    private void HandleScrollInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            selectedSlotIndex++;
            if (selectedSlotIndex >= hotbarSlots.Length)
                selectedSlotIndex = 0;
            UpdateSelectorPosition();
        }
        else if (scroll < 0)
        {
            selectedSlotIndex--;
            if (selectedSlotIndex < 0)
                selectedSlotIndex = hotbarSlots.Length - 1;
            UpdateSelectorPosition();
        }
    }

    private void UpdateSelectorPosition()
    {
        if (hotbarSelector != null)
        {
            hotbarSelector.transform.position = hotbarSlots[selectedSlotIndex].transform.position;
        }
    }

    public void RefreshHotbar()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            try
            {
                ItemClass item = inventoryManager.GetItemAtHotbarIndex(i);
                Image iconImage = hotbarSlots[i].transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI quantityText = hotbarSlots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                if (item != null)
                {
                    iconImage.enabled = true;
                    iconImage.sprite = item.itemIcon;

                    if (item.isStackable)
                        quantityText.text = inventoryManager.GetQuantityAtHotbarIndex(i).ToString();
                    else
                        quantityText.text = "";
                }
                else
                {
                    iconImage.enabled = false;
                    iconImage.sprite = null;
                    quantityText.text = "";
                }
            }
            catch
            {
                Debug.LogWarning($"Failed to refresh hotbar slot {i}");
            }
        }
    }

    public ItemClass GetSelectedItem()
    {
        return inventoryManager.GetItemAtHotbarIndex(selectedSlotIndex);
    }

    public int GetSelectedIndex()
    {
        return selectedSlotIndex;
    }
}
