using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    const string AssetDirectory = @"E:\App\Github\SeamothEngineUpgrades\Assets\";

    // Start is called before the first frame update
    [MenuItem("Tools/Build Bundles")]
    static void BuildDeepEngineBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        MoveFile(AssetDirectory, "seamothengineupgradesasset");
        MoveFile(AssetDirectory, "seamothengineupgradesasset.manifest");

        Debug.Log("Build Done");
    }

    private static void MoveFile(string destination, string fileName)
    {
        try
        {
            File.Copy(Path.Combine("Assets/Bundles", fileName), Path.Combine(destination, fileName), true);
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Error coping {fileName} in {destination} : {ex}");
        }
    }
}
