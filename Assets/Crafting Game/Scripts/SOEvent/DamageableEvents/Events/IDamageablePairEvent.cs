using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// Event of type `IDamageablePair`. Inherits from `AtomEvent&lt;IDamageablePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/IDamageablePair", fileName = "IDamageablePairEvent")]
    public sealed class IDamageablePairEvent : AtomEvent<IDamageablePair>
    {
    }
}
