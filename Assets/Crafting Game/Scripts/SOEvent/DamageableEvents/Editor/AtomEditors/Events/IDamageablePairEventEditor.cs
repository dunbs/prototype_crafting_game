#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Event property drawer of type `IDamageablePair`. Inherits from `AtomEventEditor&lt;IDamageablePair, IDamageablePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IDamageablePairEvent))]
    public sealed class IDamageablePairEventEditor : AtomEventEditor<IDamageablePair, IDamageablePairEvent> { }
}
#endif
