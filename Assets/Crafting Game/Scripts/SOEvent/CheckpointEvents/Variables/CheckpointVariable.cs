using UnityEngine;
using System;
using CraftingGame;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `Checkpoint`. Inherits from `AtomVariable&lt;Checkpoint, CheckpointPair, CheckpointEvent, CheckpointPairEvent, CheckpointCheckpointFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Checkpoint", fileName = "CheckpointVariable")]
    public sealed class CheckpointVariable : AtomVariable<Checkpoint, CheckpointPair, CheckpointEvent,
        CheckpointPairEvent, CheckpointCheckpointFunction>
    {
        protected override bool ValueEquals(Checkpoint other)
        {
            return ReferenceEquals(other, Value);
        }
    }
}