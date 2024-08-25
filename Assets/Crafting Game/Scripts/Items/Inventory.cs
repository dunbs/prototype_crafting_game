using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CraftingGame
{
    public class Inventory : InventoryBase
    {
        private readonly List<ItemBlueprint> items = new();

        public override event Action<ItemBlueprint> OnItemAdded;
        public override event Action<ItemBlueprint> OnItemRemoved;
        public override event Action<EquippedEventArgs> OnItemEquipped;

        public override IReadOnlyList<ItemBlueprint> Items => items;
        public override int EquippedIndex { get; protected set; }

        protected void AddRange(IEnumerable<ItemBlueprint> items)
        {
            this.items.AddRange(items);
        }

        public override void AddToInventory(ItemBlueprint item)
        {
            items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public override void RemoveFromInventory(ItemBlueprint item)
        {
            var index = items.IndexOf(item);
            if (index < 0) return;
            items.RemoveAt(index);

            if (EquippedIndex == index)
            {
                SetEquipped(-1);
            }
            else if (EquippedIndex > index)
            {
                SetEquipped(EquippedIndex - 1);
            }

            OnItemRemoved?.Invoke(item);
        }

        public override void SetEquipped(ItemBlueprint itemBlueprint)
        {
            SetEquipped(items.IndexOf(itemBlueprint));
        }

        public override void SetEquipped(int index)
        {
            Assert.IsTrue(index < items.Count);
            EquippedIndex = index;
            OnItemEquipped?.Invoke(new EquippedEventArgs(
                index < 0 ? null : items[index],
                index)
            );
        }
    }
}