using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Variable of type `MapManager`. Inherits from `EquatableAtomVariable&lt;MapManager, MapManagerPair, MapManagerEvent, MapManagerPairEvent, MapManagerMapManagerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/MapManager", fileName = "MapManagerVariable")]
    public sealed class MapManagerVariable : AtomVariable<MapManager, MapManagerPair, MapManagerEvent,
        MapManagerPairEvent, MapManagerMapManagerFunction>
    {
        protected override bool ValueEquals(MapManager other)
        {
            return ReferenceEquals(other, Value);
        }
    }
}