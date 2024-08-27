using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `InventoryBasePair`. Inherits from `AtomEvent&lt;InventoryBasePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/InventoryBasePair", fileName = "InventoryBasePairEvent")]
    public sealed class InventoryBasePairEvent : AtomEvent<InventoryBasePair>
    {
    }
}
