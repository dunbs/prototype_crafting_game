#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Checkpoint`. Inherits from `AtomEventEditor&lt;Checkpoint, CheckpointEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(CheckpointEvent))]
    public sealed class CheckpointEventEditor : AtomEventEditor<Checkpoint, CheckpointEvent> { }
}
#endif
