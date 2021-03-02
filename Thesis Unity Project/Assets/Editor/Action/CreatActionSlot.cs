using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatActionSlot
{
    const string PREFAB_PATH = "Assets/Exploration/Action/BaseActionSlot.prefab";

    [MenuItem("Assets/Create/Action/Action Slot")]
    private static void NewActionSlot()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string assetPath = path + "/NewActionSlot.prefab";

        if (Directory.Exists(path))
        {
            GameObject prefabRef = (GameObject)AssetDatabase.LoadMainAssetAtPath(PREFAB_PATH);
            GameObject instanceRoot = (GameObject)PrefabUtility.InstantiatePrefab(prefabRef);
            GameObject pVariant = PrefabUtility.SaveAsPrefabAsset(instanceRoot, assetPath);
            GameObject.DestroyImmediate(instanceRoot);
        }
    }
}
