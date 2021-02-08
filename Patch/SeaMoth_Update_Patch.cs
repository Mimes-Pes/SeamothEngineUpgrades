using System.Text;
using Harmony;
using UnityEngine;
using SMLHelper.V2.Utility;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    // ######################################################################
    // Patch Seamoth class Update() - implement gear and player prompts changes
    //
    // ######################################################################

    [HarmonyPatch(typeof(SeaMoth))]  // Patch for the SeaMoth class.
    [HarmonyPatch("Update")]        // The SeaMoth class's Update method.
    internal class SeaMoth_Update_Patch
    {
        // Change vanilla Seamoth operation.
        [HarmonyPostfix]      // Harmony postfix
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
                    } // end if (KeyCodeUtils.GetKeyDown(Config.HealthKeybindValue))

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
                    } // end if (KeyCodeUtils.GetKeyDown(Config.PowerKeybindValue))

                    // Detect key press and set variable (march up) to set Seamoth gear
                    if (KeyCodeUtils.GetKeyDown(Config.GearUpKeybindValue))
                    {
                        var gearVal = Config.SeamothGearValue + 1f;
                        if (gearVal > 5f) return;
                        Config.SeamothGearValue = gearVal;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);
                        //if (Config.SeamothGearValue == 1f)
                        //{
                        //    Config.SeamothGearValue = 2f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 2f);
                        //}
                        //else if (Config.SeamothGearValue == 2f)
                        //{
                        //    Config.SeamothGearValue = 3f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 3f);
                        //}
                        //else if (Config.SeamothGearValue == 3f)
                        //{
                        //    Config.SeamothGearValue = 4f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 4f);
                        //}
                        //else if (Config.SeamothGearValue == 4f)
                        //{
                        //    Config.SeamothGearValue = 5f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 5f);
                        //}
                        //else if (Config.SeamothGearValue == 5f)
                        //{
                        //    Config.SeamothGearValue = 6f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 6f);
                        //}
                    } // end if (KeyCodeUtils.GetKeyDown(KeyCode.LeftShift))

                    // Detect key press and set variable (march down) to set Seamoth gear
                    if (KeyCodeUtils.GetKeyDown(Config.GearDownKeybindValue))
                    {
                        var gearVal = Config.SeamothGearValue - 1f;
                        if (gearVal < 1f) return;
                        Config.SeamothGearValue = gearVal;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);
                        //if (Config.SeamothGearValue == 6f)
                        //{
                        //    Config.SeamothGearValue = 5f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 5f);
                        //}
                        //else if (Config.SeamothGearValue == 5f)
                        //{
                        //    Config.SeamothGearValue = 4f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 4f);
                        //}
                        //else if (Config.SeamothGearValue == 4f)
                        //{
                        //    Config.SeamothGearValue = 3f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 3f);
                        //}
                        //else if (Config.SeamothGearValue == 3f)
                        //{
                        //    Config.SeamothGearValue = 2f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 2f);
                        //}
                        //else if (Config.SeamothGearValue == 2f)
                        //{
                        //    Config.SeamothGearValue = 1f;
                        //    PlayerPrefs.SetFloat("SeamothGearValueSlider", 1f);
                        //}
                    } // end if (KeyCodeUtils.GetKeyDown(KeyCode.LeftControl))


                    // setup and display key press prompts as selected in mod options
                    Player main = Player.main;
                    if (main != null && !main.GetPDA().isInUse)
                    {
                        if (Config.ShowKeyPromptToggleValue)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
                            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

                            // prompt for gear changes
                            stringBuilder.Append("Gear up ");
                            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearUpKeybindValue.ToString());
                            stringBuilder.Append(" down ");
                            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearDownKeybindValue.ToString());
                            stringBuilder.Append('\n');

                            //prompt for health and power info cycle
                            stringBuilder.Append("Cycle health ");
                            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.HealthKeybindValue.ToString());
                            stringBuilder.Append(" power ");
                            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.PowerKeybindValue.ToString());
                            stringBuilder.Append('\n');

                            stringBuilder.Append(thisText1);
                            string result = stringBuilder.ToString();
                            HandReticle.main.SetUseTextRaw(result, thisText2);

                        } // end if (Config.ShowPromptToggleValue)

                    } // end if (main != null)

                } // end if (upgradeLoaded)

            } // end if (__instance.GetPilotingMode())

        } // end public static void Postfix(SeaMoth __instance)

    }// end internal class SeaMoth_Update_Patch

} // namespace SeamothEngineUpgrades 
