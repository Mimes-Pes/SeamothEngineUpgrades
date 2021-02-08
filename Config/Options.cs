using UnityEngine;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;


// Main mod.
namespace SeamothEngineUpgrades  // Name of the mod.
{
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

        }

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

} // namespace SeamothEngineUpgrades 
