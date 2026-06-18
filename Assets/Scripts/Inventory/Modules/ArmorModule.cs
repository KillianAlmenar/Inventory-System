using UnityEngine;

[CreateAssetMenu(menuName = "Item/Create New Modules/ArmorModule")]
public class ArmorModule : ItemModule
{
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour ArmorModule
        Debug.Log($"{item.itemName} (ArmorModule)");
    }
}