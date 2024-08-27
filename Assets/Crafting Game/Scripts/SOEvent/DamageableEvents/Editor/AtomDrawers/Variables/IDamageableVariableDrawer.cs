#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Variable property drawer of type `IDamageable`. Inherits from `AtomDrawer&lt;IDamageableVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDamageableVariable))]
    public class IDamageableVariableDrawer : VariableDrawer<IDamageableVariable> { }
}
#endif
