using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `InventoryBase`. Inherits from `AtomEvent&lt;InventoryBase&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/InventoryBase", fileName = "InventoryBaseEvent")]
    public sealed class InventoryBaseEvent : AtomEvent<InventoryBase>
    {
    }
}
