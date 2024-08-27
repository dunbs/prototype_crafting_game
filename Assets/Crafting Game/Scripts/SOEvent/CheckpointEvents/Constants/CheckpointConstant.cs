using UnityEngine;
using CraftingGame;

namespace UnityAtoms
{
    /// <summary>
    /// Constant of type `Checkpoint`. Inherits from `AtomBaseVariable&lt;Checkpoint&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-teal")]
    [CreateAssetMenu(menuName = "Unity Atoms/Constants/Checkpoint", fileName = "CheckpointConstant")]
    public sealed class CheckpointConstant : AtomBaseVariable<Checkpoint> { }
}
