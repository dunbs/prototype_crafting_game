#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `CheckpointPair`. Inherits from `AtomEventEditor&lt;CheckpointPair, CheckpointPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(CheckpointPairEvent))]
    public sealed class CheckpointPairEventEditor : AtomEventEditor<CheckpointPair, CheckpointPairEvent> { }
}
#endif
