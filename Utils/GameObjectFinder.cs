﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SeamothEngineUpgrades.Utils
{
    public class GameObjectFinder
    {
        public static GameObject FindByName(GameObject go, string name)
        {
            Transform[] ts = go.GetComponentsInChildren<Transform>();
            foreach (var t in ts)
                if (t.gameObject.name == name) return t.gameObject;

            return null;
        }
    }
}
