using System;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    public class PlayerInventory : Inventory
    {
        [SerializeField] private ItemBlueprintStorage itemBlueprintStorage;

        private void Awake()
        {
            var data = SaveSystem.Inventory.Load();
            if (data.itemBlueprintIds != null)
            {
                foreach (string dataItemBlueprintId in data.itemBlueprintIds)
                {
                    AddToInventory(itemBlueprintStorage.GetItemWithId(dataItemBlueprintId));
                }
            }

            EquippedIndex = data.equipped;
        }

        public override void AddToInventory(ItemBlueprint item)
        {
            base.AddToInventory(item);
            Save();
        }

        public override void RemoveFromInventory(ItemBlueprint item)
        {
            base.RemoveFromInventory(item);
            Save();
        }

        public override void SetEquipped(int index)
        {
            base.SetEquipped(index);
            Save();
        }

        private void Save()
        {
            SaveSystem.Inventory.Save(new SaveSystem.Inventory.Data
            {
                itemBlueprintIds = Items.Select(e => e.id).ToList(),
                equipped = EquippedIndex
            });
        }
    }
}