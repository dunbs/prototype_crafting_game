#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `CraftingTablePair`. Inherits from `AtomDrawer&lt;CraftingTablePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CraftingTablePairEvent))]
    public class CraftingTablePairEventDrawer : AtomDrawer<CraftingTablePairEvent> { }
}
#endif
