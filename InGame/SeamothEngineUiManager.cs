﻿using SeamothEngineUpgrades.Utils;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SeamothEngineUpgrades.InGame
{
    public class SeamothEngineUiManager : MonoBehaviour
    {
        private static Color _default = Color.white;

        private static GameObject InfoUI;

        private static Text txtGear;
        private static Text txtLife;
        private static Text txtEnergy;

        public static bool IsUIVisible;
        //private static Button btnLife;
        //private static Button btnEnergy;

        void Awake()
        {
            //var parent = GameObject.Find("HUD").transform;
            //this.transform.SetParent(parent);
        }

        void Start()
        {
            InfoUI = GameObjectFinder.FindByName(this.gameObject, "InfoUI");
            txtGear = GameObjectFinder.FindByName(this.gameObject, "txtGear").GetComponent<Text>();
            txtLife = GameObjectFinder.FindByName(this.gameObject, "txtLife").GetComponent<Text>();
            txtEnergy = GameObjectFinder.FindByName(this.gameObject, "txtEnergy").GetComponent<Text>();

            //btnLife = GameObjectFinder.FindByName(this.gameObject, "btnLife").GetComponent<Button>();
            //btnEnergy = GameObjectFinder.FindByName(this.gameObject, "btnEnergy").GetComponent<Button>();

            //btnLife.onClick.AddListener(() => SwitchLife());
            //btnEnergy.onClick.AddListener(() => SwitchEnergy());

            InfoUI.SetActive(false);
        }

        public void Update()
        {
            if (Player.main == null) return;
            var _seamoth = (SeaMoth)Player.main.GetVehicle();
            if(_seamoth != null)
            {
                bool upgradeLoaded = _seamoth.modules.GetCount(Modules.SeamothEngineUpgradesModule.TechTypeID) > 0;
                bool playerPiloting = Player.main.GetMode() == Player.Mode.LockedPiloting;
                var isPDAOpened = Player.main.GetPDA().isInUse;
                var showUI = upgradeLoaded && playerPiloting && !isPDAOpened;
                ShowUI(showUI);
            }
            else
            {
                ShowUI(false);
            }

            // Set Gear
            if (SeamothEngineUiManager.IsUIVisible)
            {
                var gearColor = Config.SeamothGearValue <= 4 ? nameof(Color.white) : Config.SeamothGearValue == 5 ? nameof(Color.yellow) : nameof(Color.red);
                SeamothEngineUiManager.SetGearText(Config.SeamothGearValue.ToString(), gearColor);
            }
        }

        //private void SwitchEnergy()
        //{
        //}

        //private void SwitchLife()
        //{
        //}

        public static void ShowUI(bool value)
        {
            InfoUI.SetActive(value);
            IsUIVisible = value;
        }

        public static void SetLifeText(string value, string color = nameof(Color.white)) => SetColoredText(txtLife, value, color);
        public static void SetGearText(string value, string color = nameof(Color.white)) => SetColoredText(txtGear, value, color);
        public static void SetEnergyText(string value, string color = nameof(Color.white)) => SetColoredText(txtEnergy, value, color);

        private static void SetColoredText(Text obj, string value, string color)
        {
            try
            {
                obj.text = string.IsNullOrEmpty(color) ? $"{value}" : $"<color={color}>{value}</color>";
            }
            catch (System.Exception ex)
            {
                // Debug.Log(ex)
            }
        }
    }
}
