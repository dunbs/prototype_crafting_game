#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryBasePair`. Inherits from `AtomDrawer&lt;InventoryBasePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryBasePairEvent))]
    public class InventoryBasePairEventDrawer : AtomDrawer<InventoryBasePairEvent> { }
}
#endif
