using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Create New Rarity")]
public class ItemRarity : ScriptableObject
{
    public string displayName;
    public Color color = Color.white;
    public int sortOrder;
}
