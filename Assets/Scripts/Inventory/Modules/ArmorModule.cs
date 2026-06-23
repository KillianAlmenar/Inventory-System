using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Create New Modules/ArmorModule")]
public class ArmorModule : ItemModule
{
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour ArmorModule
        Debug.Log($"{item.itemName} (ArmorModule)");
    }
}