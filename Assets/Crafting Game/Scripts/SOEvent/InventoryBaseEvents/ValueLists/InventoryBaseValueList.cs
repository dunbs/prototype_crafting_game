using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Value List of type `InventoryBase`. Inherits from `AtomValueList&lt;InventoryBase, InventoryBaseEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/InventoryBase", fileName = "InventoryBaseValueList")]
    public sealed class InventoryBaseValueList : AtomValueList<InventoryBase, InventoryBaseEvent> { }
}
