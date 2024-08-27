#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `MapManagerPair`. Inherits from `AtomEventEditor&lt;MapManagerPair, MapManagerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(MapManagerPairEvent))]
    public sealed class MapManagerPairEventEditor : AtomEventEditor<MapManagerPair, MapManagerPairEvent> { }
}
#endif
