using UnityEngine;

[CreateAssetMenu(menuName = "Item/Create New Modules/KeyItem Module")]
public class KeyItemModule : ItemModule
{
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour KeyItem Module
        Debug.Log($"{item.itemName} (KeyItem Module)");
    }
}