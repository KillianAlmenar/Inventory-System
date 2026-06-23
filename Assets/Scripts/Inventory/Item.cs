using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Create New Item")]
public class Item : ScriptableObject
{
    public enum TYPE
    {
        NONE,
        KEYITEM,
        CONSOMMABLE,
        WEAPON,
        ARMOR,
        RESSOURCE
    }
    [ReadOnly] public TYPE type;

    public List<ItemType> types = new List<ItemType>();

    public ItemRarity rarity;
    public string itemName;
    public string description;
    public Sprite icon;
    public int stackSize;
    public int id;
    public float weight = 0;
    public List<ItemModule> modules = new List<ItemModule>();


    protected void OnValidate()
    {
        id = name.GetHashCode();

        foreach (ItemModule module in modules)
        {
            if (module != null)
            {
                if (module.type != TYPE.NONE)
                {
                    type = module.type;
                    break;
                }
            }
        }

        if(stackSize < 1)
        {
            stackSize = 1;
        }
    }

    public void Use()
    {
        foreach (var m in modules)
        {
            if (m != null) m.OnUse(this);
        }
    }

}
