using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event of type `MapManagerPair`. Inherits from `AtomEvent&lt;MapManagerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/MapManagerPair", fileName = "MapManagerPairEvent")]
    public sealed class MapManagerPairEvent : AtomEvent<MapManagerPair>
    {
    }
}
