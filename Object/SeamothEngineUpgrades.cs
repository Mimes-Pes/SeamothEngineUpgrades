using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SeamothEngineUpgrades.InGame;
using SMLHelper.V2.Utility;
using System.IO;

namespace SeamothEngineUpgrades.Modules
{
    public class SeamothEngineUpgradesModule : Equipable
    {
        public const string _ClassID = "SeamothEngineUpgradesModule";
        public const string _FriendlyName = "Seamoth Engine Upgrades Module";
        public const string _ShortDescription = "Adds Gears and enhances Health, Power and Temperature displays";
        public static TechType TechTypeID { get; protected set; }
        public SeamothEngineUpgradesModule() : base(_ClassID, _FriendlyName, _ShortDescription)
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
            var UIprefab = GameObject.Instantiate(Utils.Helper.GetGameObjectFromBundle("VeichleUI.prefab"));
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

        protected override Atlas.Sprite GetItemSprite()
        {
            return Utils.Helper.GetSpriteFromBundle("SeamothEngineUpgradesModule.png");
        }
    }

}