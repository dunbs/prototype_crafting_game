#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryBase`. Inherits from `AtomDrawer&lt;InventoryBaseEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryBaseEvent))]
    public class InventoryBaseEventDrawer : AtomDrawer<InventoryBaseEvent> { }
}
#endif
