#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Event property drawer of type `IDamageable`. Inherits from `AtomDrawer&lt;IDamageableEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDamageableEvent))]
    public class IDamageableEventDrawer : AtomDrawer<IDamageableEvent> { }
}
#endif
