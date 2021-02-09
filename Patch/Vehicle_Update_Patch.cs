using Harmony;
using SeamothEngineUpgrades.InGame;
using UnityEngine;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    // ######################################################################
    // Patch Vehicle class Update()
    //
    // ######################################################################

    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("Update")]        // The Vehicle class's Update method.
    internal class Vehicle_Update_Patch
    {
        // ######################################################################
        // Patch - set speed
        // ######################################################################

        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(Vehicle __instance)
        {
            // Implement energy consumption changes
            Player main = Player.main; // player
            Vehicle thisSeamoth = (main.GetVehicle() as SeaMoth);

            float largeFactor = 3.5f;
            float smallFactor = 1.5f;

            float forwardForce = 13f; // (default)
            float backwardForce = 5f; // (default)
            float sidewardForce = 11.5f;  // (default)
            float verticalForce = 11f;  // (default)

            if (main != null && thisSeamoth != null)
            {
                bool upgradeLoaded = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;
                bool efficiencyLoaded = thisSeamoth.modules.GetCount(TechType.VehiclePowerUpgradeModule) > 0;
                bool playerPiloting = Player.main.GetMode() == Player.Mode.LockedPiloting;

                if (upgradeLoaded && playerPiloting)
                {
                    SeamothEngineUiManager.ShowUI(true);
                    if (Config.SeamothGearValue == 1f)
                    {
                        if (SeamothInfo.lastSeamothGearValue != 1f)
                        {
                            thisSeamoth.forwardForce = forwardForce - (largeFactor * 3f);
                            thisSeamoth.backwardForce = backwardForce - (smallFactor * 3f);
                            thisSeamoth.sidewardForce = sidewardForce - (largeFactor * 3f);
                            thisSeamoth.verticalForce = verticalForce - (largeFactor * 3f);
                            SeamothInfo.lastSeamothGearValue = 1f;
                        }
                    }
                    else if (Config.SeamothGearValue == 2f)
                    {
                        if (SeamothInfo.lastSeamothGearValue != 2f)
                        {
                            thisSeamoth.forwardForce = forwardForce - (largeFactor * 2f);
                            thisSeamoth.backwardForce = backwardForce - (smallFactor * 2f);
                            thisSeamoth.sidewardForce = sidewardForce - (largeFactor * 2f);
                            thisSeamoth.verticalForce = verticalForce - (largeFactor * 2f);
                            SeamothInfo.lastSeamothGearValue = 2f;
                        }
                    }
                    else if (Config.SeamothGearValue == 3f)
                    {
                        if (SeamothInfo.lastSeamothGearValue != 3f)
                        {
                            thisSeamoth.forwardForce = forwardForce - largeFactor;
                            thisSeamoth.backwardForce = backwardForce - smallFactor;
                            thisSeamoth.sidewardForce = sidewardForce - largeFactor;
                            thisSeamoth.verticalForce = verticalForce - largeFactor;
                            SeamothInfo.lastSeamothGearValue = 3f;
                        }
                    }
                    else if (Config.SeamothGearValue == 4f && SeamothInfo.lastSeamothGearValue != 4f)
                    {
                        thisSeamoth.forwardForce = forwardForce;
                        thisSeamoth.backwardForce = backwardForce;
                        thisSeamoth.sidewardForce = sidewardForce;
                        thisSeamoth.verticalForce = verticalForce;
                        SeamothInfo.lastSeamothGearValue = 4f;
                    }
                    else if (Config.SeamothGearValue == 5f)
                    {
                        if (SeamothInfo.lastSeamothGearValue != 5f)
                        {
                            thisSeamoth.forwardForce = forwardForce + largeFactor;
                            thisSeamoth.backwardForce = backwardForce + smallFactor;
                            thisSeamoth.sidewardForce = sidewardForce + largeFactor;
                            thisSeamoth.verticalForce = verticalForce + largeFactor;
                            SeamothInfo.lastSeamothGearValue = 5f;
                        }
                    }
                    else if (Config.SeamothGearValue == 6f)
                    {
                        if (SeamothInfo.lastSeamothGearValue != 6f)
                        {
                            thisSeamoth.forwardForce = forwardForce + (largeFactor * 2f);
                            thisSeamoth.backwardForce = backwardForce + (smallFactor * 2f);
                            thisSeamoth.sidewardForce = sidewardForce + (largeFactor * 2f);
                            thisSeamoth.verticalForce = verticalForce + (largeFactor * 2f);
                            SeamothInfo.lastSeamothGearValue = 6f;
                        }
                    }
                } // end if (upgradeLoaded && playerPiloting)
                else
                {
                    SeamothEngineUiManager.ShowUI(false);
                    if (SeamothInfo.lastSeamothGearValue != 0f)
                    {
                        thisSeamoth.forwardForce = forwardForce;
                        thisSeamoth.backwardForce = backwardForce;
                        thisSeamoth.sidewardForce = sidewardForce;
                        thisSeamoth.verticalForce = verticalForce;
                        SeamothInfo.lastSeamothGearValue = 0f;
                    }
                }
            }
        }
    }
}