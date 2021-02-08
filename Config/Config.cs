using UnityEngine;
using SMLHelper.V2.Utility;


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

        }
        public static string GetTempColor(int waterTemp)
        {
            if (waterTemp <= Mathf.Floor(Config.TempMothLowerLimitSliderValue))
                return nameof(Color.white);
            else if (waterTemp > Mathf.Floor(Config.TempMothLowerLimitSliderValue) && waterTemp <= Mathf.Floor(Config.TempMothUpperLimitSliderValue))
                return nameof(Color.yellow);
            else
                return nameof(Color.red);
        }

        public static string GetPowerColor(float charge, float capacity)
        {
            if (charge / capacity * 100f <= Mathf.Floor(Config.PowerLowerLimitSliderValue))
                return nameof(Color.red);
            else if (charge / capacity * 100f > Mathf.Floor(Config.PowerLowerLimitSliderValue) && charge / capacity * 100f <= Mathf.Floor(Config.PowerUpperLimitSliderValue))
                return nameof(Color.yellow);
            else
                return nameof(Color.white);
        }

        public static string GetHealtColor(float healthStatus)
        {
            var healtLimit = Mathf.Floor(Config.HealthLowerLimitSliderValue);
            if (healthStatus * 100f <= healtLimit)
                return nameof(Color.red);
            else if (healthStatus * 100f > healtLimit && healthStatus * 100f <= healtLimit)
                return nameof(Color.yellow);
            else
                return nameof(Color.white);
        }

    }

}
