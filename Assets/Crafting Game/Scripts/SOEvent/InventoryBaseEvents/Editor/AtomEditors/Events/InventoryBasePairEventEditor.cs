#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Event property drawer of type `InventoryBasePair`. Inherits from `AtomEventEditor&lt;InventoryBasePair, InventoryBasePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(InventoryBasePairEvent))]
    public sealed class InventoryBasePairEventEditor : AtomEventEditor<InventoryBasePair, InventoryBasePairEvent> { }
}
#endif
