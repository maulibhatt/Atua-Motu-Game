using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Items", fileName = "New Item")]
public class InventoryItem : ScriptableObject
{

    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int itemCount;
    // Character this item relates to
    public string character;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 0;
    }

    public void DecreaseAmount(int amtToDecrease)
    {
        if (itemCount >= amtToDecrease)
        {
            itemCount -= amtToDecrease;
        }
        if (itemCount < 0)
        {
            itemCount = 0;
        }
    }
    public void IncreaseAmount(int amtToIncrease)
    {
        itemCount += amtToIncrease;
        if (itemCount < 0)
        {
            itemCount = 0;
        }
    }
}
