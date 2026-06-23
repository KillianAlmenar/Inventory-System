using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour, IInteractable
{

    private void Start()
    {
        Interact();    
    }

    public void Interact()
    {
        if (!InventoryManager.Instance.otherInventoryUI.isDisplay)
        {
            Inventory currentInv = GetComponent<Inventory>();
            InteractionInvItem currentInteract = InventoryManager.Instance.otherInventoryUI.interaction.GetComponent<InteractionInvItem>();
            InventoryManager.Instance.otherInventoryUI.Inventory = currentInv;
            InventoryManager.Instance.otherInventoryUI.isDisplay = true;
            currentInteract.currentInv = currentInv;
            currentInteract.targetInv = InventoryManager.Instance.Player.GetComponent<Inventory>();

            InventoryManager.Instance.playerInventoryUI.isDisplay = true;
            InventoryManager.Instance.playerInventoryUI.inChest = true;
            InventoryManager.Instance.playerInventoryUI.interaction.GetComponent<InteractionInvItem>().targetInv = currentInv;

            InventoryManager.Instance.gameInput.Player.Disable();
            InventoryManager.Instance.gameInput.UI.Enable();
        }
    }
}
