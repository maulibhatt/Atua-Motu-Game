using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject emptyInventorySlot;
    [SerializeField] private GameObject inventoryContentPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    public PlayerInventory playerInventory;
    public List<InventoryItem> allItems = new List<InventoryItem>();


    public void SetDescription(string desc)
    {
        descriptionText.text = desc;
    }

    void MakeInventorySlots()
    {
        if (GameState.Inventory != null)
        {
            for (int i = GameState.Inventory.Count - 1; i >= 0; i--)
            {
                if (GameState.Inventory[i].Quantity > 0)
                {
                    // Creates a new slot and assigns it to variable newSlot
                    GameObject temp = Instantiate(emptyInventorySlot, inventoryContentPanel.transform.position, transform.rotation);
                    temp.transform.SetParent(inventoryContentPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(GameState.Inventory[i], this);
                    }
                }
            }
        }
        
    }

    // Enable is called whenever its enabled
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetDescription("");
    }

    // Clears inventory slots
    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryContentPanel.transform.childCount; i++)
        {
            Destroy(inventoryContentPanel.transform.GetChild(i).gameObject);
        }
    }

}
