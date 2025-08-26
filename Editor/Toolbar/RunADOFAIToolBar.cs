using ADOFAIRunner.Common;
using ADOFAIRunner.Core;
using ADOFAIRunner.Core.Windows;
using ADOFAIRunner.Utilities;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityToolbarExtender;
using static UnityEditor.EditorGUILayout;

namespace ADOFAIRunner.Toolbar
{
    [InitializeOnLoad]
    public static class RunADOFAIToolbar
    {
        public static Setting setting = Main.setting;
        public static int selectedIndex;
        private static Texture2D gearIcon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
        private static bool runButtonEnabled = true;

        static RunADOFAIToolbar()
        {
            ToolbarExtender.RightToolbarGUI.Insert(0, OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            using (new VerticalScope())
            {
                GUILayout.Space(2);
                using (new HorizontalScope())
                {
                    if (setting.AvailableMods.Count <= 0 || selectedIndex >= setting.AvailableMods.Count) return;
                    string currentText = setting.AvailableMods[selectedIndex].name;
                    GUIStyle popupStyle = EditorStyles.popup;
                    Vector2 size = popupStyle.CalcSize(new GUIContent(currentText));
                    float dynamicWidth = size.x + 5f;
                    //float dynamicSpacing = 760f - 35f - dynamicWidth; // Good if self-contained, bad when other uses LeftToolbar as well
                    //GUILayout.Space(dynamicSpacing);

                    try
                    {
                        var list = new List<string>();
                        foreach (var Pipeline in setting.AvailableMods)
                        {
                            list.Add(Pipeline.name);
                        }
                        setting.AvailableModsSelectedIndex = EditorGUILayout.Popup(
                            setting.AvailableModsSelectedIndex,
                            list.ToArray(),
                            GUILayout.Width(dynamicWidth)
                        );

                        // Button
                        GUI.enabled = runButtonEnabled;
                        if (GUILayout.Button(
                            new GUIContent("Run", "Run ADOFAI after importing ThunderKit's compiled things"),
                            GUILayout.Width(35f)))
                        {
                            Debug.Log($"Running {setting.AvailableMods[setting.AvailableModsSelectedIndex]}");
                            OnRunButtonClicked();
                        }
                        GUI.enabled = true; // reset so other UI isn’t disabled

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
        private static async void OnRunButtonClicked()
        {
            runButtonEnabled = false;
            try
            {
                await RunLogic.BuildAndRun(Main.setting);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"An error occurred during the build and run process: {e.Message}");
            }
            finally
            {
                runButtonEnabled = false;
            }
        }
    }
}