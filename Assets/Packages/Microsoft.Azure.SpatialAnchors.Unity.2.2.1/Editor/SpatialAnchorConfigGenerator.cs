using Microsoft.Azure.SpatialAnchors.Unity;
using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class SpatialAnchorConfigGenerator
{
    static SpatialAnchorConfigGenerator()
    {
        string spatialAnchorConfigFileName = "SpatialAnchorConfig.asset";
        string[] res = Directory.GetFiles(Application.dataPath, spatialAnchorConfigFileName, SearchOption.AllDirectories);
        if (res.Length > 1)
        {
            Debug.LogError(@"There is more than one SpatialAnchorConfig.asset file. You should remove one of them!");
            return;
        }
        if (res.Length != 0)
        {
            return;
        }

        string directoryPath = "Assets/Resources";
        Debug.Log($"SpatialAnchorConfig.asset does not exist. Will create it at {directoryPath}/{spatialAnchorConfigFileName}");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        SpatialAnchorConfig spatialAnchorConfigAsset = ScriptableObject.CreateInstance<SpatialAnchorConfig>();
        AssetDatabase.CreateAsset(spatialAnchorConfigAsset, $"{directoryPath}/{spatialAnchorConfigFileName}");
    }
}
