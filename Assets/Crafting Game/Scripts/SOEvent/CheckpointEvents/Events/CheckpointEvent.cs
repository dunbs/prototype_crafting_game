using UnityEngine;
using CraftingGame;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `Checkpoint`. Inherits from `AtomEvent&lt;Checkpoint&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Checkpoint", fileName = "CheckpointEvent")]
    public sealed class CheckpointEvent : AtomEvent<Checkpoint>
    {
    }
}
