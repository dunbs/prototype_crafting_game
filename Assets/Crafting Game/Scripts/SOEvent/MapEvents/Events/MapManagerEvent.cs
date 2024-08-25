using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `MapManager`. Inherits from `AtomEvent&lt;MapManager&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/MapManager", fileName = "MapManagerEvent")]
    public sealed class MapManagerEvent : AtomEvent<MapManager>
    {
    }
}
