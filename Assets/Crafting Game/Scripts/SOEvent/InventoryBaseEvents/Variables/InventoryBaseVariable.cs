using UnityEngine;
using System;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Variable of type `InventoryBase`. Inherits from `AtomVariable&lt;InventoryBase, InventoryBasePair, InventoryBaseEvent, InventoryBasePairEvent, InventoryBaseInventoryBaseFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/InventoryBase", fileName = "InventoryBaseVariable")]
    public sealed class InventoryBaseVariable : AtomVariable<InventoryBase, InventoryBasePair, InventoryBaseEvent,
        InventoryBasePairEvent, InventoryBaseInventoryBaseFunction>
    {
        protected override bool ValueEquals(InventoryBase other)
        {
            return ReferenceEquals(other, Value);
        }
    }
}