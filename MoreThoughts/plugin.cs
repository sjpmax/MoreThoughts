using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using System.Reflection;
using Timberborn.StockpilesUI;
using TimberApi.DependencyContainerSystem;
using Timberborn.Stockpiles;
using Timberborn.InventorySystem;

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

    //[HarmonyPatch]
    //public class KeyPressedPatch
    //{
    //public static MethodInfo TargetMethod()
    //{
    //    return AccessTools.Method(AccessTools.TypeByName("StockpileInventoryInitializer"), "Initialize", new[]
    //     {
    //         typeof(Stockpile), typeof(Inventory)
    //     });
    //}

    //    static void Postfix(StockpileOverlay stockpileOverlay)
    //    {
    //        DependencyContainer.GetInstance<IMoreThoughts>().hasButtonBeenPressed();
    //    }
    //}

}
