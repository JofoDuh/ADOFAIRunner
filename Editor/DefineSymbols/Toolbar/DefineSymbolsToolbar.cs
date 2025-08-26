using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using static UnityEditor.EditorGUILayout;
using ADOFAIRunner.Core;

namespace ADOFAIRunner.DefineSymbols.Toolbar
{
    [InitializeOnLoad]
    public static class RunADOFAIToolbar
    {
        static Setting setting = Main.setting;
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
                    try
                    {
                        EditorGUILayout.LabelField("Current Build Target:", GUILayout.Width(120));
                        setting.AvailableBuildOptionsSelectedIndex = EditorGUILayout.Popup(
                            setting.AvailableBuildOptionsSelectedIndex,
                            setting.AvailableBuildOptions,
                            GUILayout.Width(135)
                        );
                    }
                    finally { }
                }
            }
        }
    }
}