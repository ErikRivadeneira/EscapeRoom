using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<string> inventory;

    public bool FindAndUseItemInInventoryByName(string itemName)
    {
        if(inventory.Count == 0)
        {
            return false;
        }    
        foreach (string item in inventory)
        {
            if (item.Contains(itemName))
            {
                inventory.Remove(item);
                return true;
            }
        }
        return false;
    }

    public void AddItemToInventory(string item)
    {
        inventory.Add(item);
    }
}
