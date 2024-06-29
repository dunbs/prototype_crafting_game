using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Variable of type `CraftingTable`. Inherits from `EquatableAtomVariable&lt;CraftingTable, CraftingTablePair, CraftingTableEvent, CraftingTablePairEvent, CraftingTableCraftingTableFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/CraftingTable", fileName = "CraftingTableVariable")]
    public sealed class CraftingTableVariable : AtomVariable<CraftingTable, CraftingTablePair, CraftingTableEvent,
        CraftingTablePairEvent, CraftingTableCraftingTableFunction>
    {
        protected override bool ValueEquals(CraftingTable other)
        {
            return ReferenceEquals(other, _value);
        }
    }
}