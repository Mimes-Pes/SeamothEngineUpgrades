using System.Text;
using Harmony;
using UnityEngine;
using UnityEngine.UI;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
    // Mod config to show in Q-Mod options.
    public static class Config
    {
        public static bool ShowCellCapacityValue; // keep as a switch
        public static float MarchThroughHealthValue; // keep as a switch
        public static float MarchThroughPowerValue; // keep as a switch  
        public static float SeamothGearValue; // keep as a switch

        // User changeable values
        public static float VehicleFontSizeSliderValue;

        public static bool ShowKeyPromptToggleValue;

        public static KeyCode GearUpKeybindValue;
        public static KeyCode GearDownKeybindValue;

        public static KeyCode HealthKeybindValue;
        public static KeyCode PowerKeybindValue;

        public static float HealthLowerLimitSliderValue;
        public static float HealthUpperLimitSliderValue;

        public static float PowerLowerLimitSliderValue;
        public static float PowerUpperLimitSliderValue;

        public static float TempMothLowerLimitSliderValue;
        public static float TempMothUpperLimitSliderValue;

        public static void Load()
        {
            ShowCellCapacityValue = PlayerPrefsExtra.GetBool("ShowCellCapacityToggle", false); ;  // keep as a switch
            MarchThroughHealthValue = PlayerPrefs.GetFloat("MarchThroughHealthValueSlider", 3f);  // keep as a switch
            MarchThroughPowerValue = PlayerPrefs.GetFloat("MarchThroughPowerValueSlider", 3f);  // keep as a switch   
            SeamothGearValue = PlayerPrefs.GetFloat("SeamothGearValueSlider", 1f);  // keep as a switch 

            // User changeable values
            VehicleFontSizeSliderValue = PlayerPrefs.GetFloat("VehicleFontSizeSlider", 30f);

            ShowKeyPromptToggleValue = PlayerPrefsExtra.GetBool("ShowKeyPromptToggle", true);

            GearUpKeybindValue = PlayerPrefsExtra.GetKeyCode("GearUpKeybindPress", KeyCode.LeftShift);
            GearDownKeybindValue = PlayerPrefsExtra.GetKeyCode("GearDownKeybindPress", KeyCode.LeftControl);

            HealthKeybindValue = PlayerPrefsExtra.GetKeyCode("HealthKeybindPress", KeyCode.H);
            PowerKeybindValue = PlayerPrefsExtra.GetKeyCode("PowerKeybindPress", KeyCode.J);

            PowerLowerLimitSliderValue = PlayerPrefs.GetFloat("PowerLowerLimitSlider", 33f);
            PowerUpperLimitSliderValue = PlayerPrefs.GetFloat("PowerUpperLimitSlider", 66f);

            HealthLowerLimitSliderValue = PlayerPrefs.GetFloat("HealthLowerLimitSlider", 33f);
            HealthUpperLimitSliderValue = PlayerPrefs.GetFloat("HealthUpperLimitSlider", 66f);

            TempMothLowerLimitSliderValue = PlayerPrefs.GetFloat("TempMothLowerLimitSlider", 30f);
            TempMothUpperLimitSliderValue = PlayerPrefs.GetFloat("TempMothUpperLimitSlider", 45f);

        } // end public static void Load()

    } // end public static class Config


    public class Options : ModOptions
    {
        public Options() : base("Seamoth Engine Upgrades")
        {
            SliderChanged += Options_VehicleFontSizeSliderChanged;

            ToggleChanged += Options_PromptToggleValueChanged;

            KeybindChanged += Options_GearUpKeybindValueChanged;
            KeybindChanged += Options_GearDownKeybindValueChanged;

            KeybindChanged += Options_HealthKeybindValueChanged;
            KeybindChanged += Options_PowerKeybindValueChanged;

            SliderChanged += Options_HealthLowerLimitSliderChanged;
            SliderChanged += Options_HealthUpperLimitSliderChanged;

            SliderChanged += Options_PowerLowerLimitSliderChanged;
            SliderChanged += Options_PowerUpperLimitSliderChanged;

            SliderChanged += Options_TempMothLowerLimitSliderChanged;
            SliderChanged += Options_TempMothUpperLimitSliderChanged;

        } // end public Options() : base("Better Vehicle Info")


        public void Options_VehicleFontSizeSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "vehicleFontSizeSlider") return;
            Config.VehicleFontSizeSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("VehicleFontSizeSlider", Mathf.Floor(e.Value));
        }


        public void Options_PromptToggleValueChanged(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id != "showKeyPromptToggle") return;
            Config.ShowKeyPromptToggleValue = e.Value;
            PlayerPrefsExtra.SetBool("ShowKeyPromptToggle", e.Value);
        }


        public void Options_GearUpKeybindValueChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "gearUpKeybindPress") return;
            Config.GearUpKeybindValue = e.Key;
            PlayerPrefsExtra.SetKeyCode("GearUpKeybindPress", e.Key);
        }
        public void Options_GearDownKeybindValueChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "gearDownKeybindPress") return;
            Config.GearDownKeybindValue = e.Key;
            PlayerPrefsExtra.SetKeyCode("GearDownKeybindPress", e.Key);
        }


        public void Options_HealthKeybindValueChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "healthKeybindPress") return;
            Config.HealthKeybindValue = e.Key;
            PlayerPrefsExtra.SetKeyCode("HealthKeybindPress", e.Key);
        }
        public void Options_PowerKeybindValueChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "powerKeybindPress") return;
            Config.PowerKeybindValue = e.Key;
            PlayerPrefsExtra.SetKeyCode("PowerKeybindPress", e.Key);
        }


        public void Options_HealthLowerLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "healthLowerLimitSlider") return;
            Config.HealthLowerLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("HealthLowerLimitSlider", Mathf.Floor(e.Value));
        }
        public void Options_HealthUpperLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "healthUpperLimitSlider") return;
            Config.HealthUpperLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("HealthUpperLimitSlider", Mathf.Floor(e.Value));
        }


        public void Options_PowerLowerLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "powerLowerLimitSlider") return;
            Config.PowerLowerLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("PowerLowerLimitSlider", Mathf.Floor(e.Value));
        }
        public void Options_PowerUpperLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "powerUpperLimitSlider") return;
            Config.PowerUpperLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("PowerUpperLimitSlider", Mathf.Floor(e.Value));
        }


        public void Options_TempMothLowerLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "tempMothLowerLimitSlider") return;
            Config.TempMothLowerLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("TempMothLowerLimitSlider", Mathf.Floor(e.Value));
        }
        public void Options_TempMothUpperLimitSliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "tempMothUpperLimitSlider") return;
            Config.TempMothUpperLimitSliderValue = Mathf.Floor(e.Value);
            PlayerPrefs.SetFloat("TempMothUpperLimitSlider", Mathf.Floor(e.Value));
        }


        // Default values of the mod
        public override void BuildModOptions()
        {
            AddSliderOption("vehicleFontSizeSlider", "Font size health/charge (defult is 39)", 10, 40, Config.VehicleFontSizeSliderValue);

            AddToggleOption("showKeyPromptToggle", "Show key prompt", Config.ShowKeyPromptToggleValue);

            AddKeybindOption("gearUpKeybindPress", "Gear up key assignment", GameInput.Device.Keyboard, Config.GearUpKeybindValue);
            AddKeybindOption("gearDownKeybindPress", "Gear down key assignment", GameInput.Device.Keyboard, Config.GearDownKeybindValue);

            AddKeybindOption("healthKeybindPress", "Health key assignment", GameInput.Device.Keyboard, Config.HealthKeybindValue);
            AddKeybindOption("powerKeybindPress", "Power key assignment", GameInput.Device.Keyboard, Config.PowerKeybindValue);

            AddSliderOption("healthLowerLimitSlider", "Health low % stats colour change @", 1, 49, Config.HealthLowerLimitSliderValue);
            AddSliderOption("healthUpperLimitSlider", "Health high % stats colour change @", 51, 100, Config.HealthUpperLimitSliderValue);

            AddSliderOption("powerLowerLimitSlider", "Power low % stats colour change @", 1, 49, Config.PowerLowerLimitSliderValue);
            AddSliderOption("powerUpperLimitSlider", "Power high % stats colour change @", 51, 100, Config.PowerUpperLimitSliderValue);

            AddSliderOption("tempMothLowerLimitSlider", "°C low stats colour change @", 0, 40, Config.TempMothLowerLimitSliderValue);
            AddSliderOption("tempMothUpperLimitSlider", "°C high stats colour change @", 41, 50, Config.TempMothUpperLimitSliderValue);

        } // end public override void BuildModOptions()

    } // end public class Options



    // ######################################################################
    // Patch uGUI_SeamothHUD class Update() - all display health, energy and temperature changes
    //
    // ######################################################################

    [HarmonyPatch(typeof(uGUI_SeamothHUD))]  // Patch for the uGUI_SeamothHUD class.
    [HarmonyPatch("Update")]        // The uGUI_SeamothHUD class's Update method.
    internal class uGUI_SeamothHUD_Update_Patch
    {

        // Change vanilla uGUI_SeamothHUD operation.
        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(uGUI_SeamothHUD __instance)
        {

            Player main = Player.main;
            if (main != null)
            {
                Vehicle thisSeamoth = (main.GetVehicle() as SeaMoth);

                string colorStart;
                string colorWhite = "<color=white>";
                string colorYellow = "<color=yellow>";
                string colorRed = "<color=red>";
                string colorEnd = "</color>";



                // ################################################
                // Health display                

                if (thisSeamoth != null)
                {
                    LiveMixin thisLiveMixin = thisSeamoth.GetComponent<LiveMixin>();
                    float healthStatus = thisLiveMixin.GetHealthFraction();
                    StringBuilder stringBuilder = new StringBuilder();
                    bool upgradeLoaded = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;

                    // Run only if the upgrade is loaded
                    if (upgradeLoaded)
                    {
                        if (Config.MarchThroughHealthValue == 1f) // display maximum health (mh) allways in default colours
                        {
                            float thisMaxHealth = thisLiveMixin.data.maxHealth;
                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(' ');
                            stringBuilder.Append(Mathf.Round(thisMaxHealth).ToString());
                            stringBuilder.Append("</size>");
                            stringBuilder.Append("<size=");
                            stringBuilder.Append((Config.VehicleFontSizeSliderValue / 1.5).ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorYellow);
                            stringBuilder.Append("mh");
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                        else if (Config.MarchThroughHealthValue == 2f) // display health and change colours if damaged as per mod options settings
                        {
                            float thisHealth = thisLiveMixin.health;

                            // Set warning colours of health status as per mod options
                            if (healthStatus * 100f <= Mathf.Floor(Config.HealthLowerLimitSliderValue))
                                colorStart = colorRed;
                            else if (healthStatus * 100f > Mathf.Floor(Config.HealthLowerLimitSliderValue) && healthStatus * 100f <= Mathf.Floor(Config.HealthUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorWhite;

                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorStart);
                            stringBuilder.Append(' ');
                            stringBuilder.Append(Mathf.Round(thisHealth).ToString());
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                            stringBuilder.Append("<size=");
                            stringBuilder.Append((Config.VehicleFontSizeSliderValue / 1.5).ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorYellow);
                            stringBuilder.Append("h");
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                        else // display health status as a % and change colours if damaged as per mod options settings
                        {
                            // Set warning colours of health status as per mod options
                            if (healthStatus * 100f <= Mathf.Floor(Config.HealthLowerLimitSliderValue))
                                colorStart = colorRed;
                            else if (healthStatus * 100f > Mathf.Floor(Config.HealthLowerLimitSliderValue) && healthStatus * 100f <= Mathf.Floor(Config.HealthUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorWhite;

                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorStart);
                            stringBuilder.Append(' ');
                            stringBuilder.Append(Mathf.Round(healthStatus * 100f).ToString());
                            stringBuilder.Append("%");
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                    } // end if (upgradeLoaded)
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(Mathf.Round(healthStatus * 100f).ToString());
                        __instance.textHealth.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)



                // ################################################
                // Power display

                if (thisSeamoth != null)
                {
                    EnergyMixin thisEnergyMixing = thisSeamoth.GetComponent<EnergyMixin>();
                    EnergyInterface thisEnergyInterface = thisEnergyMixing.GetComponent<EnergyInterface>();
                    float charge;
                    float capacity;
                    thisEnergyInterface.GetValues(out charge, out capacity);
                    StringBuilder stringBuilder = new StringBuilder();
                    bool upgradeLoaded = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;

                    // Run only if the upgrade is loaded
                    if (upgradeLoaded)
                    {
                        if (Config.MarchThroughPowerValue == 1f) // display maximum cell charge capacity in units(mu) allways in default colours
                        {
                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(capacity.ToString()); // Displays vehicle cell capacity
                            stringBuilder.Append("</size>");
                            stringBuilder.Append("<size=");
                            stringBuilder.Append((Config.VehicleFontSizeSliderValue / 1.5).ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorYellow);
                            stringBuilder.Append("mu");
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                        }
                        else if (Config.MarchThroughPowerValue == 2f) // display cell charge capacity in units(u) and change colours as per mod options settings
                        {
                            // Set warning colours of charge status as per mod options
                            if (charge / capacity * 100f <= Mathf.Floor(Config.PowerLowerLimitSliderValue))
                                colorStart = colorRed;
                            else if (charge / capacity * 100f > Mathf.Floor(Config.PowerLowerLimitSliderValue) && charge / capacity * 100f <= Mathf.Floor(Config.PowerUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorWhite;

                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorStart);
                            stringBuilder.Append(Mathf.RoundToInt(charge).ToString()); // Displays vehicle cell charge
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                            stringBuilder.Append("<size=");
                            stringBuilder.Append((Config.VehicleFontSizeSliderValue / 1.5).ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorYellow);
                            stringBuilder.Append("u");
                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                        }
                        else // display cell charge in % and change colours as per mod options settings
                        {
                            // Set warning colours of charge status as per mod options
                            if (charge / capacity * 100f <= Mathf.Floor(Config.PowerLowerLimitSliderValue))
                                colorStart = colorRed;
                            else if (charge / capacity * 100f > Mathf.Floor(Config.PowerLowerLimitSliderValue) && charge / capacity * 100f <= Mathf.Floor(Config.PowerUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorWhite;

                            // Set font size and colour
                            stringBuilder.Append("<size=");
                            stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                            stringBuilder.Append(">");
                            stringBuilder.Append(colorWhite);
                            string noCellsDescription = "N/A";

                            if (capacity == 0f) // display if no cell present
                            {
                                stringBuilder.Append(colorRed);
                                stringBuilder.Append(noCellsDescription);
                                stringBuilder.Append(colorEnd);
                            } // end if (capacity == 0f)
                            else
                            {
                                if (capacity == 1f) // if Seamoth cell is fully charged
                                {
                                    stringBuilder.Append(colorWhite);
                                    stringBuilder.Append("100%");
                                    stringBuilder.Append(colorEnd);
                                } // end if (capacity == 1f)
                                else // if seamoth cell is partially charged
                                {
                                    stringBuilder.Append(colorStart);
                                    stringBuilder.Append(Mathf.RoundToInt(charge / capacity * 100f).ToString()); // Displays vehicle charge                                
                                    stringBuilder.Append("%");
                                    stringBuilder.Append(colorEnd);
                                } // end else
                            } // end else

                            stringBuilder.Append(colorEnd);
                            stringBuilder.Append("</size>");
                        } // end else

                        __instance.textPower.text = stringBuilder.ToString();
                    } // end if (upgradeLoaded)  
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(Mathf.RoundToInt(charge / capacity * 100f).ToString());
                        __instance.textPower.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)


                // ################################################
                // Temperature display

                if (thisSeamoth != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    bool upgradeLoaded = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;
                    int waterTemp = Traverse.Create(__instance).Field("lastTemperature").GetValue<int>();

                    if (upgradeLoaded)
                    {
                        // Set warning colours of water temperature as per mod options
                        if (waterTemp <= Mathf.Floor(Config.TempMothLowerLimitSliderValue))
                            colorStart = colorWhite;
                        else if (waterTemp > Mathf.Floor(Config.TempMothLowerLimitSliderValue) && waterTemp <= Mathf.Floor(Config.TempMothUpperLimitSliderValue))
                            colorStart = colorYellow;
                        else
                            colorStart = colorRed;

                        // Set font size and colour
                        stringBuilder.Append("<size=");
                        stringBuilder.Append(Config.VehicleFontSizeSliderValue.ToString());
                        stringBuilder.Append(">");
                        stringBuilder.Append(colorStart);
                        stringBuilder.Append(waterTemp.ToString());
                        stringBuilder.Append(colorEnd);
                        stringBuilder.Append("</size>");
                        __instance.textTemperature.text = stringBuilder.ToString();
                    } // end if (upgradeLoaded)
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(waterTemp.ToString());
                        __instance.textTemperature.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)

            } // end if (main != null)

        } // end public static void Postfix(uGUI_SeamothHUD __instance)

    } // internal class uGUI_SeamothHUD_Update_Patch



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
                        if (Config.SeamothGearValue == 1f)
                        {
                            Config.SeamothGearValue = 2f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 2f);
                        }
                        else if (Config.SeamothGearValue == 2f)
                        {
                            Config.SeamothGearValue = 3f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 3f);
                        }
                        else if (Config.SeamothGearValue == 3f)
                        {
                            Config.SeamothGearValue = 4f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 4f);
                        }
                        else if (Config.SeamothGearValue == 4f)
                        {
                            Config.SeamothGearValue = 5f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 5f);
                        }
                        else if (Config.SeamothGearValue == 5f)
                        {
                            Config.SeamothGearValue = 6f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 6f);
                        }
                    } // end if (KeyCodeUtils.GetKeyDown(KeyCode.LeftShift))

                    // Detect key press and set variable (march down) to set Seamoth gear
                    if (KeyCodeUtils.GetKeyDown(Config.GearDownKeybindValue))
                    {
                        if (Config.SeamothGearValue == 6f)
                        {
                            Config.SeamothGearValue = 5f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 5f);
                        }
                        else if (Config.SeamothGearValue == 5f)
                        {
                            Config.SeamothGearValue = 4f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 4f);
                        }
                        else if (Config.SeamothGearValue == 4f)
                        {
                            Config.SeamothGearValue = 3f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 3f);
                        }
                        else if (Config.SeamothGearValue == 3f)
                        {
                            Config.SeamothGearValue = 2f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 2f);
                        }
                        else if (Config.SeamothGearValue == 2f)
                        {
                            Config.SeamothGearValue = 1f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", 1f);
                        }
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


    internal static class SeamothInfo
    {
        internal static float lastSeamothGearValue = 0f;
    }



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



    // ######################################################################
    // Patch Vehicle class Update()
    //
    // ######################################################################

    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("Update")]        // The Vehicle class's Update method.
    internal class Vehicle_Update_Patch
    {

        // ######################################################################
        // Helper methods
        // ######################################################################

        public static void applyGearSpeed()
        {
        }

        // not called or tested yet - changes energy every 1 second
        private static void AdjustEnergyConsumption(Vehicle thisSeaMoth, float thisAmount)
        {
            EnergyMixin thisEnergyMixing = thisSeaMoth.GetComponent<EnergyMixin>();

            bool flag = GearInfo.nextEnergyConsumption == null;
            if (flag)
            {
                GearInfo.nextEnergyConsumption = new float?(Time.time + 1f);
            }
            bool flag2 = Time.time < GearInfo.nextEnergyConsumption.Value + 1f;
            if (!flag2)
            {
                //EnergyMixin energyMixin = GearInfo.GetEnergyMixin();
                bool flag3 = thisEnergyMixing == null;
                if (!flag3)
                {
                    thisEnergyMixing.ConsumeEnergy(thisAmount);
                    GearInfo.nextEnergyConsumption = new float?(Time.time + 1f);
                }
            }
        }



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
                    if (SeamothInfo.lastSeamothGearValue != 0f)
                    {
                        thisSeamoth.forwardForce = forwardForce;
                        thisSeamoth.backwardForce = backwardForce;
                        thisSeamoth.sidewardForce = sidewardForce;
                        thisSeamoth.verticalForce = verticalForce;
                        SeamothInfo.lastSeamothGearValue = 0f;
                    }

                } // end else

            }//end if (main != null)

        } // end public static void Postfix(Vehicle __instance)

    } // end internal class Vehicle_Update_Patch



    // ######################################################################
    // Patch Player class Update()
    //
    // ######################################################################

    [HarmonyPatch(typeof(Player))]  // Patch for the Player class.
    [HarmonyPatch("Update")]        // The Player class's Update method.
    internal class Player_Update_Patch
    {

        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(Player __instance)
        {
            if (__instance != null)
            {
                // Implement GUI gear info text display
                Vehicle thisSeamoth = (__instance.GetVehicle() as SeaMoth);
                GameObject gameObject = GameObject.Find("HUD");
                GameObject gameObject2 = GameObject.Find("GearDisplayUI");

                if (thisSeamoth != null)
                {
                    // var count = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID);
                    bool upgradeLoaded = thisSeamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;
                    bool playerPiloting = __instance.GetMode() == Player.Mode.LockedPiloting;

                    if (upgradeLoaded && playerPiloting)
                    {
                        if (gameObject2 == null)
                            gameObject2 = new GameObject("GearDisplayUI");

                        gameObject2.transform.SetParent(gameObject.transform, false);
                        Text text = gameObject2.GetComponent<Text>();

                        if (text == null)
                            text = gameObject2.gameObject.AddComponent<Text>();

                        text.font = __instance.textStyle.font;
                        text.fontSize = Mathf.RoundToInt(Config.VehicleFontSizeSliderValue);
                        text.alignment = TextAnchor.LowerRight;
                        text.color = Color.white;
                        RectTransform component = text.GetComponent<RectTransform>();
                        component.localPosition = GearInfo.hud_Position;
                        component.sizeDelta = GearInfo.hud_Size;
                        GearInfo.gearDisplayText = text;
                        GearInfo.gameObject = gameObject2;

                        // gear 1 to 4 (4 being default speed) is displayed white, gear 5 yellow, and gear 6 red as energy consumption is high
                        if (Config.SeamothGearValue == 5f)
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + GearInfo.colorYellow + Config.SeamothGearValue.ToString() + GearInfo.colorEnd;
                        else if (Config.SeamothGearValue == 6f)
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + GearInfo.colorRed + Config.SeamothGearValue.ToString() + GearInfo.colorEnd;
                        else
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + Config.SeamothGearValue.ToString();

                        gameObject2.SetActive(true);

                    } // end if (upgradeLoaded)
                    else // remove if upgrade not loaded
                    {
                        if (gameObject2 != null)
                            gameObject2.SetActive(false);
                    }

                } // end if (thisSeamoth != null)
                else // remove if player is not in Seamoth
                {
                    if (gameObject2 != null)
                        gameObject2.SetActive(false);
                } // end else

            } // end if (__instance != null)

        } // end public static void Postfix(Player __instance)

    } // end internal class Player_Update_Patch

} // namespace SeamothEngineUpgrades 


// ######################################################################
// Code to handle module upgrade
//
// ######################################################################

namespace SeamothEngineUpgrades.Modules
{
    public class SeamothEngineUpgradesModule : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public SeamothEngineUpgradesModule() : base("SeamothEngineUpgradesModule", "Seamoth Engine Upgrades Module", "Adds Gears and enhances Health, Power and Temperature displays")
        {
            OnFinishedPatching += () =>
            {
                TechTypeID = this.TechType;
            };
        }
        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;
        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;
        public override TechGroup GroupForPDA => TechGroup.VehicleUpgrades;
        public override CraftTree.Type FabricatorType => CraftTree.Type.SeamothUpgrades;
        public override string[] StepsToFabricatorTab => new string[] { "SeamothModules" };
        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(TechType.SeamothElectricalDefense);
            var obj = GameObject.Instantiate(prefab);
            return obj;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.ComputerChip, 1),
                    new Ingredient(TechType.AdvancedWiringKit, 1),
                    new Ingredient(TechType.Gold,1),
                },
            };
        }
        public override string AssetsFolder { get; } = MainPatcher.AssetsFolder;

    } // end public class SeamothEngineUpgradesModule : Equipable

} // end namespace SeamothEngineUpgrades.Modules