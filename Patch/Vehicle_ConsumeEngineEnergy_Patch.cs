using Harmony;
using UnityEngine;

namespace SeamothEngineUpgrades
{
    [HarmonyPatch(typeof(Vehicle))]
    [HarmonyPatch("ConsumeEngineEnergy")]
    internal class Vehicle_ConsumeEngineEnergy_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Vehicle __instance, ref float energyCost, ref bool __result)
        {
            float enginePowerRating = Traverse.Create(__instance).Field("enginePowerRating").GetValue<float>();
            EnergyInterface thisEnergyInterface = __instance.GetComponent<EnergyInterface>();
            EnergyMixin thisEnergyMixing = __instance.GetComponent<EnergyMixin>();

            var multiplier = 0.0f;
            switch (Config.SeamothGearValue)
            {
                case 1f:
                    multiplier = 0.1f;
                    break;
                case 2f:
                    multiplier = 0.3f;
                    break;
                case 3f:
                    multiplier = 0.7f;
                    break;
                case 4f:
                    multiplier = 1f;
                    break;
                case 5f:
                    multiplier = 4.0f;
                    break;
                case 6f:
                    multiplier = 10.0f;
                    break;
            }

            var realEnergyCost = energyCost * multiplier / enginePowerRating;

            float energyCanProvide = thisEnergyInterface.TotalCanProvide(out int num);
            return thisEnergyMixing.ConsumeEnergy(Mathf.Min(realEnergyCost, energyCanProvide));
        }
    }
}