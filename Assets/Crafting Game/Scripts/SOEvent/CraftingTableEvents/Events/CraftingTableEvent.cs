using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `CraftingTable`. Inherits from `AtomEvent&lt;CraftingTable&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/CraftingTable", fileName = "CraftingTableEvent")]
    public sealed class CraftingTableEvent : AtomEvent<CraftingTable>
    {
    }
}
