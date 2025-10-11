using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiInput : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.gameInput.UI.CloseInventory.performed += OnCloseInventoryPerformed;
        GameManager.Instance.gameInput.UI.Back.performed += OnBackPerformed;
        GameManager.Instance.gameInput.Player.OpenInventory.performed += OnInventoryPerformed;
    }

    private void OnDisable()
    {
        GameManager.Instance.gameInput.UI.CloseInventory.performed -= OnCloseInventoryPerformed;
        GameManager.Instance.gameInput.UI.Back.performed -= OnBackPerformed;
        GameManager.Instance.gameInput.Player.OpenInventory.performed -= OnInventoryPerformed;
    }

    private void OnInventoryPerformed(InputAction.CallbackContext ctx)
    {

        GameManager.Instance.gameInput.Player.Disable();
        GameManager.Instance.gameInput.UI.Enable();
        GameManager.Instance.playerInventoryUI.isDisplay = true;
    }


    private void OnCloseInventoryPerformed(InputAction.CallbackContext ctx)
    {
        if (GameManager.Instance.otherInventoryUI.isDisplay)
        {
            GameManager.Instance.otherInventoryUI.isDisplay = false;
        }

        if (GameManager.Instance.playerInventoryUI.isDisplay)
        {
            GameManager.Instance.playerInventoryUI.isDisplay = false;
            GameManager.Instance.playerInventoryUI.inChest = false;
            GameManager.Instance.gameInput.UI.Disable();
            GameManager.Instance.gameInput.Player.Enable();
            GameManager.Instance.playerInventoryUI.informationUI.SetActive(false);
        }

    }

    private void OnBackPerformed(InputAction.CallbackContext ctx)
    {
        
        if (GameManager.Instance.playerInventoryUI.isDisplay)
        {
            GameManager.Instance.playerInventoryUI.isDisplay = false;
            GameManager.Instance.playerInventoryUI.informationUI.SetActive(false);
        }
        if (GameManager.Instance.otherInventoryUI.isDisplay)
        {
            GameManager.Instance.otherInventoryUI.isDisplay = false;
            GameManager.Instance.playerInventoryUI.inChest = false;
        }

        GameManager.Instance.gameInput.UI.Disable();
        GameManager.Instance.gameInput.Player.Enable();
    }
}
