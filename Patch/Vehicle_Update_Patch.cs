using Harmony;
using SeamothEngineUpgrades.InGame;

namespace SeamothEngineUpgrades
{
    [HarmonyPatch(typeof(Vehicle))]
    [HarmonyPatch("Update")]
    internal class Vehicle_Update_Patch
    {
        static float largeFactor = 3.5f;
        static float smallFactor = 1.5f;

        static float forwardForce = 13f;
        static float backwardForce = 5f;
        static float sidewardForce = 11.5f;
        static float verticalForce = 11f;
        [HarmonyPostfix]
        public static void Postfix(Vehicle __instance)
        {
            if (Player.main == null) return;
            // Implement energy consumption changes
            var _seamoth = (SeaMoth)Player.main.GetVehicle();

            if (_seamoth != null)
            {
                if (SeamothEngineUiManager.IsUIVisible)
                {
                    if (Config.SeamothGearValue == 1f && SeamothInfo.lastSeamothGearValue != 1f)
                        SetGear(_seamoth, 1f, 3f, -1f);
                    else if (Config.SeamothGearValue == 2f && SeamothInfo.lastSeamothGearValue != 2f)
                        SetGear(_seamoth, 2f, 2f, -1f);
                    else if (Config.SeamothGearValue == 3f && SeamothInfo.lastSeamothGearValue != 3f)
                        SetGear(_seamoth, 3f, 1f, -1f);
                    else if (Config.SeamothGearValue == 4f && SeamothInfo.lastSeamothGearValue != 4f)
                        SetGear(_seamoth, 4f, 0f, 1f);
                    else if (Config.SeamothGearValue == 5f && SeamothInfo.lastSeamothGearValue != 5f)
                        SetGear(_seamoth, 5f, 1f, 1f);
                    else if (Config.SeamothGearValue == 6f && SeamothInfo.lastSeamothGearValue != 6f)
                        SetGear(_seamoth, 6f, 2f, 1f);

                }
                else
                {
                    if (SeamothInfo.lastSeamothGearValue != 0f)
                    {
                        SetGear(_seamoth, 0f, 1f, 1f);
                    }
                }
            }
        }

        private static void SetGear(SeaMoth _seamoth, float gear, float multip, float direction)
        {
            _seamoth.forwardForce = forwardForce + (largeFactor * multip * direction);
            _seamoth.backwardForce = backwardForce + (smallFactor * multip * direction);
            _seamoth.sidewardForce = sidewardForce + (largeFactor * multip * direction);
            _seamoth.verticalForce = verticalForce + (largeFactor * multip * direction);
            SeamothInfo.lastSeamothGearValue = gear;
        }
    }
}