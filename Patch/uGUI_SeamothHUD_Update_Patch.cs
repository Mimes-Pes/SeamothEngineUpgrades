using System.Text;
using Harmony;
using SeamothEngineUpgrades.InGame;
using UnityEngine;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    [HarmonyPatch(typeof(uGUI_SeamothHUD))]
    [HarmonyPatch("Update")]
    internal class uGUI_SeamothHUD_Update_Patch
    {
        static string Font => Config.VehicleFontSizeSliderValue.ToString();
        static string Size => (Config.VehicleFontSizeSliderValue / 1.5f).ToString();

        // Change vanilla uGUI_SeamothHUD operation.
        [HarmonyPostfix]
        public static void Postfix(uGUI_SeamothHUD __instance)
        {

            Player main = Player.main;
            if (main != null)
            {
                SeaMoth _seamoth = (SeaMoth)main.GetVehicle();
                // Info Display
                if (_seamoth != null)
                {
                    SetHealthDisplay(_seamoth, __instance);
                    SetPowerDisplay(_seamoth, __instance);
                    SetTemperatureDisplay(_seamoth, __instance);
                }
            }
        }

        private static void SetHealthDisplay(Vehicle seaMoth, uGUI_SeamothHUD __instance) 
        {
            LiveMixin thisLiveMixin = seaMoth.GetComponent<LiveMixin>();
            float healthStatus = thisLiveMixin.GetHealthFraction();

            // Run only if the upgrade is loaded
            if (SeamothEngineUiManager.IsUIVisible)
            {
                string textJoin;
                switch (Config.MarchThroughHealthValue)
                {
                    case 1f:
                        var healtMax = Mathf.Round(thisLiveMixin.data.maxHealth).ToString();
                        textJoin = $"<size={Font}><color={nameof(Color.white)}>{healtMax}</color></size> <size={Size}><color={nameof(Color.yellow)}>mh</color></size>";
                        break;
                    case 2f:
                        var healt = Mathf.Round(thisLiveMixin.health).ToString();
                        textJoin = $"<size={Font}><color={Config.GetHealtColor(healthStatus)}>{healt}</color></size> <size={Size}><color={nameof(Color.yellow)}>h</color></size>";
                        break;
                    default:
                        var healtDefault = Mathf.Round(healthStatus * 100f).ToString();
                        textJoin = $"<size={Font}><color={Config.GetHealtColor(healthStatus)}>{healtDefault}%</color></size>";
                        break;
                }
                //__instance.textHealth.text = textJoin;
                SeamothEngineUiManager.SetLifeText(textJoin);
            }
            else // display as per vanilla game
            {
                var healt = Mathf.Round(healthStatus * 100f).ToString();
                //__instance.textHealth.text = healt;
                SeamothEngineUiManager.SetLifeText(healt);
            }
        }

        private static void SetPowerDisplay(Vehicle seaMoth, uGUI_SeamothHUD __instance)
        {
            EnergyMixin thisEnergyMixing = seaMoth.GetComponent<EnergyMixin>();
            EnergyInterface thisEnergyInterface = thisEnergyMixing.GetComponent<EnergyInterface>();
            float charge;
            float capacity;
            thisEnergyInterface.GetValues(out charge, out capacity);

            if (SeamothEngineUiManager.IsUIVisible)
            {
                string textJoin;
                switch (Config.MarchThroughPowerValue)
                {
                    case 1f:// units(mu)
                        textJoin = $"<size={Font}><color={nameof(Color.white)}>{capacity}</color></size> <size={Size}><color={nameof(Color.yellow)}>mu</color></size>";
                        break;
                    case 2f:// units(u)
                        textJoin = $"<size={Font}><color={Config.GetPowerColor(charge, capacity)}>{Mathf.RoundToInt(charge).ToString()}</color></size> <size={Size}><color={nameof(Color.yellow)}>u</color></size>";
                        break;
                    default:// units(%)
                        var valueToDisplay = capacity == 0f ? "N/A" : $"{Mathf.RoundToInt(charge / capacity * 100f).ToString()}%";
                        textJoin = $"<size={Font}><color={Config.GetPowerColor(charge, capacity)}>{valueToDisplay}</color></size>";
                        break;
                }
                //__instance.textPower.text = textJoin;
                SeamothEngineUiManager.SetEnergyText(textJoin);
            }
            else // display as per vanilla game
            {
                var vanillapower = Mathf.RoundToInt(charge / capacity * 100f).ToString();
                //__instance.textPower.text = vanillapower;
                SeamothEngineUiManager.SetEnergyText(vanillapower);
            }
        }

        private static void SetTemperatureDisplay(Vehicle seamoth, uGUI_SeamothHUD __instance) 
        {
            var waterTemp = Traverse.Create(__instance).Field("lastTemperature").GetValue<int>();

            if (SeamothEngineUiManager.IsUIVisible)
            {
                string textJoin;
                // Set warning colours of water temperature as per mod options
                textJoin = $"<size={Font}><color={Config.GetTempColor(waterTemp)}>{waterTemp}</color></size>";
                __instance.textTemperature.text = textJoin;
            }
            else // display as per vanilla game
            {
                __instance.textTemperature.text = waterTemp.ToString();
            }
        }
    }

}
