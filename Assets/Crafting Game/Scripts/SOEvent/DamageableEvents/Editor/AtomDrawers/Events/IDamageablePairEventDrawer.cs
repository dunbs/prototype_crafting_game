#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Event property drawer of type `IDamageablePair`. Inherits from `AtomDrawer&lt;IDamageablePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDamageablePairEvent))]
    public class IDamageablePairEventDrawer : AtomDrawer<IDamageablePairEvent> { }
}
#endif
