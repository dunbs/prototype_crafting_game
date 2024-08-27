using UnityEngine;
using CraftingGame;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `CheckpointPair`. Inherits from `AtomEvent&lt;CheckpointPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/CheckpointPair", fileName = "CheckpointPairEvent")]
    public sealed class CheckpointPairEvent : AtomEvent<CheckpointPair>
    {
    }
}
