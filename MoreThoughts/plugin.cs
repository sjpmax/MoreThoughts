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
using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.Characters;
using Timberborn.GameDistricts;
using Timberborn.PrefabSystem;
using UnityEngine;
using Timberborn.StockpilesUI;
using Timberborn.FactionSystemGame;
using TimberApi.DependencyContainerSystem;

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
        public static MethodInfo TargetMethod()
        {
            return AccessTools.Method(AccessTools.TypeByName("StockpileOverlay"), "Load", new[]
            {
                 typeof(StockpileOverlay)
             });
        }

        static void Postfix(StockpileOverlay stockpileOverlay)
        {
            DependencyContainer.GetInstance<IMoreThoughts>().hasButtonBeenPressed();
        }
    }

    }
