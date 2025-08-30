using ADOFAIRunner.Common;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ADOFAIRunner.Core
{
    [InitializeOnLoad]
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

            string assetPath = Constants.settingsFolder + "/ADOFAIRunnerSettings.asset";

            if (!Directory.Exists(Constants.settingsFolder))
            {
                Directory.CreateDirectory(Constants.settingsFolder);
                AssetDatabase.Refresh();
            }

            setting = AssetDatabase.LoadAssetAtPath<Setting>(assetPath);

            if (setting == null)
            {
                setting = ScriptableObject.CreateInstance<Setting>();
                setting.Initialize(); 
                AssetDatabase.CreateAsset(setting, assetPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"Created new settings asset at {assetPath}");
            }

            AssetDatabase.Refresh();
        }
    }
}
