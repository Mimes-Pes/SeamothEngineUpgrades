using Harmony;
using SeamothEngineUpgrades.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace SeamothEngineUpgrades
{
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
                        {
                            SeamothEngineUiManager.SetGearText(Config.SeamothGearValue.ToString(), nameof(Color.yellow));
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + GearInfo.colorYellow + Config.SeamothGearValue.ToString() + GearInfo.colorEnd;
                        }
                        else if (Config.SeamothGearValue == 6f)
                        {
                            SeamothEngineUiManager.SetGearText(Config.SeamothGearValue.ToString(), nameof(Color.red));
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + GearInfo.colorRed + Config.SeamothGearValue.ToString() + GearInfo.colorEnd;
                        }
                        else
                        {
                            SeamothEngineUiManager.SetGearText(Config.SeamothGearValue.ToString(), nameof(Color.white));
                            GearInfo.gearDisplayText.text = GearInfo.hud_Text + Config.SeamothGearValue.ToString(); 
                        }

                        gameObject2.SetActive(true);
                        SeamothEngineUiManager.ShowUI(true);


                    } // end if (upgradeLoaded)
                    else // remove if upgrade not loaded
                    {

                        if (gameObject2 != null)
                        {
                            gameObject2.SetActive(false);
                            SeamothEngineUiManager.ShowUI(false);
                        }
                    }

                } // end if (thisSeamoth != null)
                else // remove if player is not in Seamoth
                {
                    if (gameObject2 != null)
                    {
                        gameObject2.SetActive(false);
                        SeamothEngineUiManager.ShowUI(false);
                    }
                }
            }
        }
    }
}