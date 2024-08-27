#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `CraftingTablePair`. Inherits from `AtomEventEditor&lt;CraftingTablePair, CraftingTablePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(CraftingTablePairEvent))]
    public sealed class CraftingTablePairEventEditor : AtomEventEditor<CraftingTablePair, CraftingTablePairEvent> { }
}
#endif
