using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

[CustomEditor(typeof(Item))]
public class InventoryItemEditorStrict : Editor
{
    private ReorderableList moduleList;

    private void OnEnable()
    {
        moduleList = new ReorderableList(serializedObject,
            serializedObject.FindProperty("modules"),
            true, true, true, true);

        moduleList.drawHeaderCallback = rect =>
        {
            EditorGUI.LabelField(rect, "Modules");
        };

        moduleList.onAddCallback = list =>
        {
            GenericMenu menu = new GenericMenu();

            // On affiche les modules disponibles
            string[] guids = AssetDatabase.FindAssets("t:ItemModule");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ItemModule module = AssetDatabase.LoadAssetAtPath<ItemModule>(path);

                menu.AddItem(new GUIContent(module.name), false, () =>
                {
                    var item = (Item)target;

                    bool compatible = true;
                    foreach (var existing in item.modules)
                    {
                        if (existing.IsIncompatibleWith(module))
                        {
                            Debug.LogWarning($"{module.name} incompatible avec {existing.name}");
                            compatible = false;
                            break;
                        }
                    }

                    if (compatible)
                    {
                        item.modules.Add(module);
                        EditorUtility.SetDirty(item);
                    }
                });
            }

            menu.ShowAsContext();
        };
    }

    //public override void OnInspectorGUI()
    //{
    //    serializedObject.Update();
    //    moduleList.DoLayoutList();
    //    serializedObject.ApplyModifiedProperties();
    //}
}
