using UnityEngine;
using UnityEngine.UI;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    // ######################################################################
    // Internal classes to hold info
    //
    // ######################################################################

    internal static class GearInfo
    {
        internal static string hud_Text = "Gear: ";
        internal static string colorYellow = "<color=yellow>";
        internal static string colorRed = "<color=red>";
        internal static string colorEnd = "</color>";
        internal static Text gearDisplayText;
        internal static GameObject gameObject;
        internal static Vector3 hud_Position = new Vector3(600f, -185f, 0f);
        internal static Vector2 hud_Size = new Vector2(500f, 150f);
        internal static float? nextEnergyConsumption;

    }

} // namespace SeamothEngineUpgrades 
