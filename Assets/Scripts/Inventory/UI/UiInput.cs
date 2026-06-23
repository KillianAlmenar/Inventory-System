using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiInput : MonoBehaviour
{
    private void OnEnable()
    {
        InventoryManager.Instance.gameInput.UI.CloseInventory.performed += OnCloseInventoryPerformed;
        InventoryManager.Instance.gameInput.UI.Back.performed += OnBackPerformed;
        InventoryManager.Instance.gameInput.Player.OpenInventory.performed += OnInventoryPerformed;
    }

    private void OnDisable()
    {
        InventoryManager.Instance.gameInput.UI.CloseInventory.performed -= OnCloseInventoryPerformed;
        InventoryManager.Instance.gameInput.UI.Back.performed -= OnBackPerformed;
        InventoryManager.Instance.gameInput.Player.OpenInventory.performed -= OnInventoryPerformed;
    }

    private void OnInventoryPerformed(InputAction.CallbackContext ctx)
    {

        InventoryManager.Instance.gameInput.Player.Disable();
        InventoryManager.Instance.gameInput.UI.Enable();
        InventoryManager.Instance.playerInventoryUI.isDisplay = true;
    }


    private void OnCloseInventoryPerformed(InputAction.CallbackContext ctx)
    {
        if (InventoryManager.Instance.otherInventoryUI.isDisplay)
        {
            InventoryManager.Instance.otherInventoryUI.isDisplay = false;
        }

        if (InventoryManager.Instance.playerInventoryUI.isDisplay)
        {
            InventoryManager.Instance.playerInventoryUI.isDisplay = false;
            InventoryManager.Instance.playerInventoryUI.inChest = false;
            InventoryManager.Instance.gameInput.UI.Disable();
            InventoryManager.Instance.gameInput.Player.Enable();
            InventoryManager.Instance.playerInventoryUI.informationUI.SetActive(false);
        }

    }

    private void OnBackPerformed(InputAction.CallbackContext ctx)
    {
        
        if (InventoryManager.Instance.playerInventoryUI.isDisplay)
        {
            InventoryManager.Instance.playerInventoryUI.isDisplay = false;
            InventoryManager.Instance.playerInventoryUI.informationUI.SetActive(false);
        }
        if (InventoryManager.Instance.otherInventoryUI.isDisplay)
        {
            InventoryManager.Instance.otherInventoryUI.isDisplay = false;
            InventoryManager.Instance.playerInventoryUI.inChest = false;
        }

        InventoryManager.Instance.gameInput.UI.Disable();
        InventoryManager.Instance.gameInput.Player.Enable();
    }
}
