using System.IO;
using System.Reflection;
using SeamothEngineUpgrades.Modules;
using Harmony;
using SMLHelper.V2.Handlers;


namespace SeamothEngineUpgrades     // Line matching mod name.
{
    public class MainPatcher
    {
        private static Assembly thisAssembly = Assembly.GetExecutingAssembly();
        private static string ModPath = Path.GetDirectoryName(thisAssembly.Location);
        internal static string AssetsFolder = Path.Combine(ModPath, "Assets");

        public static string _AssetName => "SeamothEngineUpgradesAsset";

        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.mimes.subnautica.seamothengineupgrades");   // Name to match mod.
            var seamothEngineUpgrades = new SeamothEngineUpgradesModule();
            seamothEngineUpgrades.Patch();
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
        }
    }
}
