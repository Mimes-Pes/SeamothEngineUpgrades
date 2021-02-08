using SMLHelper.V2.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SeamothEngineUpgrades.Utils
{
    public static class Helper
    {
        private static AssetBundle _bundle;
        public static AssetBundle Bundle
        {
            get
            {
                if (_bundle == null)
                {
                    var mainDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var assetsFolder = Path.Combine(mainDirectory, "Assets");
                    _bundle = AssetBundle.LoadFromFile(Path.Combine(assetsFolder, MainPatcher._AssetName));
                }
                return _bundle;
            }
            set
            {
                _bundle = value;
            }
        }

        public static GameObject GetGameObjectFromBundle(AssetBundle bundle, string filename)
        {
            return bundle.LoadAsset<GameObject>(filename);
        }
    }
}
