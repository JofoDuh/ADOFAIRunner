using ADOFAIRunner.Core;
using ADOFAIRunner.Utilities;
using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.Progress;

namespace ADOFAIRunner.DefineSymbols.Toolbar
{
    [InitializeOnLoad]
    public static class RunADOFAIToolbar
    {
        static Setting setting = Main.setting;
        static string[] Buildtooltips = new string[] {
            "Use to switch build for selected mod\n\nCurrent Build: Unity Mod Manager",
            "Use to switch build for selected mod\n\nCurrent Build: BepInEx",
        };

        static RunADOFAIToolbar()
        {
            ToolbarExtender.LeftToolbarGUI.Insert(0 ,OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            using (new VerticalScope())
            {
                GUILayout.Space(2);
                using (new HorizontalScope())
                {
                    GUILayout.Space(20);
                    GUIContent[] guiOptions = new GUIContent[setting.AvailableBuildOptions.Length];
                    for (int i = 0; i < setting.AvailableBuildOptions.Length; i++)
                    {
                        guiOptions[i] = new GUIContent(setting.AvailableBuildOptions[i], 
                            Buildtooltips[i]);
                    }
                    try
                    {
                        setting.AvailableBuildOptionsSelectedIndex = EditorGUILayout.Popup(
                            setting.AvailableBuildOptionsSelectedIndex,
                            guiOptions,
                            GUILayout.Width(ProjectUtilities.DynamicaWidth(setting.AvailableBuildOptions[setting.AvailableBuildOptionsSelectedIndex], 5f))
                            
                        );
                    }
                    finally { }
                }
            }
        }
    }
}