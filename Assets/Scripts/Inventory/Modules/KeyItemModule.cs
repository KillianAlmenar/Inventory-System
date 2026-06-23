using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Create New Modules/KeyItem Module")]
public class KeyItemModule : ItemModule
{
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour KeyItem Module
        Debug.Log($"{item.itemName} (KeyItem Module)");
    }
}