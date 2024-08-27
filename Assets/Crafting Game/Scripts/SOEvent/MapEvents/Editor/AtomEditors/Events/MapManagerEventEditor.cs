#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `MapManager`. Inherits from `AtomEventEditor&lt;MapManager, MapManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(MapManagerEvent))]
    public sealed class MapManagerEventEditor : AtomEventEditor<MapManager, MapManagerEvent> { }
}
#endif
