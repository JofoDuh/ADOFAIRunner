using UnityEditor;
using UnityEngine;

namespace ADOFAIRunner.Utilities
{
    public static class ProjectUtilities
    {
        public static void CreateFolderInAssets(string folderName)
        {
            string path = "Assets/" + folderName;

            if (!AssetDatabase.IsValidFolder(path))
            {
                // Create the folder inside Assets
                AssetDatabase.CreateFolder("Assets", folderName);
                AssetDatabase.Refresh();
                Debug.Log($"Created folder at: {path}");
            }
            else
            {
                Debug.Log($"Folder already exists: {path}");
            }
        }

        public static string GetCurrentBuild()
        {
            string UMM_SYMBOL = "UNITYMODMANAGER";
            string BEPINEX_SYMBOL = "BEPINEX";

            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            bool hasUMM = symbols.Contains(UMM_SYMBOL);
            bool hasBepInEx = symbols.Contains(BEPINEX_SYMBOL);

            if (hasUMM && !hasBepInEx)
            {
                return UMM_SYMBOL;
            }
            return BEPINEX_SYMBOL;
        }
    }
}