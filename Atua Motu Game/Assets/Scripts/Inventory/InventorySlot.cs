using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    // UI to change
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Image itemImage;


    // Variables from the item. They will be seen by the inventory manager, so public
    public InventoryItem thisItem;
    public InventoryManager inventoryManager;


    public void Setup(InventoryItem item, InventoryManager newIM)
    {
        thisItem = item;
        inventoryManager = newIM;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemCountText.text = "" + thisItem.itemCount;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlotClickedOn()
    {
        if (thisItem)
        {
            inventoryManager.SetDescription(thisItem.itemDescription);
        }
    }
}
