using System.Text;
using Harmony;
using UnityEngine;
using SMLHelper.V2.Utility;

namespace SeamothEngineUpgrades
{
    [HarmonyPatch(typeof(SeaMoth))]
    [HarmonyPatch("Update")]
    internal class SeaMoth_Update_Patch
    {
        // Change vanilla Seamoth operation.
        [HarmonyPostfix]
        public static void Postfix(SeaMoth __instance)
        {
            if (__instance.GetPilotingMode())
            {

                bool upgradeLoaded = __instance.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;

                if (upgradeLoaded)
                {
                    // Detect key press and set variable to cycle through health display (mh, h, %)
                    if (KeyCodeUtils.GetKeyDown(Config.HealthKeybindValue))
                    {
                        if (Config.MarchThroughHealthValue == 1f)
                        {
                            Config.MarchThroughHealthValue = 2f;
                            PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 2f);
                        }
                        else if (Config.MarchThroughHealthValue == 2)
                        {
                            Config.MarchThroughHealthValue = 3f;
                            PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 3f);
                        }
                        else
                        {
                            Config.MarchThroughHealthValue = 1f;
                            PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 1f);
                        }
                    }
                    // Detect key press and set variable to cycle through power display (mu, u, %)
                    if (KeyCodeUtils.GetKeyDown(Config.PowerKeybindValue))
                    {
                        if (Config.MarchThroughPowerValue == 1f)
                        {
                            Config.MarchThroughPowerValue = 2f;
                            PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 2f);
                        }
                        else if (Config.MarchThroughPowerValue == 2)
                        {
                            Config.MarchThroughPowerValue = 3f;
                            PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 3f);
                        }
                        else
                        {
                            Config.MarchThroughPowerValue = 1f;
                            PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 1f);
                        }
                    }
                    // Detect key press and set variable (march up) to set Seamoth gear
                    if (KeyCodeUtils.GetKeyDown(Config.GearUpKeybindValue))
                    {
                        var gearVal = Config.SeamothGearValue + 1f;
                        if (gearVal > 6f) return;
                        Config.SeamothGearValue = gearVal;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);
                    }
                    // Detect key press and set variable (march down) to set Seamoth gear
                    if (KeyCodeUtils.GetKeyDown(Config.GearDownKeybindValue))
                    {
                        var gearVal = Config.SeamothGearValue - 1f;
                        if (gearVal < 1f) return;
                        Config.SeamothGearValue = gearVal;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);
                    } 


                    // setup and display key press prompts as selected in mod options
                    Player main = Player.main;
                    if (main != null && !main.GetPDA().isInUse)
                    {
                        if (Config.ShowKeyPromptToggleValue)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
                            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();
                            
                            string text = "";
                            text += $"Gear up (<color=#ADF8FFFF>{Config.GearUpKeybindValue}</color>)  down (<color=#ADF8FFFF>{Config.GearDownKeybindValue}</color>) \n";
                            // prompt for gear changes
                            //stringBuilder.Append("Gear up ");
                            //stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearUpKeybindValue.ToString());
                            //stringBuilder.Append(" down ");
                            //stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearDownKeybindValue.ToString());
                            //stringBuilder.Append('\n');
                            text += $"Cycle health (<color=#ADF8FFFF>{Config.HealthKeybindValue}</color>)  power (<color=#ADF8FFFF>{Config.PowerKeybindValue}</color>) \n";
                            //prompt for health and power info cycle
                            //stringBuilder.Append("Cycle health ");
                            //stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.HealthKeybindValue.ToString());
                            //stringBuilder.Append(" power ");
                            //stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.PowerKeybindValue.ToString());
                            //stringBuilder.Append('\n');
                            //stringBuilder.Append(thisText1);
                            //string result = stringBuilder.ToString();
                            text += thisText1;
                            HandReticle.main.SetUseTextRaw(text, thisText2);
                        }
                    }
                }
            }
        }
    }
}
