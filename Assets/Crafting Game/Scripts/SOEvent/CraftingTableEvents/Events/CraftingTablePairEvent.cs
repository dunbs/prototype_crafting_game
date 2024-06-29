using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `CraftingTablePair`. Inherits from `AtomEvent&lt;CraftingTablePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/CraftingTablePair", fileName = "CraftingTablePairEvent")]
    public sealed class CraftingTablePairEvent : AtomEvent<CraftingTablePair>
    {
    }
}
