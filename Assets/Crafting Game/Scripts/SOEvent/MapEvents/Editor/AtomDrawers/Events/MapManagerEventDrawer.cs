#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `MapManager`. Inherits from `AtomDrawer&lt;MapManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(MapManagerEvent))]
    public class MapManagerEventDrawer : AtomDrawer<MapManagerEvent> { }
}
#endif
