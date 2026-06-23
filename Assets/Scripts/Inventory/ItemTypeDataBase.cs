using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemTypeDataBase", menuName = "Game/ItemTypeDataBase")]
public class ItemTypeDataBase : ScriptableObject
{
    public List<ItemType> types = new List<ItemType>();

    private void OnEnable()
    {
        types.RemoveAll(x => !x);
    }

    public void AddType(ItemType itemType)
    {
        if (!types.Contains(itemType))
        {
            types.Add(itemType);
            Debug.Log($"Ajouté à la base de données : {itemType.name}");
        }
    }
}
