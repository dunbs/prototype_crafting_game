using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

namespace CraftingGame
{
    [CreateAssetMenu(fileName = "Crafting/Recipe", menuName = "Placeholder_Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [field: SerializeField] public ItemBlueprint[] ItemBlueprints { get; private set; }
        [field: SerializeField] public ItemBlueprint Result { get; private set; }

        private Dictionary<ItemBlueprint, int> itemBlueprintDict;
        private Dictionary<ItemBlueprint, int> itemBlueprintComparisionDict = new Dictionary<ItemBlueprint, int>();

        public Dictionary<ItemBlueprint, int> ItemBlueprintDict => itemBlueprintDict;

        [Button]
        private void OnValidate()
        {
            // for editor
            itemBlueprintDict = ItemBlueprints
                .GroupBy(e => e)
                .Select(e => new {item = e.Key, count = e.Count()})
                .ToDictionary(e => e.item, e => e.count);
        }

        private void Awake()
        {
            OnValidate();
        }


        [ContextMenu("Print blueprint dictionary")]
        private void PrintInternalDict()
        {
            Debug.Log(string.Join(", ", itemBlueprintDict));
        }

        public bool IsCloseMatch(IEnumerable<ItemBlueprint> items)
        {
            itemBlueprintComparisionDict.Clear();
            itemBlueprintComparisionDict.AddRange(itemBlueprintDict);

            foreach (ItemBlueprint itemBlueprint in items)
            {
                if (!itemBlueprintComparisionDict.ContainsKey(itemBlueprint))
                    return false;

                itemBlueprintComparisionDict[itemBlueprint] -= 1;
                if (itemBlueprintComparisionDict[itemBlueprint] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int CountMissingItems(IEnumerable<ItemBlueprint> items)
        {
            itemBlueprintComparisionDict.Clear();
            itemBlueprintComparisionDict.AddRange(itemBlueprintDict);

            int total = ItemBlueprints.Length;

            foreach (ItemBlueprint itemBlueprint in items)
            {
                if (!itemBlueprintComparisionDict.ContainsKey(itemBlueprint))
                    continue;

                itemBlueprintComparisionDict[itemBlueprint] -= 1;
                if (itemBlueprintComparisionDict[itemBlueprint] < 0)
                {
                    continue;
                }

                total--;
            }

            return total;
        }

        public bool IsMatch(IEnumerable<ItemBlueprint> items)
        {
            if (!IsCloseMatch(items))
            {
                return false;
            }

            foreach (var item in itemBlueprintComparisionDict)
            {
                if (item.Value != 0) return false;
            }

            return true;
        }
    }
}