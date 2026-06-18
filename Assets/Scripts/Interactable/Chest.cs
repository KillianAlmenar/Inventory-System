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
        if (!GameManager.Instance.otherInventoryUI.isDisplay)
        {
            Inventory currentInv = GetComponent<Inventory>();
            InteractionInvItem currentInteract = GameManager.Instance.otherInventoryUI.interaction.GetComponent<InteractionInvItem>();
            GameManager.Instance.otherInventoryUI.Inventory = currentInv;
            GameManager.Instance.otherInventoryUI.isDisplay = true;
            currentInteract.currentInv = currentInv;
            currentInteract.targetInv = GameManager.Instance.Player.GetComponent<Inventory>();

            GameManager.Instance.playerInventoryUI.isDisplay = true;
            GameManager.Instance.playerInventoryUI.inChest = true;
            GameManager.Instance.playerInventoryUI.interaction.GetComponent<InteractionInvItem>().targetInv = currentInv;

            GameManager.Instance.gameInput.Player.Disable();
            GameManager.Instance.gameInput.UI.Enable();
        }
    }
}
