using UnityEngine;

[CreateAssetMenu(menuName = "Item/Create New Modules/ManaModule")]
public class ManaModule : ItemModule
{
    [SerializeField] private float manaRestored = 0;
    public override void OnUse(Item item)
    {
        // TODO: implémente le comportement pour ManaModule
        Debug.Log($"{item.itemName} (ManaModule)");
    }
}