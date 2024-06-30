using UnityEngine;
using CraftingGame;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `CheckpointPair`. Inherits from `AtomEventInstancer&lt;CheckpointPair, CheckpointPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/CheckpointPair Event Instancer")]
    public class CheckpointPairEventInstancer : AtomEventInstancer<CheckpointPair, CheckpointPairEvent> { }
}
