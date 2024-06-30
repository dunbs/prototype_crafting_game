#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Checkpoint`. Inherits from `AtomDrawer&lt;CheckpointEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CheckpointEvent))]
    public class CheckpointEventDrawer : AtomDrawer<CheckpointEvent> { }
}
#endif
