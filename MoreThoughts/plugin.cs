using HarmonyLib;
using System;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.ConstructionMode;
using Timberborn.Core;
using Timberborn.Debugging;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace MoreThoughts
{
    public class Plugin : IModEntrypoint
    {
        public const string PluginGuid = "MoreThoughts";

        public static IConsoleWriter Log;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Log = consoleWriter;

            new Harmony(PluginGuid).PatchAll();
        }
    }

    [HarmonyPatch]
    public class KeyPressedPatch
    {

    }
    
}
