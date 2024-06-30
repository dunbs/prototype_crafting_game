using System.Collections.Generic;
using UnityEngine;

namespace CraftingGame
{
    public abstract class InventoryBase : MonoBehaviour
    {
        // All the item in the list are using scriptable objects, this causes multiple items to have a single 
        // instance. Although this might be optimizing in term of performance, this is hard to maintain. 
        // Especially when adding the Equip & Discard system. For now, keeping an index for quick iterations. 

        public struct EquippedEventArgs
        {
            public readonly ItemBlueprint ItemBlueprint;
            public readonly int index;

            public EquippedEventArgs(ItemBlueprint itemBlueprint, int index)
            {
                ItemBlueprint = itemBlueprint;
                this.index = index;
            }
        }

        public abstract event System.Action<ItemBlueprint> OnItemAdded;
        public abstract event System.Action<ItemBlueprint> OnItemRemoved;
        public abstract event System.Action<EquippedEventArgs> OnItemEquipped;

        public abstract IReadOnlyList<ItemBlueprint> Items { get; }

        public abstract int EquippedIndex { get; protected set; }

        public abstract void AddToInventory(ItemBlueprint item);

        public abstract void RemoveFromInventory(ItemBlueprint item);

        public abstract void SetEquipped(int index);
    }
}