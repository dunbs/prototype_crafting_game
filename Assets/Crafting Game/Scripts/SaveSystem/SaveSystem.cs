using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CraftingGame
{
    public static class SaveSystem
    {
        private const string GLOBAL_KEY = "Crafting";

        public static class Inventory
        {
            [Serializable]
            public struct Data
            {
                public List<string> itemBlueprintIds;
                public int equipped;

                public Data(List<String> itemBlueprintIds, int equipped)
                {
                    this.itemBlueprintIds = itemBlueprintIds;
                    this.equipped = equipped;
                }
            }

            private const string KEY = GLOBAL_KEY + "_Inventory";

            public static void Save(Data data)
            {
                PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));
            }

            public static Data Load()
            {
                var json = PlayerPrefs.GetString(KEY, string.Empty);
                return !string.IsNullOrWhiteSpace(json)
                    ? JsonUtility.FromJson<Data>(json)
                    : new Data(default, -1);
            }
        }
    }
}