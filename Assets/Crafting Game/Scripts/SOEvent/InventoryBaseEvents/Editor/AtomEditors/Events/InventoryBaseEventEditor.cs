#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryBase`. Inherits from `AtomEventEditor&lt;InventoryBase, InventoryBaseEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(InventoryBaseEvent))]
    public sealed class InventoryBaseEventEditor : AtomEventEditor<InventoryBase, InventoryBaseEvent> { }
}
#endif
