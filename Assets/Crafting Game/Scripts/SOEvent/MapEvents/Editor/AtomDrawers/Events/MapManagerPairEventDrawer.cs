#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `MapManagerPair`. Inherits from `AtomDrawer&lt;MapManagerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(MapManagerPairEvent))]
    public class MapManagerPairEventDrawer : AtomDrawer<MapManagerPairEvent> { }
}
#endif
