using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Table : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject lastKey;
    [SerializeField] private List<GameObject> candles = new List<GameObject>();
    
    private bool canInteract = true;

    public void ExecuteInteract(InteractionSystem player)
    {
        if(canInteract && player.GetInventorySystem().FindAndUseItemInInventoryByName("Candle"))
        {
            if (candles.Count > 0)
            {
                if (candles.Count == 1)
                {
                    lastKey.SetActive(true);
                    this.gameObject.tag = "Untagged";
                    canInteract = false;
                }
                candles[0].SetActive(true);
                candles.RemoveAt(0);
                
            }
        }
    }
}
