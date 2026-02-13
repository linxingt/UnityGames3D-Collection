using UnityEngine;
using UnityEditor;

public class GenerateMaterials
{
    [MenuItem("Tools/Generate 32 Materials")]
    public static void Go()
    {
        string folderPath = "Assets/SolidColorMaterials/";
        if (!AssetDatabase.IsValidFolder(folderPath))
            AssetDatabase.CreateFolder("Assets", "SolidColorMaterials");

        string[] colorNames = new string[]
        {
                        "1Red", "1Cherry", "1Blush", "1Salmon", "1Peach",
                        "2Orange", "2Gold", "2Amber", "2Lemon", "2Khaki",
                        "3Green", "3Lime", "3Teal", "3Olive", "3Mint",
                        "4Blue", "4Aqua", "4Cyan", "4Sky", "4Navy",
                        "5Purple", "5Lilac", "5Fuschia", "5Plum", "5Indigo",
                        "6White", "6Black", "6Gray", "6Beige", "6Ivory", "6Silver", "6Slate"
        };

        string[] colorHexes = new string[]
        {
                        "#FF0000", "#DC143C", "#FF1493", "#FA8072", "#F08080",
                        "#FFA500", "#FFD700", "#FF8C00", "#FFFFE0", "#F0E68C",
                        "#008000", "#00FF00", "#008080", "#808000", "#98FB98",
                        "#0000FF", "#00FFFF", "#00CED1", "#87CEEB", "#000080",
                        "#800080", "#C8A2C8", "#FF00FF", "#EE82EE", "#4B0082",
                        "#FFFFFF", "#000000", "#808080", "#F5F5DC", "#FFFFF0", "#C0C0C0", "#708090"
        };

        Shader litShader = Shader.Find("Universal Render Pipeline/Lit");

        for (int i = 0; i < colorNames.Length; i++)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(colorHexes[i], out color))
            {
                Material mat = new Material(litShader);
                mat.SetColor("_BaseColor", color);
                AssetDatabase.CreateAsset(mat, folderPath + colorNames[i] + ".mat");
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Materials have been generated in " + folderPath);
    }
}