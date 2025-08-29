using ADOFAIRunner.Core;
using ADOFAIRunner.Core.Windows;
using ADOFAIRunner.Utilities;
using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using static UnityEditor.EditorGUILayout;

namespace ADOFAIRunner.Toolbar
{
    [InitializeOnLoad]
    public static class RunADOFAIToolbar
    {
        public static Setting setting = Main.setting;
        private static Texture2D gearIcon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
        private static bool runButtonEnabled = true;
        static bool FastRunOption = false;

        static RunADOFAIToolbar()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            using (new VerticalScope())
            {
                GUILayout.Space(2);
                using (new HorizontalScope())
                {
                    try
                    {
                        if (setting.AvailableMods != null &&
                            setting.AvailableMods.Count > 0 &&
                            setting.AvailableModsSelectedIndex >= 0 &&
                            setting.AvailableModsSelectedIndex < setting.AvailableMods.Count &&
                            setting.AvailableMods[setting.AvailableModsSelectedIndex] != null)
                        {
                            var list = new GUIContent[setting.AvailableMods.Count];
                            for (int i = 0; i < setting.AvailableMods.Count; i++)
                            {
                                list[i] = new GUIContent(setting.AvailableMods[i].name, "Add more mods in the ADOFAIRunner settings!");
                            }

                            setting.AvailableModsSelectedIndex = EditorGUILayout.Popup(
                                setting.AvailableModsSelectedIndex,
                                list,
                                GUILayout.Width(ProjectUtilities.DynamicaWidth(setting.AvailableMods[setting.AvailableModsSelectedIndex].name, 5f))
                            );

                            GUI.enabled = runButtonEnabled;
                            if (GUILayout.Button(
                                new GUIContent("Run", "Run ADOFAI after importing ThunderKit's compiled things"),
                                GUILayout.Width(35f)))
                            {
                                Debug.Log($"Running {setting.AvailableMods[setting.AvailableModsSelectedIndex]}");
                                OnRunButtonClicked();
                            }
                        }

                        if (GUILayout.Button(
                            new GUIContent("FRun", "Quick Run ADOFAI without compiling or anything"),
                            GUILayout.Width(43f)))
                        {
                            FastRunOption = !FastRunOption;
                        }
                        if (FastRunOption)
                        {
                            if (GUILayout.Button(
                                new GUIContent("UMM", "Quick Run ADOFAI without compiling or anything"),
                                GUILayout.Width(45f)))
                            {
                                FastRunOption = false;
                                OnRunButtonClicked(true, RunLogic.BuildTarget.UMM);
                            }
                            if (GUILayout.Button(
                                new GUIContent("BepInEx", "Quick Run ADOFAI without compiling or anything"),
                                GUILayout.Width(55f)))
                            {
                                FastRunOption = false;
                                OnRunButtonClicked(true, RunLogic.BuildTarget.BepInEx);
                            }
                        }
                        GUI.enabled = true; 

                        if (GUILayout.Button(new GUIContent(gearIcon, "Open ADOFAIRunner Settings"), 
                            GUILayout.Width(20f), GUILayout.Height(20f)))
                        {
                            SettingsWindow.ShowSetting();
                        }
                        GUILayout.Space(10);
                    }
                    finally { }
                }
            }
        }
        private static async void OnRunButtonClicked(bool fastRun = false, RunLogic.BuildTarget build = RunLogic.BuildTarget.Auto)
        {
            runButtonEnabled = false;
            try
            {
                await RunLogic.BuildAndRun(Main.setting, fastRun, build);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"An error occurred during the build and run process: {e.Message}");
            }
            runButtonEnabled = true;
        }
    }
}