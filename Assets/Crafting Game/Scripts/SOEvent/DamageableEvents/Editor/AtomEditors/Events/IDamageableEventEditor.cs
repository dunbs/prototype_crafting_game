#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Event property drawer of type `IDamageable`. Inherits from `AtomEventEditor&lt;IDamageable, IDamageableEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IDamageableEvent))]
    public sealed class IDamageableEventEditor : AtomEventEditor<IDamageable, IDamageableEvent> { }
}
#endif
