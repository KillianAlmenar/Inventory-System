using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Create New Modules/HealModule")]
public class HealModule : ItemModule
{
    public float HealedHP = 0;


    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour HealModule
        Debug.Log($"{item.itemName} (HealModule)");
    }
}