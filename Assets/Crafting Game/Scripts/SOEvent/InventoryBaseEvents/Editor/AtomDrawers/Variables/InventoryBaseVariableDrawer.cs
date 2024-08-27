#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable property drawer of type `InventoryBase`. Inherits from `AtomDrawer&lt;InventoryBaseVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryBaseVariable))]
    public class InventoryBaseVariableDrawer : VariableDrawer<InventoryBaseVariable> { }
}
#endif
