using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Player Inventory", fileName = "New Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = myInventory.Count - 1; i >= 0; i--)
        {
            myInventory[i].itemCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
