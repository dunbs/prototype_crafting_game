using System;
using System.Collections.Generic;
using UnityEngine;

namespace CraftingGame
{
    public class Inventory : InventoryBase
    {
        private readonly List<ItemBlueprint> items = new();

        public override event Action<ItemBlueprint> OnItemAdded;
        public override event Action<ItemBlueprint> OnItemRemoved;
        public override IReadOnlyList<ItemBlueprint> Items => items;

        public override void AddToInventory(ItemBlueprint item)
        {
            items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public override void RemoveFromInventory(ItemBlueprint item)
        {
            items.Remove(item);
            OnItemRemoved?.Invoke(item);
        }
    }
}