using ADOFAIRunner.DefineSymbols.Core;
using System.Collections.Generic;
using ThunderKit.Core.Pipelines;
using UnityEngine;

namespace ADOFAIRunner.Core
{
    [CreateAssetMenu(fileName = "ARSetting", menuName = "ADOFAI Runner/Settings", order = 1)]
    public class Setting : ScriptableObject
    {
        public string BepInExModFolderPath;
        public string BepInExExePath;

        public string UnityModManagerExePath;
        public string UMMModFolderPath;

        public string ThunderkitOutputPath;

        public bool AutoCheckBuild;

        public List<Pipeline> AvailableMods = new List<Pipeline>();
        public int AvailableModsSelectedIndex;

        public  string[] AvailableBuildOptions = new string[] { "Unity Mod Manager", "BepInEx" };
        int _AvailableBuildOptionsSelectedIndex;
        public  int AvailableBuildOptionsSelectedIndex
        {
            get
            {
                return _AvailableBuildOptionsSelectedIndex;
            }
            set
            {
                if (value == _AvailableBuildOptionsSelectedIndex) return;
                _AvailableBuildOptionsSelectedIndex = value;
                DefineSymbolToggler.SetBuild(value);
            }
        }

        public void Initialize()
        {

        }
    }
}