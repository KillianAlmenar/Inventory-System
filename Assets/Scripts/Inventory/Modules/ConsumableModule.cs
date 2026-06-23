using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Create New Modules/ConsumableModule")]
public class ConsumableModule : ItemModule
{
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour ConsumableModule
        Debug.Log($"{item.itemName} (ConsumableModule)");
    }
}