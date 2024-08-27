#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `CraftingTable`. Inherits from `AtomDrawer&lt;CraftingTableEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CraftingTableEvent))]
    public class CraftingTableEventDrawer : AtomDrawer<CraftingTableEvent> { }
}
#endif
