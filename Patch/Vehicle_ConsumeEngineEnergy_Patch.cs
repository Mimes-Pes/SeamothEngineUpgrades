using Harmony;
using UnityEngine;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    // ######################################################################
    // Patch Vehicle class ConsumeEngineEnergy()
    //
    // ######################################################################

    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("ConsumeEngineEnergy")]        // The Vehicle class's Update method.
    internal class Vehicle_ConsumeEngineEnergy_Patch
    {
        [HarmonyPrefix]      // Harmony postfix
        public static bool Prefix(Vehicle __instance, ref float energyCost, ref bool __result)
        {
            float enginePowerRating = Traverse.Create(__instance).Field("enginePowerRating").GetValue<float>();
            EnergyInterface thisEnergyInterface = __instance.GetComponent<EnergyInterface>();
            EnergyMixin thisEnergyMixing = __instance.GetComponent<EnergyMixin>();
            float realEnergyCost = energyCost / enginePowerRating;

            if (Config.SeamothGearValue == 1f)
                realEnergyCost = energyCost * 0.1f / enginePowerRating;
            else if (Config.SeamothGearValue == 2f)
                realEnergyCost = energyCost * 0.3f / enginePowerRating;
            else if (Config.SeamothGearValue == 3f)
                realEnergyCost = energyCost * 0.7f / enginePowerRating;
            else if (Config.SeamothGearValue == 5f)
                realEnergyCost = energyCost * 4f / enginePowerRating;
            else if (Config.SeamothGearValue == 6f)
                realEnergyCost = energyCost * 10f / enginePowerRating;

            int num;
            float energyCanProvide = thisEnergyInterface.TotalCanProvide(out num);
            return thisEnergyMixing.ConsumeEnergy(Mathf.Min(realEnergyCost, energyCanProvide));

        } // end public static bool Prefix(Vehicle __instance, ref float energyCost, ref bool __result)

    } // end internal class Vehicle_ConsumeEngineEnergy_Patch

} // namespace SeamothEngineUpgrades 
