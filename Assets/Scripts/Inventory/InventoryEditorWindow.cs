using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class InventoryEditorWindow : EditorWindow
{
    private string newModuleName = "NewModule";
    private string scriptsFolder = "Assets/Scripts/Inventory/Modules";
    private Vector2 scroll;

    [MenuItem("Inventory Tools/Editor")]
    public static void OpenWindow()
    {
        GetWindow<InventoryEditorWindow>("Inventory Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create new Module Script (C# template)", EditorStyles.boldLabel);
        newModuleName = EditorGUILayout.TextField("Class name", newModuleName);
        scriptsFolder = EditorGUILayout.TextField("Scripts folder", scriptsFolder);

        if (GUILayout.Button("Generate Module Script"))
        {
            GenerateModuleScript(newModuleName, scriptsFolder);
        }

        GUILayout.Space(6);
        EditorGUILayout.HelpBox("Génération : un fichier C# sera créé avec un squelette héritant de ItemModule. Unity compilera ensuite et il sera disponible dans la liste ci-dessus.", MessageType.None);
    }
    private void GenerateModuleScript(string className, string folder)
    {
        if (string.IsNullOrWhiteSpace(className))
        {
            EditorUtility.DisplayDialog("Erreur", "Nom de classe invalide.", "OK");
            return;
        }
        className = CleanClassName(className);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string filePath = Path.Combine(folder, $"{className}.cs");
        if (File.Exists(filePath))
        {
            if (!EditorUtility.DisplayDialog("Remplacer ?", $"Le fichier {filePath} existe déjà. Remplacer ?", "Oui", "Non"))
                return;
        }

        string template = $@"using UnityEngine;

[CreateAssetMenu(menuName = ""Item/Create New Modules/{className}"")]
public class {className} : ItemModule
{{
    public override void OnUse(Item item)
    {{
        // TODO: implémente le comportement pour {className}
        Debug.Log($""{{item.itemName}} ({className})"");
    }}
}}";
        File.WriteAllText(filePath, template);
        AssetDatabase.ImportAsset(filePath);
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Généré", $"Fichier créé : {filePath}\nUnity va compiler le script.", "OK");
    }

    string CleanClassName(string rawName)
    {
        // Remove all caracter execpt Letter or Digit
        string clean = new string(rawName.Where(char.IsLetterOrDigit).ToArray());

        //Remove Space and make first letter upper
        if (string.IsNullOrEmpty(clean))
            clean = "NewModule";

        clean = char.ToUpper(clean[0]) + clean.Substring(1);

        //Add "Module" if not already done
        if (!clean.EndsWith("Module"))
            clean += "Module";

        return clean;
    }


}
