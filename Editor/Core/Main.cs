using ADOFAIRunner.Common;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ADOFAIRunner.Core
{
    [InitializeOnLoad] // Runs as soon as the editor loads this assembly
    public static class Main
    {
        public static Setting setting;
        static Main()
        {
            SetupEnvironment();
        }
        private static void SetupEnvironment()
        {
            Debug.Log("Setting up ADOFAI Runner environment...");

            // Define the path for the settings asset
            string assetPath = Constants.settingsFolder + "/ADOFAIRunnerSettings.asset";

            // Ensure the directory exists
            if (!Directory.Exists(Constants.settingsFolder))
            {
                Directory.CreateDirectory(Constants.settingsFolder);
                AssetDatabase.Refresh();
            }

            // Find the existing asset
            setting = AssetDatabase.LoadAssetAtPath<Setting>(assetPath);

            // If the asset doesn't exist, create it
            if (setting == null)
            {
                setting = ScriptableObject.CreateInstance<Setting>();
                setting.Initialize(); // Call your initialization logic
                AssetDatabase.CreateAsset(setting, assetPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"Created new settings asset at {assetPath}");
            }

            AssetDatabase.Refresh();
        }
    }
}
