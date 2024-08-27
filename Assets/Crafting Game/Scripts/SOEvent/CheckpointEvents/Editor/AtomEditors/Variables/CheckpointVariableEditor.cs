using UnityEditor;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `Checkpoint`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(CheckpointVariable))]
    public sealed class CheckpointVariableEditor : AtomVariableEditor<Checkpoint, CheckpointPair> { }
}
