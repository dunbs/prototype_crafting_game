#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `Checkpoint`. Inherits from `AtomDrawer&lt;CheckpointVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CheckpointVariable))]
    public class CheckpointVariableDrawer : VariableDrawer<CheckpointVariable> { }
}
#endif
