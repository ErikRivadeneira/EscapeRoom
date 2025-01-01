using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteract
{
    [SerializeField] private bool goesToInventory;

    public void ExecuteInteract(InteractionSystem player)
    {
        if (goesToInventory)
        {
            player.GetInventorySystem().AddItemToInventory(this.gameObject.name);
        }
        Destroy(this.gameObject);
    }
}
