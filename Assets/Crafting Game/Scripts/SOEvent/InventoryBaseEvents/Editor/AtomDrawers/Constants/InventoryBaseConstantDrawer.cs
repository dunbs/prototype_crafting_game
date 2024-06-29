#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Constant property drawer of type `InventoryBase`. Inherits from `AtomDrawer&lt;InventoryBaseConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryBaseConstant))]
    public class InventoryBaseConstantDrawer : VariableDrawer<InventoryBaseConstant> { }
}
#endif
