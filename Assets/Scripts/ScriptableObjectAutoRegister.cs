#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ScriptableObjectAutoRegister : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string path in importedAssets)
        {
            var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            if (asset is Item item)
            {
                AddToItemDatabase(item);
            }
            else if (asset is ItemType itemType)
            {
                AddToTypeDatabase(itemType);
            }
        }
    }

    private static void AddToItemDatabase(Item item)
    {
        string[] databases = AssetDatabase.FindAssets("t:ItemDatabase");
        if (databases.Length > 0)
        {
            string databasePath = AssetDatabase.GUIDToAssetPath(databases[0]);
            var database = AssetDatabase.LoadAssetAtPath<ItemDatabase>(databasePath);
            if (database != null)
            {
                database.AddItem(item);
                EditorUtility.SetDirty(database);
                Debug.Log($"Item {item.name} ajouté à la base de données.");
            }
        }
        else
        {
            Debug.LogWarning("Aucune base de données d'items trouvée !");
        }
    }

    private static void AddToTypeDatabase(ItemType itemType)
    {
        string[] databases = AssetDatabase.FindAssets("t:ItemTypeDataBase");
        if (databases.Length > 0)
        {
            string databasePath = AssetDatabase.GUIDToAssetPath(databases[0]);
            var database = AssetDatabase.LoadAssetAtPath<ItemTypeDataBase>(databasePath);
            if (database != null)
            {
                database.AddType(itemType);
                EditorUtility.SetDirty(database);
                Debug.Log($"Item {itemType.name} ajouté à la base de données.");
            }
        }
        else
        {
            Debug.LogWarning("Aucune base de données d'items trouvée !");
        }
    }

}
#endif
