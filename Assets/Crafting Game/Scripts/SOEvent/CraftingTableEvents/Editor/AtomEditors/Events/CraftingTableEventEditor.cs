#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `CraftingTable`. Inherits from `AtomEventEditor&lt;CraftingTable, CraftingTableEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(CraftingTableEvent))]
    public sealed class CraftingTableEventEditor : AtomEventEditor<CraftingTable, CraftingTableEvent> { }
}
#endif
