#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable property drawer of type `CraftingTable`. Inherits from `AtomDrawer&lt;CraftingTableVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CraftingTableVariable))]
    public class CraftingTableVariableDrawer : VariableDrawer<CraftingTableVariable> { }
}
#endif
