using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public GameObject Player;
    public PlayerInventoryUI playerInventoryUI;
    public OtherInventoryUI otherInventoryUI;
    public GameInput gameInput;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        gameInput = new GameInput();
        gameInput.Enable();
        gameInput.UI.Disable();
    }

}
