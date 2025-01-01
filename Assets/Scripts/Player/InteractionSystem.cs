using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("Interaction Values")]
    [SerializeField] private float reach = 3f;
    [SerializeField] private InventorySystem inventorySystem;
    [Header("References")]
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentInteractuable;

    public delegate void OnPlayerFoundInteractuable();
    public static OnPlayerFoundInteractuable onPlayerFoundInteractuable;
    public static OnPlayerFoundInteractuable onPlayerLostInteractuable;

    #region event subscriptions
    private void OnEnable()
    {
        inputManager.OnInteract += InteractWithCurrent;
    }
    private void OnDestroy()
    {
        inputManager.OnInteract -= InteractWithCurrent;
    }
    #endregion
    
    void Update()
    {
        CheckInteract();
    }

    private void CheckInteract()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hit, reach))
        {
            if (hit.collider.tag == "Interactuable")
            {
                GameObject newInteractuable = hit.collider.gameObject;

                SetNewCurrentInteractable(newInteractuable);
            }
        }
        else
        {
            DisableCurrentInteractuable();
        }
    }

    private void DisableCurrentInteractuable()
    {
        if (currentInteractuable != null)
        {
            currentInteractuable = null;
            onPlayerLostInteractuable?.Invoke();
        }
    }

    private void SetNewCurrentInteractable(GameObject newInteractuable)
    {
        if (newInteractuable != null && (currentInteractuable == null || currentInteractuable != newInteractuable))
        {
            currentInteractuable = newInteractuable;
            onPlayerFoundInteractuable?.Invoke();
        }
    }

    private void InteractWithCurrent()
    {
        if (currentInteractuable != null)
        {
            currentInteractuable.GetComponent<IInteract>()?.ExecuteInteract(this);
            onPlayerLostInteractuable?.Invoke();
        }
    }

    public InventorySystem GetInventorySystem()
    {
        return inventorySystem;
    }
}
