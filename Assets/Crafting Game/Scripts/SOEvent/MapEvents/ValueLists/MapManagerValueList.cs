using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Value List of type `MapManager`. Inherits from `AtomValueList&lt;MapManager, MapManagerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/MapManager", fileName = "MapManagerValueList")]
    public sealed class MapManagerValueList : AtomValueList<MapManager, MapManagerEvent> { }
}
