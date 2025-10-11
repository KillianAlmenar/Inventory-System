using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemInventory : ScriptableObject
{
    public enum TYPE
    {
        KEYITEM,
        CONSOMMABLE,
        WEAPON,
        ARMOR,
        RESSOURCE
    }
    public TYPE type;

    public enum RARITY
    {
        LEGENDARY,
        RARE,
        COMMUN
    }
    public RARITY rarity;

    public string itemName;
    public string description;
    public Sprite icon;
    public int stackSize;
    public int id;

    protected void OnValidate()
    {
        id = name.GetHashCode();
    }

}
