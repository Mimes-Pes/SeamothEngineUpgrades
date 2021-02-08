using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SeamothEngineUpgrades.InGame;

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
            var prefab = GameObject.Instantiate(CraftData.GetPrefabForTechType(TechType.SeamothElectricalDefense));

            //Add UI
            var UIprefab = GameObject.Instantiate(Utils.Helper.Bundle.LoadAsset<GameObject>("VeichleUI.prefab"));
            UIprefab.AddComponent<SeamothEngineUiManager>();

            return prefab;
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

    }

}