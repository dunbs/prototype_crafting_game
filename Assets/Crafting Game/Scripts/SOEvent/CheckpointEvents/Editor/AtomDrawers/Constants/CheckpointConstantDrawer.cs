#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `Checkpoint`. Inherits from `AtomDrawer&lt;CheckpointConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(CheckpointConstant))]
    public class CheckpointConstantDrawer : VariableDrawer<CheckpointConstant> { }
}
#endif
