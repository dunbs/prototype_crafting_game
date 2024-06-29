using System.Collections.Generic;
using UnityEngine;

namespace CraftingGame
{
    public abstract class InventoryBase : MonoBehaviour
    {
        public abstract event System.Action<ItemBlueprint> OnItemAdded;
        public abstract event System.Action<ItemBlueprint> OnItemRemoved;

        public abstract IReadOnlyList<ItemBlueprint> Items { get; }

        public abstract void AddToInventory(ItemBlueprint item);

        public abstract void RemoveFromInventory(ItemBlueprint item);
    }
}