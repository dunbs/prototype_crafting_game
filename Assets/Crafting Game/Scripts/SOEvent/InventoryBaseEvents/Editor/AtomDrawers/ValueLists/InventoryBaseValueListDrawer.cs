#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Value List property drawer of type `InventoryBase`. Inherits from `AtomDrawer&lt;InventoryBaseValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(InventoryBaseValueList))]
    public class InventoryBaseValueListDrawer : AtomDrawer<InventoryBaseValueList> { }
}
#endif
