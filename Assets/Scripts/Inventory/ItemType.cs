using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Type", menuName = "Inventory System/Create New Type")]
public class ItemType : ScriptableObject
{
    public string displayedName;
    public Sprite icon;
}